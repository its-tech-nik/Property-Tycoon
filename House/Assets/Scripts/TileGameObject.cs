using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class TileGameObject : MonoBehaviour, IPointerDownHandler {

	public GameObject nextTile;
	//public Image image;

	// Use this for initialization
	void Start () {
		//Debug.Log (this.gameObject.name);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown (PointerEventData eventData) {
		Debug.Log ("Clicked tile.");
		List<Property> properties = Game.players[Game.currentPlayer].GetProperties();

		foreach(Property p in properties) {
			if(p.GetGroup().Equals(this.gameObject.name)) {
				if (PropertyDisplay.image2.gameObject.activeInHierarchy && PropertyDisplay.image2.sprite.name.Equals (this.gameObject.name)) {
					PropertyDisplay.image2.gameObject.SetActive (false);
				} else if (!PropertyDisplay.image2.gameObject.activeInHierarchy) {
					PropertyDisplay.image2.gameObject.SetActive (true);
				}
				BuildingManager.needsUpdate = true;
			}
		}
	}
}
