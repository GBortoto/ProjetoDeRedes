using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	bool powerUpOn = false;
	bool updating = false;

	public float orbitRadius;
	public float frequency;
	public float nObjects;

	public GameObject powerUpPrefab;

	private GameObject[] powerUp;
	private Transform[] positions;


	IEnumerator SpawnBoxes(){
		Vector3 myPosition = transform.position;
		for(int i=0; i<nObjects; i++){
			//Debug.Log ("Spawning - " + i);
			powerUp[i] = (GameObject) Instantiate (powerUpPrefab, myPosition, transform.rotation, gameObject.transform);
			powerUp [i].GetComponent<RotatePowerUps> ().offset = (360f/nObjects)*i;
			//Debug.Log (360f / (orbitDegreesPerSec * nObjects));
			//yield return new WaitForSeconds ( 360f / (orbitDegreesPerSec * nObjects));
		}
		updating = false;
		yield return null;
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
		powerUp = new GameObject[(int)nObjects];
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("x")){
			//Debug.Log ("1");
			if (!powerUpOn) {
				//Debug.Log ("2");
				powerUpOn = true;
				updating = true;
				turnOnPowerUp ();
			} else if(powerUpOn && !updating){
				//Debug.Log ("3");
				powerUpOn = false;
				turnOffPowerUp();
			}

		}
	}
		
}