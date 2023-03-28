using Godot;
using System;
using System.Collections.Generic;

public class Game : Node
{
	private int currentPlayer = 0;
	private int playerNum;
	private SignalAttribute SIGNA;

	private List<Player> PARR;
	private Board top;

	private int _on_Province_input_event(Province one)
	{
		return 0;
	}


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

	public int addOne(int PLID)
	{
		return 0;
	}

	private async void signalReceived() { 
		await ToSignal(this, "AddOnClick");
	}

	public int distributeMen(int PLID)
	{
		int addAmount = countScore(PLID);
		while (addAmount > 0)
		{
			signalReceived();
			addAmount--;
		}
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
		int unclaimed = 74;
		int x = 0;
		playerNum = PNUM;
		for (int i = 0; i < PNUM; i++)
		{
			PARR.Add(new Player(i));
		}

		while (unclaimed > 0)
		{
			addOne(x);
			if (x < PNUM - 1)
			{
				x++;
			}
			else
			{
				x = 0;
			}
			unclaimed--;
		}

		top.updateRegionControl();
	}

	public void mainLoop()
	{
		while (playerNum > 1)
		{
			distributeMen(currentPlayer);
			move(currentPlayer);
		}

	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public void main()
	{
		setup(6);
		mainLoop();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
