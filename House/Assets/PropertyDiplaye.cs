using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyDiplaye : MonoBehaviour {

	public Sprite[] sprites;
	public static Sprite[] sprites2;

	public Image image;
	public static Image image2;

	// Use this for initialization
	void Start () {
		sprites2 = sprites;
		image2 = image;
	}
	
	// Update is called once per frame
	void Update () {
		if(BuildingManager.needsUpdate) {
			doit ();
		}
	}

	public static void doit() {
		foreach(Sprite s in sprites2) {
			if(s.name.Equals(PropertyClicked.pname)) {
				image2.sprite = s;
			}
		}
	}
}
