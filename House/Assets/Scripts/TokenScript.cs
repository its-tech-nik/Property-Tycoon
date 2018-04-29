using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour {

	public GameObject StartingTile;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void move() {

		Vector3 pos = new Vector3 (StartingTile.transform.position.x, StartingTile.transform.position.y, StartingTile.transform.position.z);

		this.transform.position = new Vector3(0, 0, 0);
		this.transform.position = pos;

		Debug.Log ("This: " + this.transform.position + "\tStartingTile: " + StartingTile.transform.position);
	}
}
