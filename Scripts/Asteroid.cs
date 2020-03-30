using Godot;
using System;

public class Asteroid : RigidBody2D
{
  private bool destroyed = false;

  readonly PackedScene asteroidSmallScene = GD.Load<PackedScene>("res://objects/AsteroidSmall.tscn");
  readonly RandomNumberGenerator rng = new RandomNumberGenerator();

  [Signal]
  public delegate void OnExplode();

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    destroyed = false;

    var camera = GetNode("/root/Game/MainCamera/ScreenShake");
    Connect("OnExplode", camera, "AsteroidExploded");
  }

  public void Destroy()
  {
    GD.Print("Asteroid Destroyed!");
    if (destroyed)
      return;
    destroyed = true;
    SpawnAsteroidSmall();
    GetParent().RemoveChild(this);
    QueueFree();
    EmitSignal("OnExplode");
  }

  virtual protected void SpawnAsteroidSmall(int num = 4)
  {
    for (int i = 0; i < num; i++)
    {
      var asteroid = (AsteroidSmall)asteroidSmallScene.Instance();
      asteroid.Position = Position;
      asteroid.RandomizeTrajectory();
      GetParent().AddChild(asteroid);
    }
  }

  private void _on_VisibilityNotifier2D_screen_exited()
  {
    QueueFree();
  }

  protected void RandomizeTrajectory()
  {
    rng.Randomize();
    AngularVelocity = rng.RandfRange(-4, 4);
    AngularDamp = 0;

    var rx = rng.RandiRange(-1, 1);
    var ry = rng.RandiRange(-1, 1);
    LinearVelocity = new Vector2(rx * 400, ry * 400);
    LinearDamp = 0;
  }
}
