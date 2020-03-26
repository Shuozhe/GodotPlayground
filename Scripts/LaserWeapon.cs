using Godot;
using System;

public class LaserWeapon : Node2D
{
  // Declare member variables here. Examples:
  // private int a = 2;
  // private string b = "text";

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    var laser = GD.Load("res://Objects/Laser.tscn");
  }

  public void Shoot()
  {
    var laser = GetNode("Laser");
  }

  //  // Called every frame. 'delta' is the elapsed time since the previous frame.
  //  public override void _Process(float delta)
  //  {
  //      
  //  }
}
