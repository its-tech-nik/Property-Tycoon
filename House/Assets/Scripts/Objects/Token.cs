public class Token {

	private string shape;
	private int position;
	private bool passedGo;

	public Token (string shape) {
		position = 0;
		passedGo = false;
		this.shape = shape;
	}

	/**
     * Moves the token on the board.
     * 
     * @param position The amount of positions a token needs to be moved.
     * @return true if it has passed go, false otherwise.
     */
	public bool movePiece(int positions) {
		position += positions;

		if(position >= 40) {
			position -= 40;
			passedGo = true;
			return true;
		}
		return false;
	}

	public bool HasPassedGo() {
		return passedGo;
	}

	public string GetShape() {
		return shape;
	}

	public int GetPosition() {
		return position;
	}
}

