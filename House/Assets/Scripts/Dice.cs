using UnityEngine;

public class Dice {

	private int[] Die;
	private bool doneRolling;
	private bool doubles;

	public Dice() {
		Die = new int[2];
		doneRolling = false;
		doubles = false;
	}

	public int[] Roll() {
		Die[0] = Random.Range(1, 7);
		Die[1] = Random.Range(1, 7);

		if(Die[0] == Die[1]) {
			doubles = true;
		}

		return Die;
	}

	public bool IsDoubles() {
		return doubles;
	}

	public bool IsDoneRolling() {
		return doneRolling;
	}

	public int GetDie(int die) {
		return Die [die];
	}

	public int GetRoll() {
		return Die[0] + Die[1];
	}
}
