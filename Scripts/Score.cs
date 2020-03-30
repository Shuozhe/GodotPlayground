using Godot;
using System;

public class Score : Label
{

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {

  }

  public void AddScore(int score)
  {
    Text = (Int32.Parse(Text) + score).ToString();
    GD.Print($"Update Score to {Text}!");
  }

}
