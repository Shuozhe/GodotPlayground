using Godot;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Game : Node2D
{

  readonly PackedScene playerScene_ = GD.Load<PackedScene>("res://Objects/Player.tscn");

  enum GameState
  {
    PLAYING,
    GAME_OVER,
  }
  private GameState state_;

  public override void _Ready()
  {
    Connect("resized", this, "CallWrapAround");
    state_ = GameState.PLAYING;
  }

  public override void _UnhandledInput(InputEvent ev)
  {
    if (state_ == GameState.GAME_OVER && ev.IsActionReleased("restart_game"))
      RestartGame();
  }


  public void CallWrapAround()
  {
    GetTree().CallGroup("resized", "recalculate_wrap_area");
  }


  private void _on_Game_item_rect_changed()
  {
    GD.Print(GetViewport());
    CallWrapAround();
  }

  private void _on_Player_OnPlayerDestroyed()
  {
    var music = GetNode<AudioStreamPlayer>("MusicPlayer");
    music.Stop();
    music.Stream = GD.Load<AudioStream>("res://assets/audio/music/sawsquarenoise_-_06_-_Towel_Defence_Jingle_Loose.ogg");
    music.Stream.Set("loop", false);
    music.Stream.Set("volume_db", -5);

    GetNode<Timer>("AsteroidSpawner/SpawnTimer").Stop();
    foreach (Node2D asteroid in GetTree().GetNodesInGroup("asteroids"))
      asteroid.GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D").Stop();

    GetNode<Timer>("GameOverTimer").Start();
  }

  private void _on_GameoverTimer_timeout()
  {
    GetNode<AudioStreamPlayer>("MusicPlayer").Play(0);
    GetNode<Label>("GameOverLabel").Visible = true;
    state_ = GameState.GAME_OVER;
  }

  private void RestartGame()
  {
    GetNode<Label>("GameOverLabel").Visible = false;
    var music = GetNode<AudioStreamPlayer>("MusicPlayer");
    music.Stop();
    music.Stream = GD.Load<AudioStream>("res://assets/audio/music/sawsquarenoise_-_03_-_Towel_Defence_Ingame.ogg");
    music.Stream.Set("loop", true);
    music.Stream.Set("volume_db", -10);
    music.Play(0);

    var spawner = GetNode<AsteroidSpawner>("AsteroidSpawner");
    spawner.Restart();
    spawner.GetNode<Timer>("SpawnTimer").Start();

    GetNode<Label>("/root/Game/GUI/MarginContainer/HBoxContainer/VBoxContainer/Score").Text = "0";

    RespawnPlayer();
    state_ = GameState.PLAYING;
  }

  private void RespawnPlayer()
  {
    Debug.Assert(playerScene_ != null);
    var player = playerScene_.Instance() as Player;
    player.Position = new Vector2(626, 600);
    AddChild(player);
  }
}
