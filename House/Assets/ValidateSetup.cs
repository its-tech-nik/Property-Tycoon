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
	public GameObject LeftSideBar;
	public GameObject ChooseToken;

	// Warnings
	public GameObject playersWarningMessage;
	public GameObject timerWarningMessage;

	private Toggle tog;

	public void validateStart() {
		int players = 0;

		if (!p1.text.Equals ("")) {
			players++;
		}

		if (!p2.text.Equals ("")) {
			players++;
		}

		if (!p3.text.Equals ("")) {
			players++;
		}

		if (!p4.text.Equals ("")) {
			players++;
		}

		if (!p5.text.Equals ("")) {
			players++;
		}

		if (!p6.text.Equals ("")) {
			players++;
		}

		if (players >= 2) {
			int minutes = 0;

			if (timer.IsActive () && !timer.text.Equals ("") && int.Parse (timer.text) >= 5) {
				minutes = int.Parse (timer.text);

				Debug.Log ("The timer is " + minutes);

				Debug.Log ("Start Timed Game");
				SetupGame.SetActive (false);
				LeftSideBar.SetActive (true);
				ChooseToken.SetActive (true);
			} else if (timer.IsActive()) {
				Debug.Log ("No game");
				timerWarningMessage.SetActive (true);
			} else if (!timer.IsActive()){
				Debug.Log ("Start Normal Game");
				SetupGame.SetActive (false);
				LeftSideBar.SetActive (true);
				ChooseToken.SetActive (true);
			}
		} else {
			Debug.Log ("No game");
			playersWarningMessage.SetActive (true);
		}
	}

	public void addBotName(InputField field) {
		if (tog.isOn && field.text.Equals ("")) {
			field.text = "BOT";
		} else if (field.text.Equals ("BOT")) {
			field.text = "";
		}
	}

	public void getToggle(Toggle tog) {
		this.tog = tog;
	}
}
