using Godot;
using System;

public class LaserWeapon : Node2D
{
  PackedScene laser;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
	laser = GD.Load("res://Objects/Laser.tscn") as PackedScene;
  }

  public void Fire()
  {
	var laserInstance = (Area2D)laser.Instance();
	laserInstance.GlobalPosition = GlobalPosition;
	GetNode("/root/Game").AddChild(laserInstance);
  }
}
