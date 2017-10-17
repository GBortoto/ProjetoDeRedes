using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : NetworkBehaviour {

	public GameObject player;
	private bool isInitialized;
	//private Vector3 defaultOffset = new Vector3(6f, 2.5f, -10f);
	private Vector3 defaultOffset = new Vector3(6f, 4f, -20f);
	private Quaternion defaultRotation = new Quaternion ();

	private Vector3 movementLeft = new Vector3 (0f, 0f, 0f);
	private Vector3 nextPosition;
	[SerializeField] private float smoothness = 10f;

	//[SyncVar] public string cameraName;


	void Awake(){
		gameObject.SetActive (false);
	}
		
	public void setPlayer(GameObject player){
		this.player = player;
		gameObject.name = "Camera - " + player.name;
		gameObject.SetActive (true);
		start ();
	}

	//[Command]



	// Método start manual
	void start () {
		if (player) {
			if (player.GetComponent<PlayerNetworkController> ().isLocalPlayer) {
				gameObject.SetActive (true);
			}
			Vector3 nextPosition = new Vector3 (player.transform.position.x + defaultOffset.x, defaultOffset.y, defaultOffset.z);
			transform.position = nextPosition;

			transform.rotation = defaultRotation;
		} else {
			gameObject.SetActive (false);
		}
	}




	// Update is called once per frame
	void Update () {
		if(player){
			if(!player.GetComponent<PlayerNetworkController> ().isLocalPlayer){
				gameObject.SetActive (false);
			}
		} else {
			gameObject.SetActive(false);
		}

		if(player == null){
			return;
		}



		if(!isInitialized && player){
			Vector3 nextPosition = new Vector3(player.transform.position.x + defaultOffset.x, defaultOffset.y, defaultOffset.z);
			transform.position = nextPosition;
			isInitialized = true;
		}

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