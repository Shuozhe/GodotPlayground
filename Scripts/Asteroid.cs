using Godot;
using System;
using System.Diagnostics;

public class Asteroid : RigidBody2D
{
  private bool destroyed = false;
  private PackedScene explosion_;

  readonly PackedScene asteroidSmallScene = GD.Load<PackedScene>("res://objects/AsteroidSmall.tscn");
  readonly RandomNumberGenerator rng = new RandomNumberGenerator();

  protected virtual int SCORE_VALUE { get { return 100; } }

  [Signal]
  public delegate void OnExplode();

  [Signal]
  public delegate void OnScoreChanged();

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    destroyed = false;

    var camera = GetNode("/root/Game/MainCamera/ScreenShake");
    explosion_ = GD.Load("res://Common/AsteroidParticle.tscn") as PackedScene;
    Connect("OnExplode", camera, "AsteroidExploded");
    var label = GetNode("/root/Game/GUI/MarginContainer/HBoxContainer/VBoxContainer/Score");
    Connect("OnScoreChanged", label, "AddScore");
  }

  public void Destroy()
  {
    GD.Print("Asteroid Destroyed!");
    if (destroyed)
      return;
    destroyed = true;
    SpawnAsteroidSmall();
    ExplosionParticle();
    ExplosionSound();
    GetParent().RemoveChild(this);
    QueueFree();

    EmitSignal("OnExplode");
    EmitSignal("OnScoreChanged", SCORE_VALUE);
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

  private void ExplosionParticle()
  {
    Debug.Assert(explosion_ != null);
    var explosion = explosion_.Instance() as Particles2D;
    explosion.Position = Position;
    GetParent().AddChild(explosion);
    explosion.Emitting = true;
  }

  private void ExplosionSound()
  {
    var audio = new AudioStreamPlayer2D();
    audio.Stream = GD.Load("res://assets/audio/sfx/AsteroidExplosion.wav") as AudioStream;
    audio.PitchScale = 1;
    audio.Position = Position;
    GetParent().AddChild(audio);
    audio.Play(0);
  }
}
