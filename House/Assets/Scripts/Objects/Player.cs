public class Player
{
	private string name;
	private Token token;
	private bool bot;
	private int money;
	private bool isMoving;

	public Player (string name, string token, bool bot)
	{
		this.name = name;

		this.token = new Token (token);

		this.bot = bot;
		// check what is the initial amount of money for a player
		money = 1500;
		isMoving = true;

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

	public string getToken() {
		return token.GetShape ();
	}

	public string getName() {
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

