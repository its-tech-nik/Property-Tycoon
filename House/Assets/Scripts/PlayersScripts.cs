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
		Debug.Log (AssignTokens.numberOfPlayers);
		for(int i = 0; i < AssignTokens.numberOfPlayers; i++) {
			playerObj [i].SetActive (true);



			if (AssignTokens.players [i].isBot ()) {
				GameObject human = playerObj [i].transform.Find ("Human").gameObject;
				GameObject bot = playerObj [i].transform.Find ("Bot").gameObject;

				human.SetActive (false);
				bot.SetActive (true);
			}
		}
	}
}
