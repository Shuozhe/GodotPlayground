using Godot;
using System;

public class Player : KinematicBody2D
{
  const float speed = 600;
  // Declare member variables here. Examples:
  // private int a = 2;
  // private string b = "text";

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {

  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	var vel = new Vector2();
	if (Input.IsActionPressed("ui_left"))
	  vel.x = -speed;
	if (Input.IsActionPressed("ui_right"))
	  vel.x = speed;
	if (Input.IsActionPressed("ui_up"))
	  vel.y = -speed;
	if (Input.IsActionPressed("ui_down"))
	  vel.y = speed;

	MoveAndCollide(vel * delta);
  }
}
