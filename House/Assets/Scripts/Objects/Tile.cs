using System.Collections;
public class Tile : TileListener {
	private int price;
	private Property property;

	public Tile(string name, string group, int price) {
		this.price = price;
		property = new Property (name, group);
	}

	/**
     * Returns whether this property is sellable or not.
     * 
     * @return Whether this property is sellable or not.
     */
	public bool IsSellable() {
		// checks if it is an item that is not on sale, like the taxes and other staff - further discussion
		if(property != null && property.GetOwner() != null) {
			/*// checks if it is actually owned by someone
            if(property != null || property.getOwner() != null) {
                return true;
            }*/
			return false;
		}

		return true;
	}

	public void LocatePlayer(Player p) {

		// do some staff regarding the player when it lands on a tile on the board.

		_fireLocationEvent(this, p);
	}

	public void Build() {
		property.Build();
	}


	public int GetPrice() {
		return price;
	}

	public string GetName() {
		return property.GetName();
	}

	public string GetGroup() {
		return property.GetGroup();
	}
}
