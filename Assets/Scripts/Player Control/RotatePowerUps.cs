using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerUps : MonoBehaviour {

	private GameObject player;

	public float offset;
	public float orbitRadius;
	public float frequency;
	public float nObjects;

	private Vector3 originalPosition = new Vector3 ();
	private Vector3 nextPosition = new Vector3 ();

	// Use this for initialization
	void Start () {
		Debug.Log ("Estou vivo!");

		player = GameObject.FindGameObjectWithTag ("Player");

		originalPosition = player.transform.position;

		this.orbitRadius = player.GetComponent<PowerUps> ().orbitRadius;

		this.frequency = player.GetComponent<PowerUps> ().frequency;

		this.nObjects = player.GetComponent<PowerUps> ().nObjects;
	}


	// Update is called once per frame
	void Update () {
		originalPosition = player.transform.position;
		nextPosition.x = originalPosition.x + Mathf.Sin (Time.fixedTime * Mathf.PI * frequency + (offset*Mathf.PI/180)) * orbitRadius;
		nextPosition.y = originalPosition.y + Mathf.Sin (Time.fixedTime * Mathf.PI * frequency + (offset*Mathf.PI/180) + (Mathf.PI/2)) * orbitRadius;
		nextPosition.z = transform.position.z;
		transform.position = nextPosition;
	}
}