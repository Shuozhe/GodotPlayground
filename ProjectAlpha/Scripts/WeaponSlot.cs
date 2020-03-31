using Godot;
using System;

public class WeaponSlot : Node2D
{
  PackedScene ammoScene_ = GD.Load<PackedScene>("res://Objects/Laser.tscn");

  // Called when the node enters the scene tree for the first time.
  public override void _Ready() { }

  public void Fire()
  {
    var ammo = (Area2D)ammoScene_.Instance();
    ammo.GlobalPosition = GlobalPosition;
    GetNode("/root/Game").AddChild(ammo);
  }
}
