using Godot;
using System;

public class Ray : RayCast2D, IFireable
{
  private bool hit_ = false;
  private Vector2 collide_ = Vector2.Zero;

  public override void _Ready() { }

  public override void _PhysicsProcess(float delta)
  {
    Position = Vector2.Zero;
    CastTo = Vector2.Up * 500;
    //RayCast2D:
    var hit = IsColliding();
    if (hit != hit_)
      //CanvasItem:
      Update();
    hit_ = hit;

    if (hit_)
      collide_ = ToLocal(GetCollisionPoint());
    else
      collide_ = CastTo;
  }

  public override void _Draw()
  {
    var color = Colors.DarkGray;
    if (hit_)
      color = Colors.Red;
    DrawLine(Vector2.Zero, collide_, color);
    DrawCircle(Vector2.Zero, 3f, Colors.Green);
  }

  public void Fire(float strength, Vector2 globalPos, float rotation, Vector2 direction)
  {
    //RayCast2D:
    Enabled = true;
  }

  public bool IsLaser()
  {
    return true;
  }
}
