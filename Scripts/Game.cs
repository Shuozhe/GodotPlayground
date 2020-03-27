using Godot;
using System;

public class Game : Node2D
{
  // Declare member variables here. Examples:
  // private int a = 2;
  // private string b = "text";

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
	//Connect("resized", this, "call_wrap_around");
  }


  public void CallWrapAround()
  {
	GetTree().CallGroup("WrapAround", "recalculate_wrap_area");
  }


  private void _on_Game_item_rect_changed()
  {
	CallWrapAround();
  }


}

