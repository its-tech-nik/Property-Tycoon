/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
 
 package monopoly;

 


import java.util.Random;

/**
 *
 * @author nikandrosmavroudakis
 */
public class Dice {
    public static int doubles;
    public static boolean doubles2;
    
    public Dice() {
        doubles = 0;
        doubles2 = false;
    }
    
    public int rollDice() {
        Random r = new Random();
        
        int die1 = r.nextInt(6) + 1;
        int die2 = r.nextInt(6) + 1;
        
        doubles2 = die1 == die2;
        
        if(doubles2) {
            System.out.println("Doubles");
            doubles++;
        }
        
        return die1 + die2;
    }
}
