using Godot;
using System;
using System.Collections.Generic;

public class Province : Node2D
{
    private Player currentPlayer;
    /*
	Color provinceColor{get;set;}
	private List<Units> currentUnits;
	*/
    private string label;
    private string region;
    private LinkedList<Province> adjacency;
	private bool visited;


    /// <summary>
    /// Constructor for the Province defined type.
    /// </summary>
    public Province()
    {
        this.label = "";
        this.adjacency = new LinkedList<Province>();
        this.visited = false;
        this.currentPlayer = null;
    }

    /// <summary>
    /// Constructor for the Province defined type.
    /// </summary>
    /// <param name="label">The unique identifier which specifies the name of a province.</param>
    /// <exception cref="ArgumentException">Thrown when the playerId parameter is less than 0.</exception>
    public Province(string label,int playerId){
		this.label = label;
		this.adjacency = new LinkedList<Province>();
		this.visited = false;
		this.currentPlayer = null;
    }

	public string getRegion()
	{
		return this.region;
	}

    public void setRegion(string newRegion) {
        this.region = newRegion;
    }

    public Player getPlayer()
    {
    	return this.currentPlayer;
    }

    public void setPlayer(string newPlayer) {
    	this.currentPlayer = newPlayer;
    }

    public string getLabel() {
        return this.label;
    }

    public bool getVisited() {
        return this.visited;
    }

    public void setVisited(bool hasVisited) {
        this.visited = hasVisited;
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
