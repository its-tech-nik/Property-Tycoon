public class Property : Card {

	private string group;
	private Player owner;
	private int numberOfHouses;

	public Property(string text, string group) : base(text) {
		this.group = group;
		numberOfHouses = 0;
		owner = null;
	}

	public void BuyIt(Player owner) {
		this.owner = owner;
	}

	public void Build() {
		if(numberOfHouses < 5) {
			numberOfHouses++;
		}
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
