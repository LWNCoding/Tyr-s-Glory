using Godot;
using System;
using System.ComponentModel;

public abstract class Unit : Node2D{
	protected float health;
	public float getHealth(){
		return this.health;
	}

	private int numMoved;
	public int getNumMoved(){
		return this.numMoved;
	}
	
	protected int maxMoves;

	private int numAttacked;
	public int getNumAttacked(){
		return this.numAttacked;
	}
	
	protected int maxAttacks;

	protected float attack; 
	public float getAttack(){
		return this.attack;
	}

	protected float defense;
	public float getDefense(){
		return this.defense;
	}

	protected int range;
	public int getRange(){
		return this.range;
	}

	/// <summary>
	/// Returns true if attack brings health below 0
	/// Can be used like: if(!gotAttacked(example)) to simulate an attack while also checking if the Unit perished
	/// </summary>
	public float gotAttacked(Unit attacker) {
		float total = attacker.attack;
		float variation = 0.0f;

		Random random = new Random();
		int choice = random.Next(2);

		if (attacker.GetType() == typeof(Artillery))
		{
			variation = (float) random.NextDouble() * 0.25f;
		}
		if (attacker.GetType() == typeof(Cavalry))
		{
			variation = (float) random.NextDouble() * 0.125f;
		}
		if (attacker.GetType() == typeof(Infantry))
		{
			variation = (float) random.NextDouble() * 0.05f;
		}

		/*switch(attacker.GetType()){
			variation = (float) random.NextDouble() * 0.25f;
		}
		if (attacker.GetType() == typeof(Cavalry))
		{
			variation = (float) random.NextDouble() * 125f;
		}
		if (attacker.GetType() == typeof(Infantry))
		{
			variation = (float) random.NextDouble() * 0.05f;
		}

		/*switch(attacker.GetType()){
			case( Artillery):
				variation = random.NextDouble() * 0.25f;
				break;
			case(Cavalry):
				variation = random.NextDouble() * 0.125f;
				break;
			case(Infantry):
				variation = random.NextDouble() * 0.05f;
				break;
		}*/

		if (choice == 1){
			total += variation * total;
		}
		else{
			total -= variation * total;
		}
		
		total -= defense;

		if(total > 0){
			this.health -= total;
		}

		return this.health;
	}
	
	/// <summary>
	/// Returns true if successfully moved, false if not
	/// Can be used like: if(moved()) to simulate moving while also checking if its possible to move still
	/// </summary>
	public bool moved(){
		if(this.numMoved == this.maxMoves){
			return false;
		}
		this.numMoved++;
		return true;
	}
	
	public override String ToString()
	{
		if (this.GetType() == typeof(Artillery))
		{
			return "Artillery";
		}
		else if (this.GetType() == typeof(Infantry))
		{
			return "Infantry";
		}
		else
		{
			return "Cavalry";
		}
	}

	/// <summary>
	/// Check if Unit can move
	/// </summary>
	public bool canMove(){
		return this.numMoved == this.maxMoves;
	}
	

	/// <summary>
	/// Returns true if successfully attacked, false if not
	/// Can be used like: if(attacked()) to simulate moving while also checking if its possible to attack still
	/// </summary>
	public bool attacked(){
		if(this.numAttacked == this.maxAttacks){
			return false;
		}
		this.numAttacked++;
		return true;
	}
	
	/// </summary>
	/// Resests counters at the end of the turn
	/// </summary>
	public void resetTurn(){
		this.numAttacked = 0;
		this.numMoved = 0;
	}
}

