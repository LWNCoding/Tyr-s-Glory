using Godot;
using System;

class Infantry : Unit{

	/// <summary>
	/// Default constructor for Infantry
	/// </summary>
	public Infantry(){
		base.health = 0.0f; 
		base.max_moves = 0;
		base.max_attacks = 0;
		base.attack = 0.0f;
		base.defense = 0.0f;
		base.range = 0;
	}
  
}
