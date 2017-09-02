using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour {

	private Color currentColor;
	private Color finalColor;
	private Renderer rend;
	public float defaultSpeed = 10f;
	private bool updateRGB = false;
	private bool doneR = true;
	private bool doneG = true;
	private bool doneB = true;
	public float gap = 0.1f;
	[SerializeField] Light playerLight;


	private int currentPowerUp = 0;


	void Start() {
		rend = GetComponent<Renderer> ();
		playerLight = gameObject.GetComponent<Light> ();
	}

	// Update is called once per frame
	void Update () {
		updatePlayerColor ();
	}


	public void Red(){
		changeColor (Color.red, defaultSpeed);

	}
	public void Blue(){
		changeColor (Color.blue, defaultSpeed);

	}
	public void Green(){
		changeColor (Color.green, defaultSpeed);

	}
	public void Yellow(){
		changeColor (Color.yellow, defaultSpeed);

	}




	public void changeColor(Color color, float speed = 10f){
		if(rend == null){
			rend = GetComponent<Renderer> ();
		}

		if(updateRGB){
			return;
		}

		currentColor = rend.material.color;
		finalColor = color;
		gap = 0.01f * speed;
		updateRGB = true;
		doneR = false;
		doneG = false;
		doneB = false;

		//Debug.Log (this.tag.ToString() + " | Changing color");
		//Debug.Log ("Changing color from (" + currentColor.ToString() + ") to (" + finalColor.ToString() + ")");
	}



	void updatePlayerColor(){
		if(updateRGB){
			updatePlayerRGB();
		}
	}

	public bool isChanging(){
		return updateRGB;
	}


	void updatePlayerRGB(){
		if(!doneR){
			//Debug.Log ("currentColor.r = " + currentColor.r);
			//Debug.Log ("finalColor.r = " + currentColor.r);
			if (currentColor.r + gap >= finalColor.r && currentColor.r <= finalColor.r) {
				currentColor.r = finalColor.r;
				doneR = true;
				//Debug.Log ("DoneR");	
			} else if (currentColor.r - gap <= finalColor.r && currentColor.r >= finalColor.r) {
				currentColor.r = finalColor.r;
				doneR = true;
				//Debug.Log ("DoneR");
			} else {
				if (currentColor.r > finalColor.r) {
					currentColor.r = currentColor.r - gap;
				} else if (currentColor.r < finalColor.r) {
					currentColor.r = currentColor.r + gap;
				}
			}
		}

		if(!doneG){
			//Debug.Log ("currentColor.g = " + currentColor.g);
			//Debug.Log ("finalColor.g = " + currentColor.g);
			if (currentColor.g + gap >= finalColor.g && currentColor.g <= finalColor.g) {
				currentColor.g = finalColor.g;
				doneG = true;
				//Debug.Log ("DoneG");	
			} else if (currentColor.g - gap <= finalColor.g && currentColor.g >= finalColor.g) {
				currentColor.g = finalColor.g;
				doneG = true;
				//Debug.Log ("DoneG");
			} else {
				if (currentColor.g > finalColor.g) {
					currentColor.g = currentColor.g - gap;
				} else if (currentColor.g < finalColor.g) {
					currentColor.g = currentColor.g + gap;
				}
			}
		}

		if(!doneB){
			//Debug.Log ("currentColor.b = " + currentColor.b);
			//Debug.Log ("finalColor.b = " + currentColor.b);
			if (currentColor.b + gap >= finalColor.b && currentColor.b <= finalColor.b) {
				currentColor.b = finalColor.b;
				doneB = true;
				//Debug.Log ("doneB");	
			} else if (currentColor.b - gap <= finalColor.b && currentColor.b >= finalColor.b) {
				currentColor.b = finalColor.b;
				doneB = true;
				//Debug.Log ("doneB");
			} else {
				if (currentColor.b > finalColor.b) {
					currentColor.b = currentColor.b - gap;
				} else if (currentColor.b < finalColor.b) {
					currentColor.b = currentColor.b + gap;
				}
			}
		}

		if(doneR && doneG && doneB){
			updateRGB = false;
		}

		rend.material.color = currentColor;
		playerLight.color = currentColor;
	}
}
