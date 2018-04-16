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
public class Property extends Card {
    
    private Group group;
    private Player owner;
    private int numberOfHouses;
    
    public Property(String text, Group group) {
        super(text);
        this.group = group;
        numberOfHouses = 0;
        owner = null;
    }
    
    public void build() {
        if(numberOfHouses < 5) {
            numberOfHouses++;
        }
    }
    
    public void buyIt(Player owner) {
        this.owner = owner;
    }
    
    public Player getOwner() {
        return owner;
    }
    
    public int getRent() {
        // "SELECT rent" + numberOfHouses + " FROM properties WHERE name=text"
        
        return 200;
    }
}
