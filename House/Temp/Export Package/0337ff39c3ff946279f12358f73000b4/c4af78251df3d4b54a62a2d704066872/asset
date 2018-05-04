using System;
using System.Collections.Generic;

public interface CardListenerInt {
	void CardReceived(Player p);
}

public class CardListener {
	private List<CardListenerInt> _listeners = new List<CardListenerInt>();

	public void AddListener(CardListenerInt l) {
		_listeners.Add (l);
	}

	public  void removeTileListener( CardListenerInt l ) {
		_listeners.Remove( l );
	}

	public void _fireLocationEvent(Tile t, Player p) {
		foreach(CardListenerInt l in _listeners) {
			l.CardReceived(p);
		}
	}
}
