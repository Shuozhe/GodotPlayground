using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GamePad
{
  public static bool IsConnected()
  {
    return Input.GetConnectedJoypads().Count > 0;
  }
}
