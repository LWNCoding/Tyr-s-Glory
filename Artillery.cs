using Godot;
using System;

class Artillery : Unit{

	/// <summary>
	/// Default constructor for Artillery
	/// </summary>
	public Artillery(){
		base.health = 100.0f; 
		base.maxMoves = 1;
		base.maxAttacks = 2;
		base.attack = 70.0f;
		base.defense = 20.0f;
		base.range = 2;
	}
  
}
