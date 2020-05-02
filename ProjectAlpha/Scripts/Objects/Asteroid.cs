using Godot;
using System;

public class Asteroid : RigidBody2D
{
  bool destroyed = false;

  public override void _Ready()
  {

  }

  public void Destroy()
  {
    if (destroyed)
      return;
    GetParent().RemoveChild(this);
    QueueFree();
    destroyed = true;
  }

}
