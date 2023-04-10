using Godot;
using System;
using System.Collections.Generic;

public class UnitSelection : PopupMenu
{
    private List<Unit> selectedUnits = new List<Unit>();
    private List<Unit> currentUnits = new List<Unit>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Connect("id_pressed", this, nameof(_OnUnitSelected), new Godot.Collections.Array() { false });
        Connect("id_pressed", this, nameof(_OnUnitDeselected), new Godot.Collections.Array() { false });

        Button finishedButton = new Button();
        finishedButton.Text = "Finished Selection";
        AddChild(finishedButton);
        finishedButton.Connect("pressed", this, nameof(_OnFinishedSelection));
    }

    public void unitSelectionGUI(Province province)
    {
        Clear();

        foreach (Unit unit in province.getUnitEnumerator())
        {
            AddItem(unit.ToString());
            currentUnits.Add(unit);
        }

        this.Show();
    }

    private void _OnUnitSelected(int id, bool rightMouseButton)
    {
        if (!rightMouseButton)
        {
            Unit selectedUnit = currentUnits[id];
            if (!selectedUnits.Contains(selectedUnit))
            {
                selectedUnits.Add(selectedUnit);
            }
        }
    }

    private void _OnUnitDeselected(int id, bool rightMouseButton)
    {
        if (!rightMouseButton)
        {
            Unit deselectedUnit = currentUnits[id];
            if (selectedUnits.Contains(deselectedUnit))
            {
                selectedUnits.Remove(deselectedUnit);
            }
        }
    }

    private void _OnFinishedSelection()
    {
        this.Hide();
        //Send signal to game with selectedUnits

    }
}
