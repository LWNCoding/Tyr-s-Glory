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
        this.region = "";
        this.adjacency = new LinkedList<Province>();
        this.visited = false;
        this.currentPlayer = null;
    }

	/// <summary>
    /// Constructor for the Province defined type.
    /// </summary>
    /// <param name="label">Parameter for the label of the province.</param>
    /// <param name="region">Parameter for the region this province is grouped under.</param>
    /// <param name="playerId">Parameter for the playerId of the player that currently owns this province.</param>
    public Province(string label,string region,int playerId){
		this.label = label;
        this.region = region;
        this.adjacency = new LinkedList<Province>();
		this.visited = false;
		this.currentPlayer = new Player(playerId);
    }

	/// <summary>
    /// Accessor for the region member.
    /// </summary>
    /// <returns>The string region.</returns>
	public string getRegion()
	{
		return this.region;
	}

	/// <summary>
    /// Accessor for the player member.
    /// </summary>
    /// <returns>The current player at this province.</returns>
    public Player getPlayer()
    {
    	return this.currentPlayer;
    }

	/// <summary>
    /// Mutator for the player member.
    /// </summary>
    /// <param name="newPlayerId">The player id for the new player that owns this current province.</param>
    /// <exception cref="ArgumentException">Thrown when the newPlayerId parameter is less than 0.</exception>
    public void setPlayer(int newPlayerId) {
        if (newPlayerId < 0) {
            throw new ArgumentException("Construction aborted: The player id must be greater than or equal to 0");
        }
        this.currentPlayer = new Player(newPlayerId);
    }

	/// <summary>
    /// Accessor for the label member.
    /// </summary>
    /// <returns>The string label.</returns>
    public string getLabel() {
        return this.label;
    }

	/// <summary>
    /// Accessor for the visited member.
    /// </summary>
    /// <returns>The boolean visited</returns>
    public bool getVisited() {
        return this.visited;
    }

	/// <summary>
    /// Mutator for the visited member.
    /// </summary>
    /// <param name="hasVisited">The new boolean value for the visited member.</param>
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
