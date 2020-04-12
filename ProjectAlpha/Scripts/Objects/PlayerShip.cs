using Godot;
using System;
using System.Collections.Generic;

public class PlayerShip : RigidBody2D
{
  [Signal]
  delegate void OnWeaponSelected(WeaponSlot weapon);

  //[Export]
  bool spaceBreak_ = false;

  readonly Vector2 left_ = new Vector2(-100, 0);
  readonly Vector2 right_ = new Vector2(100, 0);
  readonly Vector2 up_ = new Vector2(0, -300);
  readonly Vector2 down_ = new Vector2(0, 100);

  List<WeaponSlot> weapons_ = new List<WeaponSlot>();
  List<ThrusterSlot> thrusters_ = new List<ThrusterSlot>();

  public override void _Ready()
  {
    foreach (var weapon in GetNode("Weapons").GetChildren())
      weapons_.Add(weapon as WeaponSlot);

    foreach (var thruster in GetNode("Thrusters").GetChildren())
      thrusters_.Add(thruster as ThrusterSlot);
  }

  public override void _PhysicsProcess(float delta)
  {
    foreach (var thruster in thrusters_)
    {
      if (thruster.power_ > 0)
        ApplyImpulse(thruster.Position, Transform.BasisXform(thruster.thrust_ * thruster.power_ * delta));
    }
  }

  internal void ToggleSpaceBreak()
  {
    if (spaceBreak_)
    {
      LinearDamp = 0.5f;
      AngularDamp = 0.3f;
    }
    else
    {
      LinearDamp = -1;
      AngularDamp = -1;
    }
    spaceBreak_ = !spaceBreak_;
  }

  internal void SetSpaceBreak(float br)
  {
    if (br > 0.0f)
    {
      LinearDamp = 1f * br;
      AngularDamp = 1f * br;
    }
    else
    {
      LinearDamp = -1;
      AngularDamp = -1;
    }

  }

  public void Fire(int idx = -1)
  {
    foreach (WeaponSlot weapon in GetNode<Node2D>("Weapons").GetChildren())
      weapon.Fire();
  }

  public void ToggleEngine(int idx)
  {
    GD.Print($"Toggle engine {idx}");
    if (idx >= 0 && idx < thrusters_.Count)
    {
      var thruster = thrusters_[idx];
      if (thruster.power_ > 0)
        thruster.power_ = 0;
      else
        thruster.power_ = 1;
    }
  }

  public void SetEngine(int idx, float strength)
  {
    if (idx >= 0 && idx < thrusters_.Count)
    {
      var thruster = thrusters_[idx];
      GD.Print($"{idx} : {thrusters_.Count}");
      thruster.UpdateStrength(strength);
    }
  }
}
