using Godot;
using System;

public class StartMenu : Node
{
	private Control mainMenu;
	private Control howToPlay;
	private Control start;
	private SelectedNumPlayers numPlayers = SelectedNumPlayers.getInstance();

	public override void _Ready()
	{
		mainMenu = GetNode<Control>("Main");
		howToPlay = GetNode<Control>("HowtoPlay");
		start = GetNode<Control>("StartGame");
		mainMenu.Visible = true;
		start.Visible = false;
		howToPlay.Visible = false;
	}

	private void _on_NewGame_pressed()
	{
		mainMenu.Visible = false;
		start.Visible = true;
	}

	

	private void _on_Start_pressed()
	{
		this.GetTree().ChangeScene("res://Tyr's Glory.tscn");
	}


	private void _on_StartBack_pressed()
	{
		start.Visible = false;
		mainMenu.Visible = true;
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

	private void _on_2p_pressed()
	{
		numPlayers.setSelectedNumPlayers(2);
	}

	private void _on_3p_pressed()
	{
		numPlayers.setSelectedNumPlayers(3);
	}


	private void _on_4p_pressed()
	{
		numPlayers.setSelectedNumPlayers(4);
	}


	private void _on_5p_pressed()
	{
		numPlayers.setSelectedNumPlayers(5);
	}

	private void _on_6p_pressed()
	{
		numPlayers.setSelectedNumPlayers(6);
	}
}

