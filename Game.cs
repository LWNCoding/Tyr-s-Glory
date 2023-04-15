using Godot;
using System;
using System.Collections.Generic;
using System.Security.Policy;

public class Game : Node
{
	private int currentPlayer = 0;
	private int addAmount = 0;
	private int stage = 0;
	int unclaimed = 75;
	private int playerNum;

	private List<Player> PARR;
	private Board top;
	private Province selected = null;
	private List<Unit> selectedUnits = new List<Unit>();
	private int unitChoice = 0;

	private int countScore(int PLID)
	{
		int[] reg = top.getRegionControl();
		int addAmount = 3;
		for (int i = 0; i < 7; i++)
		{
			if (reg[i] == PLID)
			{
				switch (i)
				{
					case 0: //NA
						addAmount += 5;
						break;
					case 1: //SA
						addAmount += 2;
						break;
					case 2://EU
						addAmount += 5;
						break;
					case 3://AF
						addAmount += 3;
						break;
					case 4://AS
						addAmount += 7;
						break;
					case 5://ME
						addAmount += 6;
						break;
					case 6://OC
						addAmount += 2;
						break;
				}
			}
		}
		return addAmount;
	}

	public int addOne(Province one)
	{
		if (one.getPlayer() != null)
		{
			return -1;
		}
		one.setPlayer(currentPlayer, PARR[currentPlayer].getColorArr());
		one.addUnit(new Infantry());
		unclaimed--;
		if (unclaimed == 0)
		{
			GD.Print("END OF ADDING PHASE");
			stage += 1;
			currentPlayer = 0;
			startTurn();
		}
		currentPlayer++;
		if (currentPlayer == playerNum)
		{
			currentPlayer = 0;
		}
		one.resetSelected();
		return 0;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			if (OS.GetScancodeString(keyEvent.PhysicalScancode) == "Tab" && stage == 1)
			{
                endTurn();
			}
		}
	}

	public int _on_Province_input_event(Province one)
	{
		switch (stage)
		{
			case 0:
				addOne(one);
				break;
			case 1:
				if (addAmount > 0 && one.getPlayer().getPlayerID() == currentPlayer)
				{
					addAmount--;
					one.addUnit(new Infantry());
				}
				else if (selected == null && one.getPlayer().getPlayerID() == currentPlayer)
				{
					selected = one;
					PopupMenu p = GetNode<PopupMenu>("UnitSelection");
					this.unitSelectionGUI(p,selected);
					p.Show();
				}
				else if (selected != null)
				{
					if (one == selected)
					{
                        selected = null;
                    }
					else if (selected.getPlayer().getPlayerID() == currentPlayer && one.getPlayer().getPlayerID() == currentPlayer)
					{
                        if (one.isNeighbor(selected))
						{
                            foreach (Unit i in selectedUnits)
							{
                                if (i.moved())
								{
                                    selected.move(one, i);
                                }
							}
							selectedUnits.Clear();
                            selected = null;
                        }
					}
					else if (selected.getPlayer().getPlayerID() == currentPlayer && one.getPlayer().getPlayerID() != currentPlayer)
					{
						foreach (Unit i in selectedUnits)
						{
							if (top.canAttack(i, selected, one))
							{
								if (one.getUnit(0).gotAttacked(i) == true)
								{
									one.removeUnit(i);
                                }
                            }
                        }
                        selectedUnits.Clear();
                        selected = null;
                    }
					
				}
				break;
		}
		return 0;
	}

	public int distributeMen(int PLID)
	{
		addAmount = countScore(PLID);
		return 0;
	}

	public int move(int PLID)
	{
		top.updateRegionControl(); //this should be at the end of the full function
		return 0;
	}

	public bool removePlayer(Player Play)
	{
		return PARR.Remove(Play);
	}

	public void setup(int PNUM)
	{
		playerNum = PNUM;
		for (int i = 0; i < PNUM; i++)
		{
			float[] colorR = { 0, 0, 0 };
			switch (i)
			{
				case 0:
					colorR[0] = 1;
					break;
				case 1:
					colorR[1] = 1;
					break;
				case 2:
					colorR[2] = 1;
					break;
				case 3:
					colorR[0] = 1;
					colorR[1] = 1;
					break;
				case 4:
					colorR[0] = 1;
					colorR[2] = 1;
					break;
				case 5:
					colorR[1] = 1;
					colorR[2] = 1;
					break;
				case 6:
					colorR[0] = 0.5f;
					colorR[1] = 1;
					colorR[2] = 0.5f;
					break;
			}
			PARR.Add(new Player(i, colorR));
		}

		int prevPlayer = currentPlayer;
	}

	public void startTurn()
	{
		distributeMen(currentPlayer);
		//move(currentPlayer);
	}

	public void endTurn()
	{
		if (currentPlayer == playerNum)
		{
			currentPlayer = 0;
		}
		else
		{
			currentPlayer++;
		}
        selected = null;
        selectedUnits.Clear();
        top.getProvince(1).resetSelected();
		top.updateRegionControl();
	}
	public void createBoard()
	{
        for (int i = 1; i <= 75; i++)
		{
			Province s = (Province)GetNode<Province>("Province" + i);
            s.setnewLab(i);
            top.addProv(i, s);
		}
		top.connect();
	}

	public void unitSelectionGUI(PopupMenu p, Province province)
	{	
		p.Clear();
		foreach (Unit unit in province.getUnitEnumerator())
		{
			p.AddCheckItem(unit.ToString());
		}
	}

	public void _OnUnitSelected(int id)
	{
        PopupMenu p = GetNode<PopupMenu>("UnitSelection");
        if (!p.IsItemChecked(id))
        {
            Unit selectedUnit = this.selected.getUnit(id);
            if (selectedUnit != null && !this.selectedUnits.Contains(selectedUnit))
            {
                selectedUnits.Add(selectedUnit);
                p.SetItemChecked(id, true);
            }
        }
        else
        {
            Unit deselectedUnit = this.selected.getUnit(id);
            if (deselectedUnit != null && this.selectedUnits.Contains(deselectedUnit))
            {
                selectedUnits.Remove(deselectedUnit);
                p.SetItemChecked(id, false);
            }
        }
    }

	private void _on_DistributeSelection_id_pressed(int id)
	{
		this.unitChoice = id;
			
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PARR = new List<Player>();
		top = new Board();
		createBoard();
		setup(2);
	}

	public void main()
	{

	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}



