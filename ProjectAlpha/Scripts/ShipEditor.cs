using Godot;
using System;

public class ShipEditor : Node
{
  PlayerShip ship_;

  WeaponSlot currentWeapon_ = null;

  Camera2D camera_;
  Vector2 zoomStep_ = new Vector2(0.1f, 0.1f);

  public override void _Ready()
  {
    ship_ = PlayerShipSystem.Instance().GetPlayer();
    ship_.Position = Vector2.Zero;
    AddChild(ship_);
    ship_.Connect("OnWeaponSelected", this, "OnPlayerShipWeaponSelected");

    camera_ = GetNode<Camera2D>("Camera2D");

    //OS.WindowFullscreen = true;
  }

  public override void _Input(InputEvent ev)
  {
    if (ev.IsActionReleased(Actions.BACK))
      GetTree().ChangeScene(Dialogs.MainMenu);

    if (ev.IsActionReleased(Actions.ZOOM_DOWN))
      camera_.Zoom += zoomStep_;
    if (ev.IsActionReleased(Actions.ZOOM_UP))
    {
      camera_.Zoom -= zoomStep_;
      if (camera_.Zoom < zoomStep_)
        camera_.Zoom = zoomStep_;
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
