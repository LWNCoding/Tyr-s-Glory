using Godot;
using System;

public abstract class Unit : Node2D
	protected float health;

	private int num_moved;
	protected int max_moves;

	private int num_attacked;
	protected int max_attacks;

	protected float attack; 

	protected float defense;

	protected int range;

	/// <summary>
	/// Returns true if attack brings health below 0
	/// Can be used like: if(!attacked(example)) to simulate an attack while also checking if the Unit perished
	/// </summary>
	public bool got_attacked(float damage){
		float total = damage - this.defense;

		if(total > 0){
			this.health -= total;
		}

		return health > 0 ? true : false;
	}
	
	/// <summary>
	/// Returns true if successfully moved, false if not
	/// Can be used like: if(moved()) to simulate moving while also checking if its possible to move still
	/// </summary>
	public bool moved(){
		if(num_moved == max_moves){
			return false;
		}
		num_moved++;
		return true;
	}

	/// <summary>
	/// Returns true if successfully attacked, false if not
	/// Can be used like: if(attacked()) to simulate moving while also checking if its possible to attack still
	/// </summary>
	public bool attacked(){
		if(num_attacked == max_attacks){
			return false;
		}
		num_attacked++;
		return true;
	}
	
	/// </summary>
	/// Resests counters at the end of the turn
	/// </summary>
	public void reset_turn(){
		this.num_attacked = 0;
		this.num_moved = 0;
	}
}

