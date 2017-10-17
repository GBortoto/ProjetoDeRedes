using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkController : NetworkBehaviour {


	[SyncVar]
	public string playerName;


	[SerializeField]
	Behaviour[] componentsToDisable;
	Camera sceneCamera;

	public GameObject cameraPrefab;

	private GameObject minhaCamera;


	public override void OnStartLocalPlayer(){
		base.OnStartLocalPlayer ();
		string newName = "Player " + gameObject.GetComponent<PlayerNetworkController> ().netId.ToString ();
		ChangeName (newName);
		SpawnNewCamera();
	}



	//[Command]
	public void ChangeName(string newName){
		playerName = newName;
		gameObject.name = newName;
		Debug.Log ("Name changed in the server to \"" + gameObject.name + "\"");
	}


	//[Command]
	void SpawnNewCamera(){
		Debug.Log ("Called by the player: " + gameObject);
		GameObject newCamera = (GameObject) Instantiate (cameraPrefab, gameObject.transform.position, gameObject.transform.rotation);
		newCamera.GetComponent<PlayerCamera> ().setPlayer (gameObject);
		minhaCamera = newCamera;
		if(!isServer){
			return;
		}
		NetworkServer.Spawn (newCamera);
	}





	void Start(){
		//Debug.Log ("Player Start function");

		// Disables elements and disables sceneCamera
		if (!isLocalPlayer) {
			for (int i = 0; i < componentsToDisable.Length; i++) {
				componentsToDisable [i].enabled = false;
			}
		} else {
			sceneCamera = Camera.main;
			if(sceneCamera != null){
				sceneCamera.gameObject.SetActive (false);
			}
		}
			
	}


	void OnDisable(){
		if(sceneCamera != null){
			sceneCamera.gameObject.SetActive (true);
		}
		Destroy (minhaCamera);
	}
}
