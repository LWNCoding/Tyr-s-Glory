using Godot;
using System;

class Cavalry : Unit{

	/// <summary>
	/// Default constructor for Cavalry
	/// </summary>
	public Cavalry(){
		base.health = 200.0f; 
		base.maxMoves = 2;
		base.maxAttacks = 2;
		base.attack = 100.0f;
		base.defense = 10.0f;
		base.range = 1;
	}
  
}
