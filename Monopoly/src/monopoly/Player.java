/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
 
 package monopoly;

 


import java.awt.Dimension;
import java.util.ArrayList;
import javax.swing.DefaultListModel;
import javax.swing.JFrame;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import javax.swing.ListSelectionModel;

/**
 *
 * @author nikandrosmavroudakis
 */
public class Player {
    
    private final String name;
    private final Token token;
    private int money;
    private ArrayList<Property> owns;
    private boolean auctionIt;
    private boolean passedGO;
    private boolean isMoving;
    private int countDownIsMoving;
    
    JList jl;
    DefaultListModel listModel;
    JFrame jf;
    
    public Player(String name, Token token) {
        this.name = name;
        this.money = 1500;
        owns = new ArrayList<Property>();
        auctionIt = true;
        // for testing purpose I turn it to true, so I don't need to play many
        // to pass the GO. When the player is instantiated this value has to be
        // false.
        passedGO = true;
        isMoving = true;
        countDownIsMoving = 2;
        this.token = token;
        
        jf = new JFrame(name + " " + money);
        
            listModel = new DefaultListModel();
            
            jl = new JList(listModel);
            jl.setSelectionMode(ListSelectionModel.SINGLE_INTERVAL_SELECTION);
            jl.setLayoutOrientation(JList.HORIZONTAL_WRAP);
            jl.setVisibleRowCount(-1);
                
                JScrollPane listScroller = new JScrollPane(jl);
                listScroller.setPreferredSize(new Dimension(250, 80));
        
                
        jf.setSize(new Dimension(200, 400));
        jf.setLocationRelativeTo(null);
        
        jf.add(jl);
        
        jf.setVisible(true);
    }
    
    /**
     * Adds Money to your balance.
     * 
     * @param money The amount of money.
     */
    public int addMoney(int money) {
        this.money += money;
        jf.setTitle(name + " " + this.money);
        return this.money;
    }
    
    /**
     * Removes money of your balance.
     * 
     * @param money The amount of money.
     */
    public int removeMoney(int money) {
        jf.setTitle(name + " " + this.money);
        
        int moneyDifference = this.money;
        this.money -= money;
        moneyDifference -= this.money;
        
        return moneyDifference;
    }
    
    /**
     * The player decides whether will buy the tile or declare a auction.
     * 
     * @return false when the player want to buy it, true otherwise (declares a auction).
     */
    public boolean declareAuction() {
        int decision = JOptionPane.showConfirmDialog(null, "Hey, " + name + "! Do you want to buy the property?");
        
        //int decision = 0;
        
        if(decision == 0) {
            return false;
        }
        
        return true;
    }
    
    /**
     * Makes the transaction and transfers the tile to the player who bought it.
     * 
     * @param t The tile that is being purchased.
     */
    public void buyProperty(Tile t) {
        listModel.addElement(t.getProperty().getName());
        removeMoney(t.getPrice());
        owns.add(t.getProperty());
        // saves the player in the property internally
        t.getProperty().buyIt(this);
    }
    
    /**
     * The user bids.
     * 
     * @return The bid of the user.
     */
    public int bid() {
        int bid = -1;
        
        try {
            bid = Integer.parseInt(JOptionPane.showInputDialog(null,  "Hey, " + name + "! What is your bid?"));
        } catch(NumberFormatException nfe) {
            JOptionPane.showMessageDialog(null, "You entered a letter.");
            System.exit(0);
        }
        
        if(bid == 0) {
            auctionIt = false;
        }
        
        return bid;
    }
    
    /**
     * Will set passedGo to true, when the player passes the go
     * 
     * @param passedGO 
     */
    public void passedGO() {
        passedGO = true;
    }
    
    public boolean passedGOa() {
        return passedGO;
    }
    
    /**
     * Moves the player on the board.
     * 
     * @param position The amount of position a player needs to move.
     */
    public void move(int moves) {
        int newPosition = token.getPosition() + moves;
        
        if(newPosition >= 40) {
            newPosition -= 40;
            // this is when it always passes the GO
            // here is when the player gets the money.
            System.out.println("Passes GO");
            addMoney(50);
            passedGO = true;
        }
        jf.setTitle(name + " " + money);
        token.setPosition(newPosition);
    }
    
    /**
     * Returns the name of the player.
     * 
     * @return The name of the player.
     */
    public String getName() {
        return name;
    }
    
    /**
     * Returns the current position of the player.
     * 
     * @return The current position of the player.
     */
    public int getPosition() {
        return token.getPosition();
    }
    
    /**
     * Returns the money the player has.
     * 
     * @return The money the player has.
     */
    public int getMoney() {
        return money;
    }
    
    /**
     * Allows to the player to join the auction, initially.
     */
    public void joinAuction() {
        if(money > 0) {
            auctionIt = true;
        }
    }
    
    public void leaveAuction() {
        auctionIt = false;
    }
    
    /**
     * Returns whether the player wants to join the auction or not.
     * 
     * @return Whether the player wants to join the auction or not.
     */
    public boolean auctionIt() {
        return auctionIt;
    }
    
    public int goToJail() {
        token.setPosition(10);
        return 10;
    }
    
    // this is for when the player needs to lose its go for 2 or 3 (not sure) times.
    public boolean isMoving() {
        if(!isMoving) {
            countDownIsMoving--;
            
            if(countDownIsMoving == 0) {
                countDownIsMoving = 2;
                isMoving = true;
            }
        }
        return isMoving;
    }
    
    public void isNotMoving() {
        isMoving = false;
    }
    
    public void payRent(Property p) {
        int rent = p.getRent();
        
        addMoney(p.getOwner().removeMoney(p.getRent()));
        
        if(removeMoney(rent) < 0 && owns.size() > 0) {
            JOptionPane.showMessageDialog(null, "Insufficient funds. You have to sell somethin to pay for the rent to " + p.getOwner().getName());
            // here force the player to destroy buildings, sell properties and whatever is possible to get money.
            
            int option = JOptionPane.showConfirmDialog(null, "You have to sell or mortgage properties. Yes for sell, No for mortgage, Cancel to surrender.");
            
            if(option == 0) {
                JOptionPane.showMessageDialog(null, "SELL IT");
            } else if(option == 1) {
                JOptionPane.showMessageDialog(null, "MORTGAGE IT");
            } else if(option == 2) {
                JOptionPane.showMessageDialog(null, "SURRENDER");
            }
        }
        
        Player playerTo = p.getOwner();
        System.out.println(playerTo);
        playerTo.addMoney(rent);
    }
    
    public void mortgageProperties() {
        
    }
    
    public void sellProperties() {
        
    }
}
