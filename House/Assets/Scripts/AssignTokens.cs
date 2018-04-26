using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignTokens : MonoBehaviour {

	public Toggle[] toggles;
	public GameObject chooseTokenGameObj;
	public GameObject startGame;
	public Text header;

	public static Player[] players = new Player[6];
	public static int numberOfPlayers;

	private int index = 0;

	void Start() {
		fillTests ();
	}

	private void fillTests() {
		players [0] = new Player ("Nikandros", 1);
		players [1] = new Player ("Kiriakos", 2);
		players [2] = new Player ("Bot", 3);
		numberOfPlayers = 3;
	}

	public void setHeader() {
		header.text = ValidateSetup.names[index] + " Choose Token:";
	}

	public void chooseToken() {
		//int token = 0;

		for(int i = 0; i < toggles.Length; i++) {
			Toggle t = toggles [i];

			if(t.isOn) {
				players [index] = new Player (ValidateSetup.names[index], i);
				ToggleGroup tg = t.GetComponentInParent<ToggleGroup> ();
				tg.SetAllTogglesOff ();
				t.interactable = false;
				t.isOn = false;
				index++;
				setHeader ();
			}
		}

		if (ValidateSetup.names [index] == null) {
			numberOfPlayers = index;
			chooseTokenGameObj.SetActive (false);
			startGame.SetActive (true);
		}
	}
}
