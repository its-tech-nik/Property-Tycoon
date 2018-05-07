using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeManager : MonoBehaviour {

	public static int PlayerToTrade = -1;
	public static bool IsTrading = false;

	public static List<Property> currentPlayer;
	public Text[] currentPlayerText;

	public static List<Property> otherPlayer;
	public Text[] otherPlayerText;

	public static bool doit = false;

	// Use this for initialization
	void Start () {
		Debug.Log ("TRADEMANAGER");
	}
	
	// Update is called once per frame
	void Update () {
		if(doit) {
			Debug.Log ("Update the fields!");
			for(int i = 0; i < currentPlayer.Count; i++) {
				currentPlayerText [i].text = currentPlayer [i].GetName ();
				currentPlayerText [i].gameObject.SetActive (true);
			}
			doit = false;
		}
	}

	public void TradeWithPlayer(int number) {
		PlayerToTrade = number;

		currentPlayer = new List<Property> ();
		otherPlayer = new List<Property> ();

		IsTrading = true;

		BuildingManager.needsUpdate = true;
	}

	public void StopTrade() {
		IsTrading = false;
	}
}
