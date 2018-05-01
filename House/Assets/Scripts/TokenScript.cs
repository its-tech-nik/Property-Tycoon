using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour {

	public GameObject StartingTile;
	public float extraPositioning;

	private GameObject currentTile;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void move() {
		//Vector3 pos = new Vector3 (StartingTile.transform.position.x, StartingTile.transform.position.y, StartingTile.transform.position.z);

		Vector3 move = new Vector3 (1, 0, 0);

		this.transform.Translate (move);

		//Debug.Log (StartingTile.name + ": " + this.transform.position + "\tStartingTile: " + StartingTile.transform.position);
	}
}
