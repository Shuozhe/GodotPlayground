using Godot;
using System;

public class MainMenu : Control
{
  public override void _Ready()
  {

  }

  private void OnGameStart()
  {
	GetTree().ChangeScene(Dialogs.GameMain);
  }

  private void OnEditorStart()
  {
	GetTree().ChangeScene(Dialogs.ShipEditor);
  }

  private void OnExit()
  {
	GetTree().Quit();
  }

  public override void _Notification(int what)
  {
	if (what == MainLoop.NotificationWmQuitRequest)
	  GetTree().Quit(); // default behavior
  }
}
