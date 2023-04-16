using Godot;
using System;

class Infantry : Unit{

	/// <summary>
	/// Default constructor for Infantry
	/// </summary>
	public Infantry(){
		base.health = 300.0f; 
		base.maxMoves = 1;
		base.maxAttacks = 1;
		base.attack = 150.0f;
		base.range = 1;
	}
  
}
