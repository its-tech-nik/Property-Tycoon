/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
 
 package monopoly;

 


import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class TileListener {
    
    private List _listeners = new ArrayList();
    
    public synchronized void addTileListener( TileListenerInt l ) {
        _listeners.add( l );
    }
    
    public synchronized void removeTileListener( TileListenerInt l ) {
        _listeners.remove( l );
    }
    
    public synchronized void _fireLocationEvent(Tile t, Player p) {
        Iterator listeners = _listeners.iterator();
        
        while( listeners.hasNext() ) {
            ( (TileListenerInt) listeners.next() ).playerReceived(t, p);
        }
    }
}