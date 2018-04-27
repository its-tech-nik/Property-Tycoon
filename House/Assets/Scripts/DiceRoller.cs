using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DiceValues = new int[2];
		doublesCounter = 0;
		doubles ();
	}

	// Update is called once per frame
	void Update () {

	}

	public int DiceTotal;
	private int[] DiceValues;
	public int doublesCounter;

	public void Roll() {
		
		if (doubles ()) {
			doublesCounter++;
		} else {
			doublesCounter = 0;
		}

		Debug.Log ("Total: " + DiceTotal + "\tCounter: " + doublesCounter);
	}

	public bool doubles() {
		int Die1 = Random.Range(1, 7);
		int Die2 = Random.Range(1, 7);
		bool doubles = false;
		DiceTotal = 0;

		if(Die1 == Die2) {
			doubles = true;
		}

		DiceTotal += Die1;
		DiceTotal += Die2;

		return doubles;
	}

	public void delete() {
		Debug.Log(DiceValues) ;
	}
}
