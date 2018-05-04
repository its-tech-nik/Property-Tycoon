using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileListener : MonoBehaviour {

	public GameObject auctionORbuy;
	public static GameObject auction_buy;

	private static Tile currentTile;
	private static Player p;

	void Start() {
		auction_buy = auctionORbuy;
	}

	public void PropertyListener() {

	}

	public static void action(Tile currentT, Player p1) {
		currentTile = currentT;
		p = p1;

		if(currentTile.GetProperty() == null) {
			Debug.Log ("It is a card or tax");

		} else if(currentTile.GetProperty().GetOwner() != null || p.Equals(currentTile.GetProperty().GetOwner())) {
			Debug.Log ("It is owned by someone else or yourself.");
			//p.PayRent(currentTile.GetProperty());
		} else if(p.PassedGo() && currentTile.IsSellable() && p.GetMoney() >= currentTile.GetPrice()) { // ask if the player does not have money for the property is the property going to auction automatically?
			// show UI where it asks for auction or buy.
			auction_buy.SetActive (true);
		} else if(p.GetMoney() < currentTile.GetPrice() && !p.Equals(currentTile.GetProperty().GetOwner())) {
			if(currentTile.GetProperty().GetOwner()!= null)
				Debug.Log ("You don't have enough money to buy the property.");
		} else {
			Debug.Log ("Not a possible thing to do!!!");
			// SUGGESTIONS: maybe have the build here!
		}
	}

	public void Buy() {
		p.BuyProperty (currentTile);
	}

	public static void Auction(Tile tile) {
		List<Player> players = Game.players;

		foreach(Player p in players) {
			p.JoinAuction();
		}

		int localPlayer = 0;
		int highestBid = 0;
		int highestBidder = -1;

		while(MinimumPlayersForAuction(players)) {

			int bid = 0;

			if(players[localPlayer].AuctionIt()) {

				bid = players[localPlayer].Bid();

				if(bid > highestBid) {
					// checks if the bid of the current player is bigger than the highest bid
					if(players[localPlayer].GetMoney() >= bid) {
						highestBidder = localPlayer;
						highestBid = bid;
						localPlayer++;
					} else {
						Debug.Log ("Sorry, "
							+ "" + players[localPlayer].GetName() + "! "
							+ "You have insufficient funds for this "
							+ "bid. Check if you can bid something "
							+ "smaller. The highest bid is "
							+ "" + highestBid);
					}
				} else if(bid == 0) {
					// If the bid is 0, then it is withdrawn from the auction.
					Debug.Log("Hey,"
						+ players[localPlayer].GetName() + "! You "
						+ "just left the Auction.");
					
					players[localPlayer].LeaveAuction();
					localPlayer++;
				} else {
					Debug.Log("Hey, "
						+ "" + players[localPlayer].GetName() + "! Your bid"
						+ " is smaller than the highest bid at "
						+ "" + highestBid + " from "
						+ "" + players[highestBidder].GetName());
				}
			} else {
				// when the player does not take part in the auction just skips the player.
				localPlayer++;
			}

			// check that it actually works
			if(localPlayer >= players.Count) {
				localPlayer = 0;
			}
		}

		if(highestBidder != -1 && highestBid > 0) {
			Debug.Log ("Hey, "
				+ players[highestBidder].GetName() + "! You are "
				+ "the highest bidder. You just bought "
				+ tile.GetName());
			players[highestBidder].BuyProperty(tile);
		} else {
			// when there are 2 bidders and the first bidder leaves the auction, the second bidder doesn't have the opportunity to do its bid.
			// first bidder bids 0
			// second bidder doesn't have the opportunity to bid.
			Debug.Log ("None bought this area. It is owned by the bank.");
		}
	}

    public static bool MinimumPlayersForAuction(List<Player> players) {
        int counter = 0;

		foreach (Player p in players) {
			if(p.AuctionIt()) {
				counter++;
			}
		}
        return counter >= 2;
    }


}


