using Godot;
using System;

public class StartMenu : Node
{
	private Control mainMenu;
	private Control howToPlay;
	public override void _Ready()
	{
		mainMenu = GetNode<Control>("Main");
		howToPlay = GetNode<Control>("HowtoPlay");
		mainMenu.Visible = true;
		howToPlay.Visible = false;
	}

	private void _on_NewGame_pressed()
	{
		this.GetTree().ChangeScene("res://Tyr's Glory.tscn");
	}

	private void _on_HowToPlay_pressed()
	{
		mainMenu.Visible = false;
		howToPlay.Visible = true;

	}

	private void _on_Back_pressed()
	{
		howToPlay.Visible = false;
		mainMenu.Visible = true;
	}

	private void _on_Quit_pressed()
	{
		this.GetTree().Quit();
	}
}

