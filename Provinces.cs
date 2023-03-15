using Godot;
using System;
using System.Collections.Generic;

public class Province : Node2D
{
	// Declare member variables here.
	private Player currentPlayer{get;set;}
	/*
	Color provinceColor{get;set;}
	private List<Units> currentUnits;
	*/
	private string label{get;}
	private LinkedList<Province> adjacency;
	private bool visited;

	public Province(string label,int playerId){
		this.label = label;
		this.adjacency = new LinkedList<Province>();
		this.visited = false;
		this.currentPlayer = new Player(playerId);
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
