using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSpace : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {
		player = other.gameObject;
		Debug.Log (player.name + " Entrou");
	}

	void OnTriggerExit(Collider other){
		player = other.gameObject;
		Debug.Log (player.name + " Saiu");
	}


	// Update is called once per frame
	void Update () {
		
	}
}
