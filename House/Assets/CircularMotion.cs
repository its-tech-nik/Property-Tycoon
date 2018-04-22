using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour {

	public GameObject Cube;
	public float speed;

	void Start() {
	}

	void Update() {
		orbitAround ();
	}

	void orbitAround() {
		transform.RotateAround (Cube.transform.position, Vector3.down, speed * Time.deltaTime);
	}



}
