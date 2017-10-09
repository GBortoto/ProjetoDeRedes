using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	int maxNObjects = 6;				// Número máximo de spawns de objetos
	bool powerUpOn = false;				// Existe algum power up ativo?
	bool updating = false;				// Já existe um processo de spawning acontecendo?

	// Referência para os prefabs de cada power up
	public GameObject powerUpPrefab_Vermelho;
	public GameObject powerUpPrefab_Verde;
	public GameObject powerUpPrefab_Azul;
	public GameObject powerUpPrefab_Amarelo;

	private GameObject[] powerUp;		// Array dos objetos no power up


	// Responsável por chamar o spawn certo para cada power up
	void turnOnPowerUp(int powerUpOption){
		if(powerUpOption == 1){
			StartCoroutine(SpawnBoxes (powerUpPrefab_Vermelho));
		}
		if(powerUpOption == 2){
			StartCoroutine(SpawnBoxes (powerUpPrefab_Verde));
		}
		if(powerUpOption == 3){
			StartCoroutine(SpawnBoxes (powerUpPrefab_Azul));
		}
		if(powerUpOption == 4){
			StartCoroutine(SpawnBoxes (powerUpPrefab_Amarelo));
		}
	}

	// Responsável por matar os spawns nos power ups
	void turnOffPowerUp(){
		for(int i=0; i<maxNObjects; i++){
			if(powerUp[i]){
				Destroy (powerUp[i]);
			}
		}
	}

	// ESTE É O MÉTODO PÚBLICO QUE DEVE SER CHAMADO - Faz tudo
	public void setPowerUp(int powerUpOption){
		// Se não estiver ligado
		if (!powerUpOn) {
			powerUpOn = true;
			updating = true;
			turnOnPowerUp (powerUpOption);
		// Se estiver ligado e não estiver sendo criado
		} else if (powerUpOn && !updating) {
			powerUpOn = false;
			turnOffPowerUp ();

			powerUpOn = true;
			updating = true;
			turnOnPowerUp (powerUpOption);
		}
	}
		
	// Método de spawn
	IEnumerator SpawnBoxes(GameObject powerUpPrefab){
		float nObjects = powerUpPrefab.GetComponent<RotatePowerUps>().nObjects;

		Debug.Log (nObjects);

		Vector3 myPosition = transform.position;
		for(int i=0; i<nObjects; i++){
			//Debug.Log ("Spawning - " + i);
			powerUp[i] = (GameObject) Instantiate (powerUpPrefab, myPosition, transform.rotation, gameObject.transform);
			powerUp[i].GetComponent<RotatePowerUps>().offset = (360f/nObjects)*i;
			powerUp[i].GetComponent<RotatePowerUps>().player = gameObject;
			//Debug.Log (360f / (orbitDegreesPerSec * nObjects));
			//yield return new WaitForSeconds ( 360f / (orbitDegreesPerSec * nObjects));
		}
		updating = false;
		yield return null;
	}
		

	void Start () {
		powerUp = new GameObject[maxNObjects];
	}
}