using Godot;
using System;

public class ShipEditor : Node
{
  public override void _Ready()
  {

  }

  public override void _UnhandledInput(InputEvent ev)
  {
    if (ev.IsActionReleased(Actions.BACK))
    {
      // Todo: somekind of dialog stack?
      GetTree().ChangeScene(Dialogs.MainMenu);
    }
  }
}
