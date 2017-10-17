using UnityEngine;
using UnityEngine.Networking;

public class PrefabsManager : NetworkBehaviour {
	public GameObject powerUpPrefab_Vermelho;
	public GameObject powerUpPrefab_Verde;
	public GameObject powerUpPrefab_Azul;
	public GameObject powerUpPrefab_Amarelo;

	public override void OnStartServer()
	{
		GameObject[] locaisDeSpawn = GameObject.FindGameObjectsWithTag ("LocalDeSpawn-PowerUp");

		for (int i=0; i < locaisDeSpawn.Length; i++){
			
			int powerUpToBeSpawnedID = locaisDeSpawn[i].GetComponent<powerUpToBeSpawned>().powerUpToBeSpawnedID;

			GameObject enemy = null;

			if(powerUpToBeSpawnedID == 1){
				enemy = (GameObject)Instantiate(powerUpPrefab_Vermelho, locaisDeSpawn[i].transform.position, locaisDeSpawn[i].transform.rotation);
			}
			if(powerUpToBeSpawnedID == 2){
				enemy = (GameObject)Instantiate(powerUpPrefab_Verde, locaisDeSpawn[i].transform.position, locaisDeSpawn[i].transform.rotation);
			}
			if(powerUpToBeSpawnedID == 3){
				enemy = (GameObject)Instantiate(powerUpPrefab_Azul, locaisDeSpawn[i].transform.position, locaisDeSpawn[i].transform.rotation);
			}
			if(powerUpToBeSpawnedID == 4){
				enemy = (GameObject)Instantiate(powerUpPrefab_Amarelo, locaisDeSpawn[i].transform.position, locaisDeSpawn[i].transform.rotation);
			}

			if(enemy){
				NetworkServer.Spawn(enemy);
			}
		}
	}
}