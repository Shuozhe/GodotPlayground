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

  public override void _Draw()
  {
    // TODO: why is this always 0?
    if (power_ > 0f)
    {
      DrawLine(Vector2.Zero, thrust_, Colors.Red, 5f);
      GD.Print($"Drawing {thrust_}");
    }
    GD.Print($"_Draw: {power_}");
  }

  public void UpdateStrength(float power)
  {
    if (power != power_)
      Update();
    particle_.Emitting = power > 0f;
    power_ = power;
  }
}
