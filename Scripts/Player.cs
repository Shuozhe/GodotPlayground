using Godot;
using System;

public class Player : KinematicBody2D
{
  [Signal]
  public delegate void OnFire();

  [Signal]
  public delegate void OnPlayerDestroyed();

  PackedScene explosionScene_ = GD.Load<PackedScene>("res://Common/PlayerExplosion.tscn");

  const float speed = 600;


  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    var shake = GetParent().GetNode<Node>("MainCamera/ScreenShake");
    Connect("OnFire", shake, "_on_Player_OnFire");

    var game = GetParent();
    Connect("OnPlayerDestroyed", game, "_on_Player_OnPlayerDestroyed");
  }

  public override void _PhysicsProcess(float delta)
  {
    var vel = new Vector2();
    if (Input.IsActionPressed("ui_left"))
      vel.x = -speed;
    if (Input.IsActionPressed("ui_right"))
      vel.x = speed;
    //if (Input.IsActionPressed("ui_up"))
    //  vel.y = -speed;
    //if (Input.IsActionPressed("ui_down"))
    //  vel.y = speed;

    MoveAndCollide(vel * delta);
  }

  public override void _UnhandledInput(InputEvent ev)
  {
    if (ev.IsActionPressed("fire"))
    {
      var laser = GetNode("LaserWeapon") as LaserWeapon;
      laser.Fire();
      EmitSignal(nameof(OnFire));
    }
  }

  private void _on_Hitbox_body_entered(Node body)
  {
    if (!IsQueuedForDeletion() && body.IsInGroup("Asteroids"))
    {
      var particle = explosionScene_.Instance() as Particles2D;
      particle.Position = Position;
      GetParent().AddChild(particle);
      particle.Emitting = true;

      QueueFree();

      EmitSignal("OnPlayerDestroyed");
    }
  }
}
