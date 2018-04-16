/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

 package monopoly;

 

import java.util.ArrayList;
import javax.swing.JOptionPane;

/**
 *
 * @author nikandrosmavroudakis
 */
public class Monopoly {
    public static ArrayList<Player> players;
    private int player;
    public static Dice dice;
    private Board board;
    
    public Monopoly(int numberOfPlayers) {
        players = new ArrayList<Player>();
        player = 0;
        
        board = new Board();
        
        for(int i = 0; i < numberOfPlayers; i++) {
            String name = JOptionPane.showInputDialog(null, "What is the name of the player no. " + (i + 1));
            players.add(new Player(name, new Token()));
        }
        
        // do not initialize the dice, before you locate all the players on the GO tile.
        dice = new Dice();
        
        procedure1();
    }
    
    /**
     * Checks if auction works.
     */
    public void procedure2() {
        nextPlay();
    }
    
    /**
     * Check if the doubles work.
     */
    public void procedure1() {
        for(int i = 0; i < 400; i++) {
            nextPlay();
            Dice.doubles2 = false;
        }
    }
    
    public void nextPlay() {
        Player p = players.get(player);
        
        if(p.isMoving()) {
            int moves = dice.rollDice();
            
            board.movePlayer(p, moves);

            if(!Dice.doubles2) {
                nextPlayer();

                Dice.doubles = 0;
            }
            //System.out.println(Dice.doubles2 + "\t" + Dice.doubles);
            if(Dice.doubles == 2) {
                board.movePlayer(p, p.goToJail());
                //System.out.println("============================================================================= GO TO JAIL");
                p.isNotMoving();
                
                nextPlayer();
                
                Dice.doubles = 0;
            }
        } else {
            nextPlayer();
        }
    }
    
    public void nextPlayer() {
        player++;

        if(player >= players.size()) {
            player = 0;
        }
    }
    
    public static void main(String[] args) {
        int numberOfPlayers2 = Integer.parseInt(JOptionPane.showInputDialog(null, "What is the number of players for this game?"));
        Monopoly m = new Monopoly(numberOfPlayers2);
        
        
        
        
        /*Board b = new Board();
        Player p = new Player("Nikandros");
        p.moves(0);
        b.movePlayer(p);
        System.out.println(p.passedGOa());
        dice = new Dice();
        
        p.moves(20);
        b.movePlayer(p);
        p.moves(21);
        b.movePlayer(p);
        System.out.println(p.passedGOa());*/
    }
}
