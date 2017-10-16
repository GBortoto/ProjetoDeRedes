using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraPrincipal : MonoBehaviour {

	private GameObject player;
	private Vector3 defaultOffset = new Vector3(6f, 2.5f, -10f);
	private Vector3 movementLeft = new Vector3 (0f, 0f, 0f);
	private Vector3 nextPosition;
	[SerializeField] private float smoothness = 10f;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Vector3 nextPosition = new Vector3(player.transform.position.x + defaultOffset.x, defaultOffset.y, defaultOffset.z);
		transform.position = nextPosition;
	}
	
	// Update is called once per frame
	void Update () {
		nextPosition = new Vector3(player.transform.position.x + defaultOffset.x, defaultOffset.y, defaultOffset.z);
		if(!transform.position.Equals(nextPosition)){
			movementLeft = new Vector3 (nextPosition.x - transform.position.x, 0f, 0f);
		}

		if(!movementLeft.Equals(Vector3.zero)){
			moveCamera ();
		}
	}

	void moveCamera(){
		transform.position = new Vector3(transform.position.x + (movementLeft.x / smoothness), transform.position.y, transform.position.z);
		//transform.position.x = transform.position.x + (movementLeft.x / smoothness);
		movementLeft.x = movementLeft.x - (movementLeft.x / smoothness);
		if(Mathf.Abs(movementLeft.x) < 0.01f){
			movementLeft.x = 0f;
		}

	}

}
