using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignTokens : MonoBehaviour {

	public string[] names;
	public int[] tokens;

	public static Player[] players;

	public Toggle t1;
	public Toggle t2;
	public Toggle t3;
	public Toggle t4;
	public Toggle t5;
	public Toggle t6;

	private int index;

	public GameObject chooseTokenGameObj;
	public GameObject bottomPanel;
	public GameObject leftPanel;
	public Text header;

	// Use this for initialization
	void Start () {
		index = 0;
		names = new string[6];
		players = new Player[6];
		tokens = new int[6];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setHeader() {
		header.text = ValidateSetup.names[index] + " Choose Token:";
	}

	public void chooseToken() {
		if(names[0] == null) {
			names = ValidateSetup.names;
		}

		int token = 0;

		if(t1.isOn) {
			token = 1;
			tokens [index] = token;
			ToggleGroup t = t1.GetComponentInParent<ToggleGroup> ();
			t.SetAllTogglesOff ();
			t1.interactable = false;
			t1.isOn = false;
			index++;
		}

		if(t2.isOn) {
			token = 2;
			tokens [index] = token;
			ToggleGroup t = t1.GetComponentInParent<ToggleGroup> ();
			t.SetAllTogglesOff ();
			t2.interactable = false;
			index++;
		}

		if(t3.isOn) {
			token = 3;
			tokens [index] = token;
			ToggleGroup t = t1.GetComponentInParent<ToggleGroup> ();
			t.SetAllTogglesOff ();
			t3.interactable = false;
			index++;
		}

		if(t4.isOn) {
			token = 4;
			tokens [index] = token;
			ToggleGroup t = t1.GetComponentInParent<ToggleGroup> ();
			t.SetAllTogglesOff ();
			t4.interactable = false;
			index++;
		}

		if(t5.isOn) {
			token = 5;
			tokens [index] = token;
			ToggleGroup t = t1.GetComponentInParent<ToggleGroup> ();
			t.SetAllTogglesOff ();
			t5.interactable = false;
			index++;
		}

		if(t6.isOn) {
			token = 6;
			tokens [index] = token;
			ToggleGroup t = t1.GetComponentInParent<ToggleGroup> ();
			t.SetAllTogglesOff ();
			t6.interactable = false;
			index++;
		}

		if (ValidateSetup.names [index] == null) {
			for (int i = 0; i < names.Length; i++) {
				if (names [i] != null) {
					players [i] = new Player (names[i], tokens[i]);
				}
			}

			chooseTokenGameObj.SetActive (false);
			leftPanel.SetActive (true);
			bottomPanel.SetActive (true);
		} else {
			header.text = ValidateSetup.names [index] + " Choose Token:";
		}
	}
}
