using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyDisplay : MonoBehaviour {

	public Sprite[] sprites;
	public static Sprite[] sprites2;

	public Image image;
	public static Image image2;

	public Image imageOther;
	public static Image imageOther2;

	public static Sprite empty;

	// Use this for initialization
	void Start () {
		sprites2 = sprites;
		image2 = image;
		imageOther2 = imageOther;
		empty = image.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void doit(int i) {
		foreach(Sprite s in sprites2) {
			if(s.name.Equals(PropertyClicked.pname)) {

				if (!TradeManager.IsTrading) {
					image2.sprite = s;
					//imageOther2.sprite = s;
					//PropertyDisplay.image2.gameObject.SetActive (false);
					//image2.sprite = empty;
				} else {

					if (i == 1) {
						image2.sprite = s;
						PropertyDisplay.imageOther2.gameObject.SetActive (false);

					} else if(i == 2) {
						imageOther2.sprite = s;
						PropertyDisplay.image2.gameObject.SetActive (false);
					} else if(i == 3) {
						image2.gameObject.SetActive (false);
					}

					//imageOther2.sprite = empty;
				}
			}
		}
	}
}
