using System;
using System.Collections.Generic;
using UnityEngine;

public class TileListener {
	public static void ShowTiles(TileArgs e) {
		Debug.Log("showTile()" + e._tile.GetName() + "\t" + e._player.getName());
		//Tile.ShowTile (e);
	}
}


