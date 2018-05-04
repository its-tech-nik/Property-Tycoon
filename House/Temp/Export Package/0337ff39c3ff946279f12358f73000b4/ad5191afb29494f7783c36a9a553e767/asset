using System.Collections.Generic;
using UnityEngine;

public class Player
{
	private string name;
	private Token token;
	private bool bot;
	private int money;
	private bool isMoving;
	private bool auctionIt;
	private List<Property> owns;

	public Player (string name, string token, bool bot) {
		this.name = name;

		this.token = new Token (token);

		this.bot = bot;
		// check what is the initial amount of money for a player
		money = 1500;
		isMoving = true;
		auctionIt = false;

		owns = new List<Property> ();
		// here add the query for the database that is going to save the player's info
	}

	public int Bid() {
		int bid = -1;

		/*try {
			bid = Integer.parseInt(JOptionPane.showInputDialog(null,  "Hey, " + name + "! What is your bid?"));
		} catch(NumberFormatException nfe) {
			JOptionPane.showMessageDialog(null, "You entered a letter.");
			System.exit(0);
		}*/

		if(bid == 0) {
			auctionIt = false;
		}

		return bid;
	}

	public void LeaveAuction() {

	}

	public void BuyProperty(Tile t) {
		BuildingManager.iterations = 0;
		money -= t.GetPrice ();
		owns.Add (t.GetProperty());
		t.GetProperty ().BuyIt (this);
		BuildingManager.needsUpdate = true;
	}

	public void JoinAuction() {
		if(money > 0) {
			auctionIt = true;
		}
	}

	public bool AuctionIt() {
		return auctionIt;
	}

	public void movePlayer(int positions) {
		token.movePiece (positions);
		BuildingManager.needsUpdate = true;
	}

	public void payAnotherPlayer(int incoming) {
		money += incoming;
	}

	public void getPaidByAnotherPlayer(int outcoming) {
		money -= outcoming;
	}

	public List<Property> GetProperties() {
		return owns;
	}

	public bool PassedGo() {
		return token.HasPassedGo ();
	}

	public int GetMoney() {
		return money;
	}

	public string GetToken() {
		return token.GetShape ();
	}

	public string GetName() {
		return name;
	}

	public bool isBot() {
		return bot;
	}

	public int GetPosition() {
		return token.GetPosition ();
	}

	public bool IsMoving() {
		return isMoving;
	}
}

