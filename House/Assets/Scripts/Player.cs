using System;
using UnityEngine.UI;
using UnityEngine;

public class Player
{
	private string name;
	private Token token;
	private bool bot;
	private int money;

	public Player (string name, int token, bool bot)
	{
		this.name = name;

		this.token = new Token();


		this.bot = bot;
		// check what is the initial amount of money for a player
		money = 1500;

		// here add the query for the database that is going to save the player's info
	}

	public void movePlayer(int positions) {
		token.movePiece (positions);
	}

	public void payAnotherPlayer(int incoming) {
		money += incoming;
	}

	public void getPaidByAnotherPlayer(int outcoming) {
		money -= outcoming;
	}

	public Token getToken() {
		return token;
	}

	public string getName() {
		return name;
	}

	public Boolean isBot() {
		return bot;
	}
}

