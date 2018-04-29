using System.Collections;
public class Tile {
	private string name;
	private int price;
	private string group;

	public Tile(string name, string group, int price) {
		this.name = name;
		this.price = price;
		this.group = group;
	}

	public string GetName() {
		return name;
	}

	public string GetGroup() {
		return group;
	}

	public int GetPrice() {
		return price;
	}
}
