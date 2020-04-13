using Godot;
using System;

public class Ray : RayCast2D
{
  private Line2D line_;

  public override void _Ready()
  {
    line_ = GetNode<Line2D>("Line2D");
    //line_.Points[1]
  }
}
