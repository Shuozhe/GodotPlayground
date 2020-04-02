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

  private void OnHitboxInput(Node viewport, InputEvent ev, int shapeIdx)
  {
    if (ev.IsActionPressed(Actions.GAME_SELECT))
    {
      GetParent().GetParent<PlayerShip>().EmitSignal("OnWeaponSelected", this);
    }
  }

  private void OnHitboxEntered()
  {
    GetNode<Polygon2D>("Shape").Color = Colors.DarkGray;
  }


  private void OnHitboxExited()
  {
    GetNode<Polygon2D>("Shape").Color = Colors.White;
  }

}


