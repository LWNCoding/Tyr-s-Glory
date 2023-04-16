using Godot;
using System;
using System.Collections.Generic;

public class Province : Area2D
{
	private Player currentPlayer;
	/*
	Color provinceColor{get;set;}
	*/
	private List<Unit> currentUnits;
	private string label;
	private int newLab;
	private string region;
	private LinkedList<Province> adjacency;
	private bool visited;
	private bool isInArea;
	//private bool isClicked = false;

	private CurrentSelectedProvince singleProvince = CurrentSelectedProvince.getInstance();	
	private Color provinceColor = new Color(1,1,1,1);
	private Label provinceLabel;

	/*SIGNAL CODE*/
	[Signal]
	public delegate void ProvinceClicked(Province pName);

	public void setnewLab(int num)
	{
		newLab = num;
	}

	public int getnewLab()
	{
		return newLab;
	}

	public LinkedList<Province> getAdj()
	{
		return adjacency;
	}

	/// <summary>
	/// Constructor for the Province defined type.
	/// </summary>
	public Province()
	{
		this.label = "";
		this.region = "";
		this.adjacency = new LinkedList<Province>();
		this.currentUnits = new List<Unit>();
		this.visited = false;
		this.currentPlayer = null;
		this.isInArea = false;
	}

	/// <summary>
	/// Constructor for the Province defined type.
	/// </summary>
	/// <param name="label">Parameter for the label of the province.</param>
	/// <param name="region">Parameter for the region this province is grouped under.</param>
	/// <param name="playerId">Parameter for the playerId of the player that currently owns this province.</param>
	public Province(string label,string region){
		this.label = label;
		this.region = region;
		this.adjacency = new LinkedList<Province>();
		this.currentUnits = new List<Unit>();
		this.visited = false;
		this.currentPlayer = null;
		this.isInArea = false;
	}

	public override bool Equals(object? obj) {
		if (obj != null && obj is Province) {
			Province secondProvince = (Province)obj;
			return this.newLab == secondProvince.newLab;
		}
		return false;
	}

	public override int GetHashCode() {
		return this.label.ToLower().GetHashCode();
	}

	public IEnumerable<Province> getAdjacencyEnumerator() {
		return (IEnumerable<Province>)this.adjacency;
	}

	public IEnumerable<Unit> getUnitEnumerator() {
		return (IEnumerable<Unit>)this.currentUnits;
	}

	public int unitNum()
	{
		return this.currentUnits.Count;
	}


	public Province getCurrentSelected(){
		return this.singleProvince.getCurrentSelected();
	}

	/// <summary>
	/// Accessor for the region member.
	/// </summary>
	/// <returns>The string region.</returns>
	public string getRegion()
	{
		return this.region;
	}

	/// <summary>
	/// Accessor for the player member.
	/// </summary>
	/// <returns>The current player at this province.</returns>
	public Player getPlayer()
	{
		return this.currentPlayer;
	}

	/// <summary>
	/// Mutator for the player member.
	/// </summary>
	/// <param name="newPlayerId">The player id for the new player that owns this current province.</param>
	/// <exception cref="ArgumentException">Thrown when the newPlayerId parameter is less than 0.</exception>
	public void setPlayer(int newPlayerId, float[] colorR) {
		if (newPlayerId < 0) {
			throw new ArgumentException("Construction aborted: The player id must be greater than or equal to 0");
		}
		this.currentPlayer = new Player(newPlayerId, colorR);
		setProvinceColor(colorR[0], colorR[1], colorR[2]);
	}

	/// <summary>
	/// Accessor for the label member.
	/// </summary>
	/// <returns>The string label.</returns>
	public string getLabel() {
		return this.label;
	}

	/// <summary>
	/// Accessor for the visited member.
	/// </summary>
	/// <returns>The boolean visited</returns>
	public bool getVisited() {
		return this.visited;
	}

	/// <summary>
	/// Mutator for the visited member.
	/// </summary>
	/// <param name="hasVisited">The new boolean value for the visited member.</param>
	public void setVisited(bool hasVisited) {
		this.visited = hasVisited;
	}

	public int unitNums()
	{
		return currentUnits.Count;
	}

	public bool addEdge(Province neighbor) {
		//cannot have loops and multiple edges i.e. a simple graph
		if ((this.getnewLab().Equals(neighbor.getnewLab()) == false) && (this.adjacency.Contains(neighbor) == false)) {
			this.adjacency.AddFirst(neighbor);
			return true;
		}
		return false;
	}

	public bool removeEdge(Province neighbor) { 
		if(!this.adjacency.Contains(neighbor))
			return false;
		this.adjacency.Remove(neighbor);
		return true;
	}

	public void addUnit(Unit unitName){
		this.currentUnits.Add(unitName);
		this.updateProvinceLabel();
	}

	public bool removeUnit(Unit unitName)
	{
		if (this.currentUnits.Remove(unitName) == false)
		{
			return false;
		}
        this.updateProvinceLabel();
        return true;
	}

	public Unit getUnit(int index){
		if(index >-1 && index < this.currentUnits.Count){
			return this.currentUnits[index];
		}
		return null;
	}

	public bool hasNeighbor() {
		return this.adjacency.Count > 0;
	}

	public int hasNeighbors()
	{
		return this.adjacency.Count;
	}

	public bool isNeighbor(Province otherProvince){
		return this.adjacency.Contains(otherProvince);
	}

	public bool attack(Unit currentPlayerUnit, Unit otherPlayerUnit){
		return otherPlayerUnit.gotAttacked(currentPlayerUnit) <= 0;
	}

	public bool move(Province other, Unit currentUnit){
		bool success = this.removeUnit(currentUnit);
		if(success){
			other.addUnit(currentUnit);
			other.updateProvinceLabel();
			this.updateProvinceLabel();
		}
		return success;
		
	}

	private void moveNumUnits(Province other, int numUnits, Type unitType){
		for(int i = 0; i < numUnits; i++){
			foreach(Unit unitName in this.currentUnits){
				if(unitName.GetType() == unitType){
					this.move(other,unitName);
				}
			}
		}
	}

	public void moveUnitTypes(Province other, int numArtillery, int numCavalry, int numInfantry){
		this.moveNumUnits(other,numArtillery,typeof(Artillery));
		this.moveNumUnits(other,numArtillery,typeof(Cavalry));
		this.moveNumUnits(other,numInfantry,typeof(Infantry));
	}

	public void moveUnitTypes(Province other, List<Unit> unitList){
		foreach(Unit playerUnit in unitList){
			foreach(Unit provinceUnit in this.currentUnits){
				if(playerUnit == provinceUnit){
					this.move(other, provinceUnit);
				}
			}
		}
	}

	public void resetSelected(){
		if(singleProvince.currentSelected != null){
			this.singleProvince.currentSelected.Modulate = new Color(this.singleProvince.currentSelected.getProvinceColor(), 1);
		}
		this.singleProvince.setCurrentSelected(null);
	}

	public override void _Input(InputEvent @event){
		if(@event is InputEventMouseButton clicked){
			if(isInArea && clicked.Pressed && clicked.ButtonIndex == (int)ButtonList.Left){
				//GD.Print("Pressed!");
				this.ProvinceSelected(this);
				EmitSignal("ProvinceClicked", this);
			}
		}
	}
	
	private void MouseIsInArea(){
		this.isInArea = true;
		Modulate = new Color(this.provinceColor, 0.5f);
	}
	
	private void MouseNotInArea(){
		this.isInArea = false;
		if(this.singleProvince.currentSelected == null || this != this.singleProvince.currentSelected)
			Modulate = new Color(this.provinceColor,1);
	}

	private void ProvinceSelected(Province pName){
		if(this.singleProvince.currentSelected == null){
			this.singleProvince.currentSelected = pName;
			Modulate = new Color(this.provinceColor,0.5f);
		}
		else if(this.singleProvince.currentSelected == pName){
			this.singleProvince.currentSelected = null;
			Modulate = new Color(this.provinceColor,1);
		}
	}

	private void updateProvinceLabel(){
		this.provinceLabel.Text = this.unitNums().ToString();
	}

	public void setProvinceColor(float r, float g, float b){
		
		this.provinceColor = new Color(r,g,b,1);
		Modulate = this.provinceColor;
	}

	public Color getProvinceColor(){
		return this.provinceColor;
	}

		
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		/*SIGNAL CODE*/
		this.Connect("ProvinceClicked", this.GetParent(), "_on_Province_input_event");
		//this.Connect("ProvinceClicked", this, "ProvinceSelected");
		this.Connect("mouse_entered", this, "MouseIsInArea");
		this.Connect("mouse_exited", this, "MouseNotInArea");
		this.provinceLabel = GetNode<Sprite>("Sprite").GetNode<Label>("Label");
		this.provinceLabel.Text = "0";
		this.provinceLabel.Modulate = new Color(0,0,0,1);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
// 

//  }
}
