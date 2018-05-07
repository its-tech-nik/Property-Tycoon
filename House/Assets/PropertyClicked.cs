using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required when using Event data.
using UnityEngine.UI;

public class PropertyClicked : MonoBehaviour, IPointerDownHandler {

	public GameObject Parent;
	public int click = 0;

	public static string pname = "";
	public static int no = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnPointerDown (PointerEventData eventData) {
		//Debug.Log (Parent.name + "\t" + click);

		List<Property> properties = Game.players[Game.currentPlayer].GetProperties();
		int index = 0;
		foreach(Property p in properties) {
			if(p.GetGroup().Equals(Parent.name)) {
				if(index == click) {
					pname = p.GetName ();

					if (PropertyDiplaye.image2.gameObject.activeInHierarchy && PropertyDiplaye.image2.sprite.name.Equals (pname)) {
						PropertyDiplaye.image2.gameObject.SetActive (false);
					} else if (!PropertyDiplaye.image2.gameObject.activeInHierarchy) {
						PropertyDiplaye.image2.gameObject.SetActive (true);
					}
					BuildingManager.needsUpdate = true;
				}
				index++;
			}
		}
	}
}
