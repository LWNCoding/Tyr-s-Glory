using Godot;
using System;
using System.Collections.Generic;

public class UnitSelection : PopupMenu
{
	private List<Unit> currentUnits = new List<Unit>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//this.Show();
		
		this.Connect("id_pressed", this.GetParent(), "_OnUnitSelected");
		this.Connect("id_pressed", this.GetParent(), "_OnUnitDeselected");

		Button finishedButton = new Button();
		finishedButton.Text = "Finished Selection";
		AddChild(finishedButton);
		finishedButton.Connect("pressed", this, nameof(_OnFinishedSelection));
	}

	private void _OnFinishedSelection()
	{
		this.Hide();
		//Send signal to game with selectedUnits

	}
}
