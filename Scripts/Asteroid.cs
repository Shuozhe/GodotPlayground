using Godot;
using System;

public class Asteroid : RigidBody2D
{
  private bool destroyed = false;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    destroyed = false;
  }

  public void Destroy()
  {
    GD.Print("Asteroid Destroyed!");
    if (destroyed)
      return;
    destroyed = true;
    GetParent().RemoveChild(this);
    QueueFree();
  }
}
