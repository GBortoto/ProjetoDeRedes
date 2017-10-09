using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpElement : MonoBehaviour {
	public int powerUpOption;

	public int getPowerUpOption(){
		return powerUpOption;
	}

	void Update(){
		transform.Rotate (new Vector3 (45, 30, 15) * Time.deltaTime);
	}
}
