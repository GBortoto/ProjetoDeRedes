using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerUp : MonoBehaviour {

	GameObject player;
	float orbitDegreesPerSec;
	float orbitDistance;

	// Use this for initialization
	void Start () {

		Debug.Log ("Estou vivo!");
		player = GameObject.FindGameObjectWithTag ("Player");
		orbitDistance = player.GetComponent<PowerUps> ().orbitSize;
		orbitDegreesPerSec = player.GetComponent<PowerUps> ().orbitDegreesPerSec;
		//Debug.Log (player.name);

		transform.position = player.transform.position + new Vector3 (0f, orbitDistance, 0f);

		//transform.position = (transform.position - player.transform.position).normalized * orbitDistance + player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Orbit ();
	}

	void Orbit(){

		transform.RotateAround (player.transform.position, Vector3.forward, orbitDegreesPerSec * Time.deltaTime);
		//var desiredPosition = (transform.position - player.transform.position).normalized * orbitDistance + player.transform.position;
		//transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

		/*

		//transform.RotateAround (player.transform.position, Vector3.forward, orbitDegreesPerSec * Time.deltaTime);
		transform.position = player.transform.position + (transform.position - player.transform.position).normalized * orbitDistance;
		transform.RotateAround(player.transform.position, Vector3.forward, orbitDegreesPerSec * Time.deltaTime);
		*/
	}
}
