using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpCooldown : MonoBehaviour {

	public GameObject powerUp;

	public void consumePowerUp(){
		StartCoroutine (beConsumed());
	}

	IEnumerator beConsumed(){
		powerUp.SetActive (false);
		yield return new WaitForSeconds (3f);
		powerUp.SetActive (true);
	}

}
