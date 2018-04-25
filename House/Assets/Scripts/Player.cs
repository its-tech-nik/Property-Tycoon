using System;

public class Player
{
	private string name;
	private int token;
	private Boolean bot;

	public Player (string name, int token, Boolean bot)
	{
		this.name = name;
		this.token = token;
		this.bot = bot;
	}

	public int getToken() {
		return token;
	}

	public string getName() {
		return name;
	}

	public Boolean isBot() {
		return bot;
	}
}

