using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour {

	//[SerializeField] Material color;

	public Color currentColor = Color.white;
	public Color finalColor = Color.cyan;
	public Renderer rend;



	bool updateRGB = true;
	bool doneR = false;
	bool doneG = false;
	bool doneB = false;

	float gap = 0.1f;

	void Start() {
		rend = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		///Debug.Log ("Update");
		//Debug.Log ("currentColor = " + currentColor.ToString());

		updatePlayerColor ();



	}

	void changeColor(Color color, int speed){
		currentColor = rend.material.color;
	}



	void updatePlayerColor(){
		
	}



	void updatePlayerRGB(){
		if(!updateRGB){
			return;
		}
		if(!doneR){
			//Debug.Log ("currentColor.r = " + currentColor.r);
			//Debug.Log ("finalColor.r = " + currentColor.r);
			if (currentColor.r + gap >= finalColor.r && currentColor.r <= finalColor.r) {
				currentColor.r = finalColor.r;
				doneR = true;
				Debug.Log ("DoneR");	
			} else if (currentColor.r - gap <= finalColor.r && currentColor.r >= finalColor.r) {
				currentColor.r = finalColor.r;
				doneR = true;
				Debug.Log ("DoneR");
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
				Debug.Log ("DoneG");	
			} else if (currentColor.g - gap <= finalColor.g && currentColor.g >= finalColor.g) {
				currentColor.g = finalColor.g;
				doneG = true;
				Debug.Log ("DoneG");
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
				Debug.Log ("doneB");	
			} else if (currentColor.b - gap <= finalColor.b && currentColor.b >= finalColor.b) {
				currentColor.b = finalColor.b;
				doneB = true;
				Debug.Log ("doneB");
			} else {
				if (currentColor.b > finalColor.b) {
					currentColor.b = currentColor.b - gap;
				} else if (currentColor.b < finalColor.b) {
					currentColor.b = currentColor.b + gap;
				}
			}
		}

		rend.material.color = currentColor;
	}
}
