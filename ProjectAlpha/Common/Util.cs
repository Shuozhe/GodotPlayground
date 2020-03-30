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
}