using Godot;
using System;
using System.Diagnostics;

public class AsteroidSpawner : Node
{
  private PackedScene asteroid_;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    asteroid_ = GD.Load("res://Objects/Asteroid.tscn") as PackedScene;
    SpawnAsteroid();
  }

  private void SpawnAsteroid()
  {
    Asteroid newAst = (Asteroid)asteroid_.Instance();
    InitializeAsteroid(newAst);
    AddChild(newAst);
  }

  private void InitializeAsteroid(Asteroid asteroid)
  {
    var rect = GetViewport().Size;
    asteroid.Position = new Vector2((float)GD.RandRange(0, rect.x), -100);

    asteroid.AngularVelocity = (float)GD.RandRange(-4, 4);
    asteroid.AngularDamp = 0;
    asteroid.LinearVelocity = new Vector2((float)GD.RandRange(-300, 300), 300);
    asteroid.LinearDamp = 0;
  }
}
