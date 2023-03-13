using Godot;
using System;
using System.Collections.Generic;

public class game : Node
{
    private int currentPlayer = 0;
    private int playerNum = 6;

    private List<Player> PARR;
    private Board top;

    public int addOne(int PLID)
    {
        return 0;
    }

    public int distributeMen(int PLID)
    {
        return 0;
    }

    public int move(int PLID)
    {
        return 0;
    }
    public int removePlayer(int PLID)
    {
        return 0;
    }
    public void setup(int PNUM)
    {
        int unclaimed = 74;
        int x = 0;
        playerNum = PNUM;
        for (int i = 0; i < PNUM; i++)
        {
            PARR.Add(new Player());
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
        setup(6);
        mainLoop();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
