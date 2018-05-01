using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour {

	public static bool GameStarted = false;
	public GameObject Cube;
	public float speed;

	void Start() {
	}

	void Update() {
		if (!GameStarted) {
			orbitAround ();
		} else {
			Quaternion rotation = Quaternion.Euler (-12.0f, 90.0f, 180.0f);
			Vector3 dir = new Vector3 (1, 1, 1);
			Vector3 v = new Vector3 (1, 22, 0);
			this.transform.position = v;// + rotation*dir;
			this.transform.LookAt (Cube.transform.position);

			this.gameObject.SetActive (false);

			/*Player p = Game.players [Game.currentPlayer];
			GameObject t = Game.Tokens [p.getToken()];

			Vector3 dir = new Vector3 (0, 1, -10);
			Quaternion rotation = Quaternion.Euler (45.0f, 90.0f, 180.0f);
			//Quaternion rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);

			this.transform.position = t.transform.position + rotation * dir;
			this.transform.LookAt (t.transform.position);*/
		}
	}

	public void StartGame() {
		GameStarted = true;
	}

	public void NoGame() {
		GameStarted = false;
	}

	void orbitAround() {
		transform.RotateAround (Cube.transform.position, Vector3.down, speed * Time.deltaTime);
	}



}
