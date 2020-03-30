using Godot;
using System;

public class PointsScored : Node2D
{
  public override void _Ready()
  {

  }

  private void _on_Timer_timeout()
  {
    QueueFree();
  }
}


