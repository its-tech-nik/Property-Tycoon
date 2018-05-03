using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
	public GameObject[] boardGraphics;
	public static Tile[] board = new Tile[40];
	public Text RollField;

	public GameObject[] tokens;
	public static Dictionary<string, GameObject> Tokens;
	public static Player[] players = new Player[6];

	public static int currentPlayer = 0;
	public static Dice dice = new Dice();

	private int DoublesCounter = 0;

	public GameObject Buy_Auction;

	// board check
	// pot luck
	// opportunity knock
	// players check
	// dice check


	// Use this for initialization
	void Start () {
		//Debug.Log ("Game Object");
	}
	
	// Update is called once per frame
	void Update () {
		if(dice.IsDoneRolling()) {
			RollField.text = dice.GetDie (0) + "+" + dice.GetDie (1);
			RollField.gameObject.SetActive (true);
		}
	}

	public void RollDice() {
		int roll = dice.Roll ();
		Player p = players [currentPlayer];

		if (dice.IsDoubles ()) {
			DoublesCounter++;

			if(DoublesCounter == 3) {
				DoublesCounter = 0;

				// Send player in jail.
				Debug.Log ("In jail");
			}
		} else {
			DoublesCounter = 0;
			nextPlayer ();
		}

		p.movePlayer (roll);

		Vector3 pos = boardGraphics [p.GetPosition ()].transform.position;

		Tokens [p.getToken ()].transform.position = pos;
		Debug.Log ("Should be: " + board[p.GetPosition()].GetName());
		Debug.Log (Tokens [p.getToken ()].name + ": " + Tokens [p.getToken ()].transform.position + "\tStartingTile: " + boardGraphics [p.GetPosition ()].transform.position);

		Debug.Log ("Total: " + dice.GetRoll() + "\tCounter: " + DoublesCounter);
	}

	public void AddTokens() {
		Tokens = new Dictionary<string, GameObject> ();

		for(int i = 0; i < AssignTokens.numberOfPlayers; i++) {
			Tokens.Add (tokens[i].name, tokens[i]);
		}

		tokens = null;

		/*Debug.Log (Tokens.Count);
		for(int i = 0; i < AssignTokens.numberOfPlayers; i++) {
			Debug.Log (Tokens[tokens[i].name]);
		}*/
	}

	private void nextPlayer() {
		currentPlayer++;
		//Debug.Log ("Next player is player no. " + currentPlayer);

		if(currentPlayer >= AssignTokens.numberOfPlayers) {
			currentPlayer = 0;
		}
	}
}
