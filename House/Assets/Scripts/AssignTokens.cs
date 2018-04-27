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

	}

	public void setHeader() {
		header.text = ValidateSetup.names[index] + " Choose Token:";
	}

	public void chooseToken() {
		for(int i = 0; i < toggles.Length; i++) {
			Toggle t = toggles [i];

			if(t.isOn) {
				players [index] = new Player (ValidateSetup.names[index], i, ValidateSetup.bot[i]);
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
