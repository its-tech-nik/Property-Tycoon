using System;
using System.Collections.Generic;

public interface TileListenerInt {
	void PlayerReceived(Tile t, Player p);
}

public class TileListener {
	private List<TileListenerInt> _listeners = new List<TileListenerInt>();

	public void AddListener(TileListenerInt l) {
		_listeners.Add (l);
	}

	public  void removeTileListener( TileListenerInt l ) {
		_listeners.Remove( l );
	}

	public void _fireLocationEvent(Tile t, Player p) {
		foreach(TileListenerInt l in _listeners) {
			l.PlayerReceived(t, p);
		}
	}
}


