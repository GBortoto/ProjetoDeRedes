using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		GameObject player = other.gameObject;
        PlayerStatus classeDePlayer = other.gameObject.GetComponent (typeof(PlayerStatus)) as PlayerStatus;
		if (classeDePlayer != null) {
            classeDePlayer.death();
		}	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
