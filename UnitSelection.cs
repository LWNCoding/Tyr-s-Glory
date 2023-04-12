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
	}

	private void _on_Button_pressed()
	{
	// Replace with function body.
		this.Hide();
	}
}
