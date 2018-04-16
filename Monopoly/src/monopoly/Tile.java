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
public class Tile extends TileListener {
    
    private String name;
    private int price;
    private Property property;
    
    public Tile(String name) {
        this.name = name;
        this.price = 0;
        property = null;
    }
    
    public Tile(Property property, int price) {
        this.name = property.getName();
        this.price = price;
        this.property = property;
    }
    
    /**
     * Returns the price of the property.
     * 
     * @return The price of the property.
     */
    public int getPrice() {
        return price;
    }
    
    /**
     * Returns whether this property is sellable or not.
     * 
     * @return Whether this property is sellable or not.
     */
    public boolean isSellable() {
        // checks if it is an item that is not on sale, like the taxes and other staff - further discussion
        if(property != null && property.getOwner() != null) {
            /*// checks if it is actually owned by someone
            if(property != null || property.getOwner() != null) {
                return true;
            }*/
            return false;
        }
        
        return true;
    }
    
    /**
     * Returns the name of the property.
     * 
     * @return The name of the property.
     */
    public String getName() {
        return name;
    }
    
    public void locatePlayer(Player p) {
        _fireLocationEvent(this, p);
    }
    
    public void build() {
        property.build();
    }
    
    public Property getProperty() {
        return property;
    }
}
