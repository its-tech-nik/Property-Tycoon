using System;

public class Player
{
	private string name;
	private int token;

	public Player (string name, int token)
	{
		this.name = name;
		this.token = token;
	}

	public int getToken() {
		return token;
	}

	public string getName() {
		return name;
	}
}

