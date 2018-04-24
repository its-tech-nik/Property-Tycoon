using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ValidateSetup : MonoBehaviour {

	// Input Name Fields
	public InputField p1;
	public InputField p2;
	public InputField p3;
	public InputField p4;
	public InputField p5;
	public InputField p6;

	public InputField timer;

	public GameObject SetupGame;
	public GameObject ChooseToken;

	// Warnings
	public GameObject playersWarningMessage;
	public GameObject timerWarningMessage;

	private Toggle tog;

	public static string[] names = new string[6];

	public bool validateStart() {
		int player = 0;

		if (!p1.text.Equals ("")) {
			names [player] = p1.text;
			player++;
		}

		if (!p2.text.Equals ("")) {
			names [player] = p2.text;
			player++;
		}

		if (!p3.text.Equals ("")) {
			names [player] = p3.text;
			player++;
		}

		if (!p4.text.Equals ("")) {
			names [player] = p4.text;
			player++;
		}

		if (!p5.text.Equals ("")) {
			names [player] = p5.text;
			player++;
		}

		if (!p6.text.Equals ("")) {
			names [player] = p6.text;
			player++;
		}

		for (int i = 0; i < names.Length; i++) {
			if (names [i] != null) {
				Debug.Log (names [i]);
			}
		}

		if (player >= 2) {
			int minutes = 0;

			if (timer.IsActive () && !timer.text.Equals ("") && int.Parse (timer.text) >= 5) {
				minutes = int.Parse (timer.text);

				Debug.Log ("The timer is " + minutes);

				Debug.Log ("Start Timed Game");
				return true;
			} else if (timer.IsActive()) {
				Debug.Log ("No game");
				timerWarningMessage.SetActive (true);
				return false;
			} else if (!timer.IsActive()){
				Debug.Log ("Start Normal Game");
				return true;
			}
		} else {
			Debug.Log ("No game");
			playersWarningMessage.SetActive (true);
		}
		return false;
	}

	public void startGame () {
		if(validateStart()) {
			SetupGame.SetActive (false);
			ChooseToken.SetActive (true);
		}
	}

	public void addBotName(InputField field) {
		if (tog.isOn && field.text.Equals ("")) {
			field.text = "BOT";
		} else if (field.text.Equals ("BOT")) {
			field.text = "";
		}
	}

	// this is the AI toggle button
	public void getToggle(Toggle tog) {
		this.tog = tog;
	}
}
