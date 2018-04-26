using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersScripts : MonoBehaviour {

	public GameObject[] playerObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showPlayers() {
		for(int i = 0; i < AssignTokens.numberOfPlayers; i++) {
			if(AssignTokens.players[i].isBot()) {
				playerObj [i].SetActive (true);
			}
		}
	}
}
