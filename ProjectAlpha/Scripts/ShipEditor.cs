using Godot;
using System;

public class ShipEditor : Node
{
  PlayerShip ship_;

  public override void _Ready()
  {
    ship_ = PlayerShipSystem.Instance().GetPlayer();
    ship_.Position = new Vector2(100, 100);
    AddChild(ship_);
  }

  public override void _UnhandledInput(InputEvent ev)
  {
    if (ev.IsActionReleased(Actions.BACK))
    {
      // Todo: somekind of dialog stack?
      GetTree().ChangeScene(Dialogs.MainMenu);
    }
  }

  private void OnPlayerShipWeaponSelected(WeaponSlot weapon)
  {
    GD.Print(weapon);
  }
}
