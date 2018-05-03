using System;

public interface TileListenerInt {
	void PlayerReceived(Tile t, Player p);
}

public delegate void PlayerReceived(Tile t, Player p);
