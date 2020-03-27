using Godot;
using System;

public class Player : KinematicBody2D
{
  [Signal]
  public delegate void OnFire();

  const float speed = 600;
  // Declare member variables here. Examples:
  // private int a = 2;
  // private string b = "text";

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {

  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
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
      GD.Print("FIRE!");
      EmitSignal(nameof(OnFire));
    }
  }

  private void _on_Hitbox_body_entered(Node body)
  {
    GD.Print("Player hit by something..!");
    if (!IsQueuedForDeletion() && body.IsInGroup("Asteroids"))
    {
      QueueFree();
      GD.Print("Player hit by asteroid!");
    }
  }
}
