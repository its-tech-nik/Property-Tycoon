/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
 
 
 package monopoly;



/**
 *
 * @author nikandrosmavroudakis
 */
public class Card extends CardListener {
    
    private String name;
    
    public Card(String name) {
        this.name = name;
    }
    
    public String getName() {
        return name;
    }
    
    public void useCard(Player p) {
        
    }
    
}
