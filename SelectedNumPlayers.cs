public class SelectedNumPlayers{
	private static SelectedNumPlayers singleInstance;
	public int selectedNumPlayers = 2;
	private SelectedNumPlayers(){}
	public static SelectedNumPlayers getInstance(){
		if(singleInstance == null){
			singleInstance = new SelectedNumPlayers();
		}
		return singleInstance;
	}
	public int getSelectedNumPlayers(){
		return this.selectedNumPlayers;
	}
	public void setSelectedNumPlayers(int num){
		this.selectedNumPlayers = num;
	}
}
