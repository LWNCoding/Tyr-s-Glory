using Godot;
using System;
using System.Collections.Generic;

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
        GD.Print(currentPlayer);
        GD.Print(unclaimed);
        one.setPlayer(currentPlayer);
        one.addUnit(new Infantry());
        unclaimed--;
        if (unclaimed == 0)
        {
            stage += 1;
            currentPlayer = 0;
            startTurn();
        }
		 else if (currentPlayer == playerNum)
        {
            currentPlayer = 0;
        }
        else
        {
            currentPlayer++;
        }
        return 0;
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
                }
                else if (selected != null)
                {
                    if (selected.getPlayer().getPlayerID() == currentPlayer && one.getPlayer().getPlayerID() == currentPlayer)
                    {
                        if (one.isNeighbor(selected))
                        {

                        }
                    }
                    else if (selected.getPlayer().getPlayerID() == currentPlayer && one.getPlayer().getPlayerID() != currentPlayer)
                    {

                    }
                    selected = null;
                }
                addAmount--;
                break;
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
            PARR.Add(new Player(i));
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
        top.updateRegionControl();
    }
    public void createBoard()
    {
        for (int i = 1; i < 75; i++)
        {
            Province s = (Province)GetNode<Province>("Province" + i);
            top.addProv("" + i, s);
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        PARR = new List<Player>();
        top = new Board();
        createBoard();
        setup(6);
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
