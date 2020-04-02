using Godot;
using System;

public class ShipEditor : Node
{
  PlayerShip ship_;

  WeaponSlot currentWeapon_ = null;

  public override void _Ready()
  {
    ship_ = PlayerShipSystem.Instance().GetPlayer();
    ship_.Position = Vector2.Zero;
    AddChild(ship_);
    ship_.Connect("OnWeaponSelected", this, "OnPlayerShipWeaponSelected");

    //OS.WindowFullscreen = true;
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
    if (currentWeapon_ != null)
      currentWeapon_.Select(false);
    currentWeapon_ = weapon;
    weapon.Select(true);
  }
}
