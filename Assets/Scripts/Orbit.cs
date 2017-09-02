using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public float offset = 0f;
	public float radius = 1f;
	public float frequency = 1f;

	private Vector3 originalPosition = new Vector3 ();
	private Vector3 nextPosition = new Vector3 ();

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		nextPosition.x = originalPosition.x + Mathf.Sin (Time.fixedTime * Mathf.PI * frequency + (offset*Mathf.PI/180)) * radius;
		nextPosition.y = originalPosition.y + Mathf.Sin (Time.fixedTime * Mathf.PI * frequency + (offset*Mathf.PI/180) + (Mathf.PI/2)) * radius;
		nextPosition.z = transform.position.z;
		transform.position = nextPosition;
	}
}
