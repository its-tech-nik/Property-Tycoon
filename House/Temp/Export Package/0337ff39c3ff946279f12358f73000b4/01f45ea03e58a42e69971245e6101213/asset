using System.Collections;
using System;
using UnityEngine;

public delegate void TileAddDelegate(TileArgs e);

public class TileArgs : EventArgs {
	public Player _player;
	public Tile _tile;

	public TileArgs(Tile t, Player p) {
		this._player = p;
		this._tile = t;
	}
}

public delegate void OnTop(TileArgs e);

public class Tile {

	public event TileAddDelegate _tileEventHandler;
	private int price;
	private Property property;
	private string name;

	public Tile(string name, string group, int price) :base() {

		//Debug.Log ("Tile(string name, string group, int price)");
		this.price = price;
		this.name = name;
		property = new Property (name, group);
	}

	public Tile(string name) :base() {
		//Debug.Log ("Tile(string " + name + ")");
		this.name = name;
		property = null;
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

		if(p != null) {
			TileArgs e = new TileArgs (this, p);
			OnPlayerLocation (e);
		}

		// fire the event
	}

	public void OnPlayerLocation(TileArgs e) {
		if (_tileEventHandler != null) {
			_tileEventHandler (e);
		}
	}

	public Property GetProperty() {
		return property;
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
