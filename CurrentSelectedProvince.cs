public class CurrentSelectedProvince{
	private static CurrentSelectedProvince singleInstance;
	public Province currentSelected = null;
	private CurrentSelectedProvince(){}
	public static CurrentSelectedProvince getInstance(){
		if(singleInstance == null){
			singleInstance = new CurrentSelectedProvince();
		}
		return singleInstance;
	}
	public Province getCurrentSelected(){
		return this.currentSelected;
	}
	public void setCurrentSelected(Province pName){
		this.currentSelected = pName;
	}
}
