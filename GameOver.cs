using Godot;
using System;

public class GameOver : Node
{
	public override void _Ready()
	{
		
	}

	private void _on_Quit_pressed()
	{
		this.GetTree().Quit();
	}

	private void _on_Replay_pressed()
	{
		this.GetTree().ChangeScene("res://StartMenu.tscn");
	}

}

