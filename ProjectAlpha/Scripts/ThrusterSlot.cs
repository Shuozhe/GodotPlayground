using Godot;
using System;

public class ThrusterSlot : Node2D
{
  [Export]
  public Vector2 thrust_ = new Vector2(0, -100);

  internal float power_ = 0;
}
