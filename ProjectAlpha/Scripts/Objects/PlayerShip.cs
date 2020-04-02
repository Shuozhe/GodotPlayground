using Godot;
using System;

public class PlayerShip : RigidBody2D
{
  [Signal]
  delegate void OnWeaponSelected(WeaponSlot weapon);

  readonly Vector2 left_ = new Vector2(-100, 0);
  readonly Vector2 right_ = new Vector2(100, 0);
  readonly Vector2 up_ = new Vector2(0, -300);
  readonly Vector2 down_ = new Vector2(0, 100);

  public override void _Ready()
  {

  }

  public override void _UnhandledInput(InputEvent ev)
  {
    if (ev.IsActionPressed(Actions.FIRE))
    {
      foreach (WeaponSlot weapon in GetNode<Node2D>("Weapons").GetChildren())
        weapon.Fire();
    }
  }

  public void ApplyImpuse(float left_)
  {

  }
}
