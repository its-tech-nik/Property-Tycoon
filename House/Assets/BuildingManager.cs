using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour {

	public Text[] properties;

	public Text MoneyDisplay;

	public static bool needsUpdate;
	public static int iterations = 0;

	// Use this for initialization
	void Start () {
		needsUpdate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(needsUpdate) {
			int currentPlayer = Game.currentPlayer;
			List<Property> owned = Game.players [currentPlayer].GetProperties ();

			int index = 0;

			foreach(Property p in owned) {
				if(index < owned.Count && index < properties.Length) {
					properties [index].text = p.GetName ();
					index++;
				}
			}

			for(int i = owned.Count; i < properties.Length; i++) {
				properties [i].text = "";
			}

			needsUpdate = false;

			if(iterations < 5) {
				needsUpdate = true;
				iterations++;
			}

			if(iterations == 5) {
				iterations = 0;
			}

			string money = Game.players [Game.currentPlayer].GetMoney ().ToString ();

			MoneyDisplay.text = money;
		}
	}
}
