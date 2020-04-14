using Godot;
using System;
using System.Collections;
using System.Diagnostics;

public class Laser : Area2D, IFireable
{

  public Vector2 direction_ = new Vector2(0, -1);
  float speed = 1000;
  bool destroyed = false;


  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    destroyed = false;
  }

  public override void _Process(float delta)
  {
    Position += direction_ * speed * delta;
  }


  // - - - = = = private signals = = = - - -

  private void _on_VisibilityNotifier2D_viewport_exited(object viewport)
  {
    GD.Print("Laser despawns!");
    this.CallDeferred("Destroy");
  }


  private void _on_Laser_body_shape_entered(int body_id, object body, int body_shape, int area_shape)
  {
    var asteroid = body as AsteroidOld;
    if (asteroid != null && asteroid.IsInGroup("Asteroids"))
    {
      GD.Print("Asteroid hit");
      asteroid.CallDeferred("Destroy");
      this.CallDeferred("Destroy");
    }
  }

  private void Destroy()
  {
    if (destroyed)
      return;
    GetParent().RemoveChild(this);
    QueueFree();
    destroyed = true;
  }

  public void Fire(float strength, Vector2 globalPos, float rotation, Vector2 direction)
  {
    Position = globalPos;
    Rotation = rotation;
    direction_ = direction;
  }
}
