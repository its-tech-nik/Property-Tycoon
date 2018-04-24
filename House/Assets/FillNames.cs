using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillNames : MonoBehaviour {

	public Text player1;
	public Text player2;
	public Text player3;
	public Text player4;
	public Text player5;
	public Text player6;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addNames() {

		Player[] ps = AssignTokens.players;
		int index = 0;

		for (int i = 0; i < ps.Length; i++) {
			if(ps[i] != null) {
				if(index == 0) {
					player1.text = ps [i].getName ();
				} else if(index == 1) {
					player2.text = ps [i].getName ();
				} else if(index == 2) {
					player3.text = ps [i].getName ();
				} else if(index == 3) {
					player4.text = ps [i].getName ();
				} else if(index == 4) {
					player5.text = ps [i].getName ();
				} else if(index == 5) {
					player6.text = ps [i].getName ();
				}

				index++;
			}
		}
	}
}
