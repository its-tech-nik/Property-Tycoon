/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
 
 
 package monopoly;



import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 *
 * @author nikandrosmavroudakis
 */
public class CardListener {
    private List _listeners = new ArrayList();
    
    public synchronized void addCardListener( CardListenerInt l ) {
        _listeners.add( l );
    }
    
    public synchronized void removeCardListener( CardListenerInt l ) {
        _listeners.remove( l );
    }
    
    public synchronized void _fireCardEvent(Player p) {
        Iterator listeners = _listeners.iterator();
        
        while( listeners.hasNext() ) {
            ( (CardListenerInt) listeners.next() ).cardReceived(p);
        }
    }
}
