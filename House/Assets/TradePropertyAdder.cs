using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradePropertyAdder : MonoBehaviour {

	public List<GameObject> CurrentPlayerTradingProperties;
	private List<Property> CurrentPlayerTradingPropertiesP;


	public List<GameObject> OtherPlayerTradingProperties;
	private List<Property> OtherPlayerTradingPropertiesP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddAndShowTradingProperty(Property p) {
		if (Game.players [Game.currentPlayer].Equals (p.GetOwner ())) {
			// the current player owns this property
			CurrentPlayerTradingPropertiesP.Add(p);

			int i = CurrentPlayerTradingPropertiesP.Count;

			CurrentPlayerTradingProperties [i].GetComponent<InputField> ().text = p.GetName ();

			CurrentPlayerTradingProperties [i].SetActive (true);
		} else {
			// the other player owns this property
			OtherPlayerTradingPropertiesP.Add(p);

			int i = OtherPlayerTradingPropertiesP.Count;

			OtherPlayerTradingProperties [i].GetComponent<InputField> ().text = p.GetName ();

			OtherPlayerTradingProperties [i].SetActive (true);
		}
	}

	public void DeleteTradingProperty(Property p) {

		if (Game.players [Game.currentPlayer].Equals (p.GetOwner ())) {
			// the current player owns this property
			CurrentPlayerTradingPropertiesP.Add (p);
			int detetedIndex = CurrentPlayerTradingPropertiesP.IndexOf (p);
			CurrentPlayerTradingPropertiesP.Remove (p);

			int i = 0;
			foreach (GameObject g in CurrentPlayerTradingProperties) {
				string text = "";

				if (i < CurrentPlayerTradingPropertiesP.Count && detetedIndex != i) {
					text = CurrentPlayerTradingPropertiesP [i].GetName ();
					i++;
				}

				g.GetComponent<InputField> ().text = text;
			}

			//CurrentPlayerTradingProperties [i].SetActive (true);
		} else {
			// the other player owns this property
			CurrentPlayerTradingPropertiesP.Add (p);
			int detetedIndex = CurrentPlayerTradingPropertiesP.IndexOf (p);
			CurrentPlayerTradingPropertiesP.Remove (p);

			int i = 0;
			foreach (GameObject g in CurrentPlayerTradingProperties) {
				string text = "";

				if (i < CurrentPlayerTradingPropertiesP.Count && detetedIndex != i) {
					text = CurrentPlayerTradingPropertiesP [i].GetName ();
					i++;
				}

				g.GetComponent<InputField> ().text = text;
			}
		}
	}
}
