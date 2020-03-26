using Godot;
using System;

public class AsteroidSpawner : Node
{
  private PackedScene asteroid;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    asteroid = GD.Load("res://Objects/Asteroid.tscn") as PackedScene;
    SpawnAsteroid();
  }

  private void SpawnAsteroid()
  {
    Asteroid newAst = (Asteroid)asteroid.Instance();
    newAst.Position = new Vector2(50, -100);
    AddChild(newAst);
  }
}

