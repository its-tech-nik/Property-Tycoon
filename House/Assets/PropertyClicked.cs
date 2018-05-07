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
		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log (Parent.name + "\t" + click);
			List<Property> properties = Game.players [Game.currentPlayer].GetProperties ();
			bool didit = false;

			int index = 0;
			foreach (Property p in properties) {
				if (p.GetGroup ().Equals (Parent.name)) {
					Debug.Log (Parent.name + "\t" + click);
					if (index == click) {
						pname = p.GetName ();

						if (PropertyDisplay.image2.gameObject.activeInHierarchy) {
							if (!PropertyDisplay.image2.sprite.name.Equals (pname)) {
								
								PropertyDisplay.doit (1);

								if (PropertyDisplay.imageOther2.gameObject.activeInHierarchy) {
									PropertyDisplay.imageOther2.gameObject.SetActive (false);
								}
								didit = true;
							} else {
								//PropertyDisplay.doit (3);
								PropertyDisplay.image2.gameObject.SetActive (false);
							}
						} else if (!PropertyDisplay.image2.gameObject.activeInHierarchy) {
							didit = true;
							PropertyDisplay.doit (1);
							PropertyDisplay.image2.gameObject.SetActive (true);
						}
					}
					index++;
				}
			}

			if(TradeManager.IsTrading && !PropertyDisplay.image2.gameObject.activeInHierarchy) {
				properties = Game.players [TradeManager.PlayerToTrade].GetProperties ();
				index = 0;
				foreach (Property p in properties) {
					if (p.GetGroup ().Equals (Parent.name)) {
						Debug.Log (Parent.name + "\t" + click);
						if (index == click) {
							pname = p.GetName ();

							if (PropertyDisplay.imageOther2.gameObject.activeInHierarchy) {
								if (!PropertyDisplay.imageOther2.sprite.name.Equals (pname)) {
									PropertyDisplay.doit (2);
								} else {
									PropertyDisplay.imageOther2.gameObject.SetActive (false);
								}
							} else if (!PropertyDisplay.imageOther2.gameObject.activeInHierarchy) {
								//PropertyDisplay.doit (2);
								PropertyDisplay.imageOther2.gameObject.SetActive (true);
							}
						}
						index++;
					}
				}
			}

		} else if(Input.GetMouseButtonDown (1) && TradeManager.IsTrading) {
			Debug.Log ("RIGHT CLICK");

			int index = 0;
			foreach (Property p in Game.players[Game.currentPlayer].GetProperties()) {
				if (p.GetGroup ().Equals (Parent.name)) {
					Debug.Log ("Current:\t" + p.GetName());
					if (index == click) {
						pname = p.GetName ();

						TradeManager.currentPlayer.Add (p);

						/*if (PropertyDiplaye.image2.gameObject.activeInHierarchy && PropertyDiplaye.image2.sprite.name.Equals (pname)) {
							PropertyDiplaye.image2.gameObject.SetActive (false);
						} else if (!PropertyDiplaye.image2.gameObject.activeInHierarchy) {
							PropertyDiplaye.image2.gameObject.SetActive (true);
						}*/
						TradeManager.doit = true;
					}
					index++;
				}
			}

			index = 0;
			foreach (Property p in Game.players[TradeManager.PlayerToTrade].GetProperties()) {
				if (p.GetGroup ().Equals (Parent.name)) {
					Debug.Log ("Other:\t" + p.GetName());
					if (index == click) {
						pname = p.GetName ();

						TradeManager.otherPlayer.Add (p);

						/*if (PropertyDiplaye.image2.gameObject.activeInHierarchy && PropertyDiplaye.image2.sprite.name.Equals (pname)) {
							PropertyDiplaye.image2.gameObject.SetActive (false);
						} else if (!PropertyDiplaye.image2.gameObject.activeInHierarchy) {
							PropertyDiplaye.image2.gameObject.SetActive (true);
						}*/
						//BuildingManager.needsUpdate = true;
						TradeManager.doit = true;
					}
					index++;
				}
			}

		}
	}

	public void OnRightPointerDown(PointerEventData eventData) {

	}
}
