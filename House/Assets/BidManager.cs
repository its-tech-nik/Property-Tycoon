using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BidManager : MonoBehaviour {

	public InputField bidDisplay;
	public Button[] bids;

	public void SetBid(string bid) {
		bidDisplay.text = bid;
	}
}
