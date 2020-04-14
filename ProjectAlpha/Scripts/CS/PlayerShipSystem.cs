using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerShipSystem
{
  PackedScene scene_ = GD.Load<PackedScene>("res://ProjectAlpha/GameObjects/PlayerShip.tscn");
  private PlayerShip ship_;

  private PlayerShipSystem() { }
  private static PlayerShipSystem instance_ = null;
  public static PlayerShipSystem Instance()
  {
    if (instance_ == null)
      instance_ = new PlayerShipSystem();
    return instance_;
  }

  public PlayerShip GetPlayer()
  {
    if (ship_ == null)
      ship_ = scene_.Instance() as PlayerShip;

    return ship_;
  }

}
