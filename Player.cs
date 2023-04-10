using Godot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;

public class Player : Node2D
{

	private int playerId;
	private List<string> provincesOwned;
	private float[] colorArr;
    /*
	private List<Units> unitsOwned;
	*/

    /// <summary>
    /// Constructor for the Player user defined type.
    /// </summary>
    public Player()
	{
		this.playerId = -1;
		this.provincesOwned = new List<string>();
		colorArr = new float[3];
    }

	/// <summary>
	/// Constructor for the Player user defined type.
	/// </summary>
	/// <param name="playerId">The unique identification integer for this Player. Must be a nonnegative number.</param>
	/// <exception cref="ArgumentException">Thrown when the playerId parameter is less than 0.</exception>
	public Player(int playerId, float[] colorARR){
		if(playerId < 0){
			throw new ArgumentException("Construction aborted: The player id must be greater than or equal to 0");
		}
		this.playerId = playerId;
		this.provincesOwned = new List<string>();
		colorArr = colorARR;
	}
    public float[] getColorArr()
    {
        return colorArr;
    }

    /// <summary>
    /// Checks whether two players are equal to each other by comparing their unique id. Overrides the Equals method from the Object class.
    /// </summary>
    /// <param name="obj">The object to compare to.</param>
    /// <returns>True if the object is an instance of Player and the unique id matches. False otherwise.</returns>
    public override bool Equals(object? obj){
		if(obj != null && obj is Player){
			Player secondPlayer = (Player)obj;
			return this.playerId == secondPlayer.playerId;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 1;
	}

	/// <summary>
	/// Accessor method for player id.
	/// </summary>
	/// <returns>The player id.</returns>
	public int getPlayerID(){
		return playerId;
	}

	/// <summary>
	/// Allows for adding a province to the players list of provinces owned.
	/// </summary>
	/// <param Province="label"> The province to be added.</param>
	public void addProvince(string label){
		provincesOwned.Add(label);
	}

	/// <summary>
	/// Allows for removing a province from the players list of provinces owned.
	/// </summary>
	/// <param Province="label">The province to be removed.</param>
	public void removeProvince(string label){
		provincesOwned.Remove(label);
	}

	/// <summary>
	/// Determines whether the player has any provinces owned.
	/// </summary>
	/// <returns>True if the player has at least one province owned. False otherwise.</returns>
	public bool hasProvince(){
		return this.provincesOwned.Count > 0;
	}

	/// <summary>
	/// Gives the number of provinces owned by the player.
	/// </summary>
	/// <returns>An integer representing the number of provinces owned by this player.</returns>
	public int numProvinces(){
		return this.provincesOwned.Count;
	}

	public bool ownsProvince(Province otherProvince){
		return this.provincesOwned.Contains(otherProvince.getLabel());
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
