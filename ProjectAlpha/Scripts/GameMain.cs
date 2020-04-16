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
      // Todo: somekind of dialog stack?
      GetTree().ChangeScene(Dialogs.MainMenu);

    ship_.SetEngine(0, Input.GetActionStrength(Actions.GAME_LEFT));
    ship_.SetEngine(2, Input.GetActionStrength(Actions.GAME_RIGHT));
    ship_.SetEngine(1, Input.GetActionStrength(Actions.GAME_UP));
    ship_.SetSpaceBreak(Input.GetActionStrength(Actions.GAME_BOTTOM));
  }
}
