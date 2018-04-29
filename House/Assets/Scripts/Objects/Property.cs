public class Property {

	private string group;
	private Player owner;
	private int numberOfHouses;

	public Property(string text, string group) {
		//super (text);
		this.group = group;
		numberOfHouses = 0;
		owner = null;
	}

	public string GetGroup() {
		return group;
	}

	public Player GetOwner() {
		return owner;
	}

	public int GetNumberOfHouses() {
		return numberOfHouses;
	}
}
