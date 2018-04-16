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
public class Board {
    
    private Tile board[];
    private Property properties[];
    private Pot_Luck potLuck[];
    private Opportunity_Knocks OpportunityKnocks[];
    private ArrayList<Pot_Luck> pl;
    private ArrayList<Opportunity_Knocks> ok;
    
    public Board() {
        board = new Tile[40];
        properties = new Property[40];
        pl = new ArrayList<Pot_Luck>();
        ok = new ArrayList<Opportunity_Knocks>();
        potLuck = new Pot_Luck[16];
        OpportunityKnocks = new Opportunity_Knocks[16];
        
        setupBoard();
        setupCards();
    }
    
    public void setupBoard() {
        board[0] = new Tile("GO");
        board[0].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                //p.addMoney(200);
                action(t, p);
                
                /*
                    We know that the game starts now, because we do not have dice.
                    We will use this, in order to change the Player.PassedGO, when
                    the gameplay starts.
                */
                
                if(Monopoly.dice != null) {
                    //p.passedGO();
                }
            }
        });
        
        // Crapper Street
        properties[0] = new Property("Crapper Street", Group.Brown);
        board[1] = new Tile(properties[0], 60);
        board[1].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[2] = new Tile("Pot Luck");
        board[2].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        // Gangsters Paradise
        properties[1] = new Property("Gangsters Paradise", Group.Brown);
        board[3] = new Tile(properties[1], 60);
        board[3].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[4] = new Tile("Income Tax");
        board[4].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        // Brighton Station
        properties[2] = new Property("Brighton Station", Group.Station);
        board[5] = new Tile(properties[2], 200);
        board[5].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        // Weeping Angel
        properties[3] = new Property("Weeping Angel", Group.Blue);
        board[6] = new Tile(properties[3], 100);
        board[6].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[7] = new Tile("Opportunity Knocks");
        board[7].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Potts Avenue
        properties[4] = new Property("Potts Avenue", Group.Blue);
        board[8] = new Tile(properties[4], 100);
        board[8].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Nardole Drive
        properties[5] = new Property("Nardole Drive", Group.Blue);
        board[9] = new Tile(properties[5], 120);
        board[9].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[10] = new Tile("Jail / Just Visiting");
        board[10].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Skywalker Drive
        properties[6] = new Property("Skywalker Drive", Group.Purple);
        board[11] = new Tile(properties[6], 140);
        board[11].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Tesla Power Co
        properties[7] = new Property("Tesla Power Co", Group.Utilities);
        board[12] = new Tile(properties[7], 150);
        board[12].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        // Wookie Hole
        properties[8] = new Property("Wookie Hole", Group.Purple);
        board[13] = new Tile(properties[8], 140);
        board[13].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Rey Lane
        properties[9] = new Property("Rey Lane", Group.Purple);
        board[14] = new Tile(properties[9], 160);
        board[14].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Hove Station
        properties[10] = new Property("Hove Station", Group.Station);
        board[15] = new Tile(properties[10], 200);
        board[15].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Cooper Drive
        properties[11] = new Property("Cooper Drive", Group.Orange);
        board[16] = new Tile(properties[11], 180);
        board[16].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[17] = new Tile("Pot Luck");
        board[17].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Wolowitz Street
        properties[12] = new Property("Wolowitz Street", Group.Orange);
        board[18] = new Tile(properties[12], 180);
        board[18].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Penny Lane
        properties[13] = new Property("Penny Lane", Group.Orange);
        board[19] = new Tile(properties[13], 200);
        board[19].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[20] = new Tile("Free Parking");
        board[20].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Yue Fei Square
        properties[14] = new Property("Yue Fei Square", Group.Red);
        board[21] = new Tile(properties[14], 220);
        board[21].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[22] = new Tile("Opportunity Knocks");
        board[22].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Mulan Rouge
        properties[15] = new Property("Mulan Rouge", Group.Red);
        board[23] = new Tile(properties[15], 220);
        board[23].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Han Xin Gardens
        properties[16] = new Property("Han Xin Gardens", Group.Red);
        board[24] = new Tile(properties[16], 240);
        board[24].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Falmer Station
        properties[17] = new Property("Falmer Station", Group.Station);
        board[25] = new Tile(properties[17], 200);
        board[25].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Kirk Close
        properties[18] = new Property("Kirk Close", Group.Yellow);
        board[26] = new Tile(properties[18], 260);
        board[26].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Ricard Avenue
        properties[19] = new Property("Picard Avenue", Group.Yellow);
        board[27] = new Tile(properties[19], 260);
        board[27].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Edison Water
        properties[20] = new Property("Edison Water", Group.Utilities);
        board[28] = new Tile(properties[20], 150);
        board[28].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Crusher Creek
        properties[21] = new Property("Crusher Creek", Group.Yellow);
        board[29] = new Tile(properties[21], 280);
        board[29].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[30] = new Tile("Go to jail");
        board[30].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Sirat Mews
        properties[22] = new Property("Sirat Mews", Group.Green);
        board[31] = new Tile(properties[22], 300);
        board[31].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Ghengis Crescent
        properties[23] = new Property("Ghengis Crescent", Group.Green);
        board[32] = new Tile(properties[23], 300);
        board[32].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[33] = new Tile("Pot Luck");
        board[33].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Ibis Close
        properties[24] = new Property("Ibis Close", Group.Green);
        board[34] = new Tile(properties[24], 320);
        board[34].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Lewes Station
        properties[25] = new Property("Lewes Station", Group.Station);
        board[35] = new Tile(properties[25], 200);
        board[35].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[36] = new Tile("Opportunity Knocks");
        board[36].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Hawking Way
        properties[26] = new Property("Hawking Way", Group.Deep_Blue);
        board[37] = new Tile(properties[26], 350);
        board[37].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        board[38] = new Tile("Super Tax");
        board[38].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
        
        //Turing Heights
        properties[27] = new Property("Turing Heights", Group.Deep_Blue);
        board[39] = new Tile(properties[27], 400);
        board[39].addTileListener(new TileListenerInt() {
            @Override
            public void playerReceived(Tile t, Player p) {
                System.out.println(p.getName() + " is at " + t.getName());
                action(t, p);
            }
        });
    }
    
    public void setupCards() {
        Opportunity_Knocks a;
        
        a = new Opportunity_Knocks("This is what it does.");
        a.addCardListener(new CardListenerInt() {
            @Override
            public void cardReceived(Player p) {
                
            }
        });
        ok.add(a);
        
        a = new Opportunity_Knocks("This is what it does2.");
        a.addCardListener(new CardListenerInt() {
            @Override
            public void cardReceived(Player p) {
                
            }
        });
        ok.add(a); 
   }
    
    // this is called from the tile listeners
    public void action(Tile currentTile, Player p) {
        
        if(currentTile.getProperty() == null) {
            JOptionPane.showMessageDialog(null, "It is a card or tax");
            
        } else if(p.passedGOa() && currentTile.isSellable() && p.getMoney() >= currentTile.getPrice()) { // ask if the player does not have money for the property is the property going to auction automatically?
            boolean auction = p.declareAuction();
            
            if(auction) {
                auction(currentTile);
            } else {
                p.buyProperty(currentTile);
            }
        } else if(currentTile.getProperty().getOwner() != null && !p.equals(currentTile.getProperty().getOwner())) {
            JOptionPane.showMessageDialog(null, "It is owned by someone else");
            p.payRent(currentTile.getProperty());
        } else if(p.getMoney() < currentTile.getPrice() && !p.equals(currentTile.getProperty().getOwner())) {
            if(currentTile.getProperty().getOwner()!= null)
                JOptionPane.showMessageDialog(null, "You don't have enough money to buy the property.");
        } else {
            JOptionPane.showMessageDialog(null, "Not a possible thing to do!!!");
            // SUGGESTIONS: maybe have the build here!
        }
    }
    
    public void auction(Tile property) {
        ArrayList<Player> players = Monopoly.players;
        
        for(Player p : players) {
            p.joinAuction();
        }
        
        int localPlayer = 0;
        int highestBid = 0;
        int highestBidder = -1;
        
        while(auctionIt(players)) {
            
            int bid = 0;
            
            if(players.get(localPlayer).auctionIt()) {
                
                bid = players.get(localPlayer).bid();
                
                if(bid > highestBid) {
                    // checks if the bid of the current player is bigger than the highest bid
                    if(players.get(localPlayer).getMoney() >= bid) {
                        highestBidder = localPlayer;
                        highestBid = bid;
                        localPlayer++;
                    } else {
                        JOptionPane.showMessageDialog(null, "Sorry, "
                                + "" + players.get(localPlayer).getName() + "! "
                                        + "You have insufficient funds for this "
                                        + "bid. Check if you can bid something "
                                        + "smaller. The highest bid is "
                                        + "" + highestBid);
                    }
                } else if(bid == 0) {
                    // If the bid is 0, then it is withdrawn from the auction.
                    JOptionPane.showMessageDialog(null, "Hey, "
                            + "" + players.get(localPlayer).getName() + "! You "
                                    + "just left the Auction.");
                    players.get(localPlayer).leaveAuction();
                    localPlayer++;
                } else {
                JOptionPane.showMessageDialog(null, "Hey, "
                        + "" + players.get(localPlayer).getName() + "! Your bid"
                                + " is smaller than the highest bid at "
                                + "" + highestBid + " from "
                                        + "" + players.get(highestBidder).getName());
                }
            } else {
                // when the player does not take part in the auction just skips the player.
                localPlayer++;
            }
            
            if(localPlayer >= players.size()) {
                localPlayer = 0;
            }
        }
        
        if(highestBidder != -1 && highestBid > 0) {
            JOptionPane.showMessageDialog(null, "Hey, "
                    + "" + players.get(highestBidder).getName() + "! You are "
                            + "the highest bidder. You just bought "
                            + "" + property.getName());
            players.get(highestBidder).buyProperty(property);
        } else {
            // when there are 2 bidders and the first bidder leaves the auction, the second bidder doesn't have the opportunity to do its bid.
            // first bidder bids 0
            // second bidder doesn't have the opportunity to bid.
            JOptionPane.showMessageDialog(null, "None bought this area. It is owned by the bank.");
        }
    }
    
    public boolean auctionIt(ArrayList<Player> players) {
        int counter = 0;
        
        for(int i = 0; i < players.size(); i++) {
            if(players.get(i).auctionIt()) {
                counter++;
            }
        }
        
        return counter >= 2;
    }
    
    public void movePlayer(Player p, int moves) {
        // saves the position of the player to the player side
        p.move(moves);

        // saves the position of the player to the board side
        board[p.getPosition()].locatePlayer(p);
    }
}
