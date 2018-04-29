using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour {

	private string[] names;

	public Text player1;

	public GameObject[] boardGraphics;

	public Tile[] board = new Tile[40];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setNames(string[] names) {
		this.names = names;
		player1.text = names [0];
	}

	public string[] getNames() {
		return names;
	}
}
