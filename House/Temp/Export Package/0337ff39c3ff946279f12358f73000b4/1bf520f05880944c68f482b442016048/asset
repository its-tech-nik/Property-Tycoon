using System;
using UnityEngine;

public interface PlayerLocated {
	// Raise this event after drawing
	// the shape.
	event EventHandler OnMovement;
}


public class Listeners {
	// References the shape object as an IDrawingObject
	public Listeners(Tile tile) {
		PlayerLocated d = (PlayerLocated)tile;
		d.OnMovement += new EventHandler(HandleCustomEvent);
	}

	void HandleCustomEvent(object sender, EventArgs e) {
		Debug.Log ("I am in a new tile.");
	}
}
