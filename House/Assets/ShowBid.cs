using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class ShowBid : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // required interface when using the OnPointerDown method.
{
	public InputField bidField;

	public void OnPointerDown (PointerEventData eventData) {
		Debug.Log ("Clicked.");
		bidField.gameObject.SetActive (true);
	}

	public void OnPointerUp (PointerEventData eventData) {
		Debug.Log ("Unclicked.");
		bidField.gameObject.SetActive (false);
	}
}
