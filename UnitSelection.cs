using Godot;
using System;
using System.Collections.Generic;

public class UnitSelection : PopupMenu
{
	private List<Unit> selectedUnits = new List<Unit>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	public List<Unit> unitSelectionGUI(Province province, Node parent){
		Clear();
		List<Unit> currentUnits = new List<Unit>();

		foreach (Unit unit in province.getUnitEnumerator()){
			AddItem(unit.GetName()); // Replace GetName() with the actual method that returns the unit's name
			currentUnits.Add(unit);
		}

		Connect("id_pressed", this, nameof(_OnUnitSelected), new Godot.Collections.Array() { false });
		Connect("id_pressed", this, nameof(_OnUnitDeselected), new Godot.Collections.Array() { false });


		Button finishedButton = new Button();
		finishedButton.Text = "Finished Selection";
		AddChild(finishedButton);
		finishedButton.Connect("pressed", this, nameof(_OnFinishedSelection));

		parent.AddChild(this);
		Rect2 parentRect = parent.GetGlobalRect();
		Rect2 popupRect = new Rect2(parentRect.Position + GetGlobalMousePosition(), new Vector2(0, 0));
		ShowPopup(popupRect);

		return selectedUnits;
	}
	
	private void _OnUnitSelected(int id, bool rightMouseButton){
		if (!rightMouseButton){
			Unit selectedUnit = currentUnits[id];
			if (!selectedUnits.Contains(selectedUnit)){
				selectedUnits.Add(selectedUnit);
			}
		}
	}

	private void _OnUnitDeselected(int id, bool rightMouseButton){
		if (!rightMouseButton){
			Unit deselectedUnit = currentUnits[id];
			if (selectedUnits.Contains(deselectedUnit)){
				selectedUnits.Remove(deselectedUnit);
			}
		}
	}


	private void _OnFinishedSelection(){
		GetParent().Call("onUnitsSelected", selectedUnits);
		Hide();
	}
}
