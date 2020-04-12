using Godot;
using System;

public class ThrusterSlot : Node2D
{
  [Export]
  public Vector2 thrust_ = new Vector2(0, -100);

  internal float power_ = 0;

  internal Particles2D particle_;

  public override void _Ready()
  {
    particle_ = GetNode<Particles2D>("Particles2D");
    particle_.Emitting = false;
  }

  public void UpdateStrength(float strength)
  {
    particle_.Emitting = strength > 0f;
    power_ = strength;
  }
}
