using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	bool powerUpOn = false;

	public float orbitSize = 1f;
	public float orbitDegreesPerSec = 180.0f;

	public GameObject powerUpPrefab;

	GameObject[] powerUp;

	IEnumerator SpawnBoxes(){
		Vector3 myPosition = transform.position;
		for(int i=0; i<3; i++){
			powerUp[i] = (GameObject)Instantiate (powerUpPrefab, myPosition, transform.rotation, gameObject.transform);			
			yield return new WaitForSeconds (1);
		}
	}

	void turnOnPowerUp(){
		StartCoroutine(SpawnBoxes ());
	}

	void turnOffPowerUp(){
		for(int i=0; i<powerUp.Length; i++){
			Destroy (powerUp[i]);
		}
	}


	// Use this for initialization
	void Start () {
		powerUp = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () {
		if(checkPress("p")){
			if (powerUpOn) {
				powerUpOn = false;
				turnOffPowerUp ();
				Debug.Log ("Power up OFF");
			} else {
				powerUpOn = true;
				turnOnPowerUp ();
				Debug.Log ("Power up ON");
			}

		}
	}

	bool checkPress(string key){
		string tmp = Input.inputString;
		if(tmp.Equals(key)){
			return true;
		}
		return false;
	}
}
