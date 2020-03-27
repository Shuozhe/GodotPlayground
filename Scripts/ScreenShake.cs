using Godot;
using System;

public class ScreenShake : Node
{
  private Camera2D camera;
  private float amplitute = 0;
  private int prio = -1;

  private Timer durationTimer_;
  private Timer freqTimer_;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    camera = (Camera2D)GetParent();
    durationTimer_ = GetNode<Timer>("Duration");
    freqTimer_ = GetNode<Timer>("Frequency");
  }

  public void Start(float duration = .2f, float frequency = 15, float amplitute_ = 16, int prio_ = 0)
  {
    if (prio_ > prio)
    {
      prio = prio_;
      amplitute = amplitute_;

      durationTimer_.WaitTime = duration;
      freqTimer_.WaitTime = 1.0f / frequency;
      durationTimer_.Start();
      freqTimer_.Start();

      NewShake();
    }
  }

  private void NewShake()
  {
    Vector2 rand = new Vector2((float)GD.RandRange(-amplitute, amplitute), (float)GD.RandRange(-amplitute, amplitute));
    var tween = GetNode<Tween>("ShakeTween");
    tween.InterpolateProperty(camera, "offset", camera.Offset, rand, freqTimer_.WaitTime, Tween.TransitionType.Sine);
    tween.Start();
  }

  private void Reset()
  {
    var tween = GetNode<Tween>("ShakeTween");
    tween.InterpolateProperty(camera, "offset", camera.Offset, Vector2.Zero, freqTimer_.WaitTime, Tween.TransitionType.Sine);
    tween.Start();
    prio = -1;
  }

  private void _on_Duration_timeout()
  {
    Reset();
    freqTimer_.Stop();
  }


  private void _on_Frequency_timeout()
  {
    NewShake();
  }

  private void _on_Player_OnFire()
  {
    Start(3f, 15, 4, 0);
  }
}

