using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour {

	public Text[] properties;
	public GameObject[] propertiesColorred;

	public Text MoneyDisplay;

	public static bool needsUpdate;

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

			foreach (GameObject g in propertiesColorred) {
				for (int i = 0; i < g.transform.childCount; i++) {
					g.transform.GetChild (i).gameObject.SetActive (false);
				}
			}

			foreach(Property p in owned) {
				foreach(GameObject g in propertiesColorred) {
					if(g.name.Equals(p.GetGroup())) {
						for(int i = 0; i < g.transform.childCount; i++) {
							if(!g.transform.GetChild (i).gameObject.activeSelf) {
								g.transform.GetChild (i).gameObject.SetActive (true);
								break;
							}
						}
					}
				}

				if(index < owned.Count && index < properties.Length) {
					properties [index].text = p.GetName ();
					index++;
				}
			}



			for(int i = owned.Count; i < properties.Length; i++) {
				properties [i].text = "";
			}

			needsUpdate = false;

			string money = Game.players [Game.currentPlayer].GetMoney ().ToString ();

			MoneyDisplay.text = money;
		}
	}
}
