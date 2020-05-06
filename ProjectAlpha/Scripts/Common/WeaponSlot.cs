using Godot;
using System;

public class WeaponSlot : Node2D
{
  [Export]
  private PackedScene ammoScene_ = GD.Load<PackedScene>("res://ProjectAlpha/Common/Laser.tscn");

  [Export]
  internal Color Color = Colors.White;
  [Export]
  internal Color SelectedColor = Colors.Red;
  [Export]
  internal Color HoverColor = Colors.DarkGray;

  private Polygon2D poly_ = null;

  IFireable ammo_ = null;

  private bool selected_ = false;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    poly_ = GetNode<Polygon2D>("Shape");
    ammo_ = (IFireable)ammoScene_.Instance();
    var rigid = (ammo_ as RigidBody2D);
    if (rigid != null)
      rigid.Sleeping = true;
    if (ammo_.IsLaser())
    {
      (ammo_ as RayCast2D).Enabled = true;
      // TODO: this throws error currently
      AddChild(ammo_ as Node2D);
    }
  }

  public void Fire(bool pressed)
  {
    if (ammo_ != null)
    {
      ammo_.Fire(1f, GlobalPosition, GlobalRotation, Vector2.Up.Rotated(GlobalRotation));
      if (!ammo_.IsLaser())
      {
        GetNode("/root").GetChild(0).AddChild(ammo_ as Node2D);
        ammo_ = (IFireable)ammoScene_.Instance();
      }
    }
  }

  public void Select(bool selected = true)
  {
    selected_ = selected;
    if (selected)
      poly_.Color = SelectedColor;
    else
      poly_.Color = Color;
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
    if (!selected_)
      poly_.Color = HoverColor;
  }

  private void OnHitboxExited()
  {
    if (!selected_)
      poly_.Color = Color;
  }
}


