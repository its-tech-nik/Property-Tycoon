using System;
using UnityEngine;

public class Token {

	private int position;
	private bool passedGo;

	public Token () {
		position = 0;
		passedGo = false;
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
			return passedGo = true;
		}
		return false;
	}


}

