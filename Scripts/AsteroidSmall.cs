using Godot;
using System;

public class AsteroidSmall : Asteroid
{
  protected override int SCORE_VALUE { get { return 50; } }

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    base._Ready();
  }

  override protected void SpawnAsteroidSmall(int num = 0) { }

  //  // Called every frame. 'delta' is the elapsed time since the previous frame.
  //  public override void _Process(float delta)
  //  {
  //      
  //  }
}
