using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Util
{
  public static string GetScenePath(string name)
  {
    return $"res://ProjectAlpha/Scenes/{name}.tscn";
  }
}

class Dialogs
{
  readonly static public string MainMenu = Util.GetScenePath("MainMenu");
  readonly static public string GameMain = Util.GetScenePath("GameMain");
  readonly static public string ShipEditor = Util.GetScenePath("ShipEditor");
}

class Actions
{
  readonly static public string BACK = "back";
  readonly static public string FIRE = "fire";
  readonly static public string GAME_LEFT = "game_left";
  readonly static public string GAME_RIGHT = "game_right";
  readonly static public string GAME_UP = "game_up";
  readonly static public string GAME_BOTTOM = "game_down";
  readonly static public string GAME_SELECT = "game_select";

  readonly static public string ZOOM_UP = "zoom_up";
  readonly static public string ZOOM_DOWN = "zoom_down";
}