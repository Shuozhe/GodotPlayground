using Godot;
using System;
using System.Diagnostics;

public class AsteroidSpawner : Node
{
  readonly private PackedScene asteroid_ = GD.Load("res://Objects/Asteroid.tscn") as PackedScene;

  float spawnInterval_;
  float difficultyIndex_;


  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    Restart();
    SpawnAsteroid();
  }

  public void Restart()
  {
    spawnInterval_ = 2.0f;
    difficultyIndex_ = 1.5f;
    GetNode<Timer>("SpawnTimer").WaitTime = spawnInterval_ / difficultyIndex_;
  }

  private void SpawnAsteroid()
  {
    AsteroidOld newAst = (AsteroidOld)asteroid_.Instance();
    InitializeAsteroid(newAst);
    AddChild(newAst);
  }

  private void InitializeAsteroid(AsteroidOld asteroid)
  {
    var rect = GetViewport().Size;
    asteroid.Position = new Vector2((float)GD.RandRange(0, rect.x), -100);

    asteroid.AngularVelocity = (float)GD.RandRange(-4, 4);
    asteroid.AngularDamp = 0;
    asteroid.LinearVelocity = new Vector2((float)GD.RandRange(-300, 300), 300);
    asteroid.LinearDamp = 0;
  }

  private void _on_DifficultyTimer_timeout()
  {
    GetNode<Timer>("SpawnTimer").WaitTime = spawnInterval_ / difficultyIndex_;
    difficultyIndex_ += 1.0f;
  }
}
