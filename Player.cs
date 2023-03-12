using Godot;
using System;
using System.Collections.Generic;

public class Player : Node2D
{
	// Declare member variables here.
	private int player_id{get;}
	private List<Provinces> provincesOwned{get;set;}
	/*
	private List<Units> unitsOwned{get;set;}
	*/
	private int numProvincesOwned{get;}
	private int numUnitsOwned{get;}
	

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
