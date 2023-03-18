using Godot;
using System;
using System.Collections.Generic;

public class Board : Node2D
{
    private Dictionary<string, Province> provDict;
    private int[] regionControl;
    /// <summary>
    /// Constructor for the Board defined type.
    /// </summary>
    public Board()
    {
        provDict = new Dictionary<string, Province>();
        regionControl = new int[] { -1, -1, -1, -1, -1, -1, -1}; //NA=0,SA=1,EU=2,AF=3,AS=4,ME=5,OC=6
    }

    public Dictionary<string, Province> getProvDict()
    {
        return provDict;
    }

    public Province getProvince(string label)
    {
        return provDict[label];
    }

    public int[] getRegionControl()
    {
        return regionControl;
    }

    public void updateRegionControl()
    {

    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
