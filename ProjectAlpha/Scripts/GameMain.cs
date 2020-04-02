using Godot;
using System;

public class GameMain : Node
{

  PlayerShip ship_;
  public override void _Ready()
  {
    //ship_ = PlayerShipSystem.Instance().GetPlayer();
    ship_ = GetNode<PlayerShip>("PlayerShip");
  }

  public override void _UnhandledInput(InputEvent ev)
  {
    if (ev.IsActionReleased(Actions.BACK))
    {
      // Todo: somekind of dialog stack?
      GetTree().ChangeScene(Dialogs.MainMenu);
    }
  }

  public override void _PhysicsProcess(float delta)
  {
    Vector2 impuls = Vector2.Zero;
    if (Input.IsActionPressed(Actions.GAME_LEFT))
      ship_.ApplyCentralImpulse(left_ * delta);
    if (Input.IsActionPressed(Actions.GAME_RIGHT))
      ship_.ApplyCentralImpulse(right_ * delta);
    if (Input.IsActionPressed(Actions.GAME_UP))
      ship_.ApplyCentralImpulse(up_ * delta);
    if (Input.IsActionPressed(Actions.GAME_BOTTOM))
      ship_.ApplyCentralImpulse(down_ * delta);
  }
}