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
	private string label{ get { return label; } set { } }
	private string region { get; set; }
	private LinkedList<Province> adjacency;
	private bool visited;


    /// <summary>
    /// Constructor for the Province defined type.
    /// </summary>
    public Province()
    {
        this.label = "";
        this.adjacency = new LinkedList<Province>();
        this.visited = false;
        this.currentPlayer = null;
    }

    /// <summary>
    /// Constructor for the Province defined type.
    /// </summary>
    /// <param name="label">The unique identifier which specifies the name of a province.</param>
    /// <exception cref="ArgumentException">Thrown when the playerId parameter is less than 0.</exception>
    public Province(string label,int playerId){
		this.label = label;
		this.adjacency = new LinkedList<Province>();
		this.visited = false;
		this.currentPlayer = null;
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