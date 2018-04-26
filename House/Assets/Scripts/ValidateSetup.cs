using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ValidateSetup : MonoBehaviour {

	// Input Name Fields
	public InputField[] fields;

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

		// Get the names from fields and save then in an array.
		for(int i = 0; i < fields.Length; i++) {
			string content = fields [i].text;

			if(!content.Equals("")) {
				names [player] = content;
				player++;
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
