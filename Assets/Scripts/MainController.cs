using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	[SerializeField] ColorHandler Player1;
	[SerializeField] ColorHandler Player2;


	// Use this for initialization
	void Start () {
		//StartCoroutine (flashColors ());
		Player1.Blue();
	}

	IEnumerator flashColors(){

		yield return new WaitForSeconds (2);

		int counter = 0;

		while(counter < 1){
			while(Player1.isChanging()){
				yield return null;
			}
			Player1.changeColor (Color.red, 5);

			while(Player1.isChanging()){
				yield return null;
			}

			yield return new WaitForSeconds (2);

			Player1.changeColor (Color.blue, 5);
			counter++;
		}
		yield break;
	}

	void Update () {
		if(ExtraUtilities.checkPress("z")){
			Player1.Red ();
		}
		if(ExtraUtilities.checkPress("x")){
			Player1.Green ();
		}
		if(ExtraUtilities.checkPress("c")){
			Player1.Blue ();
		}
		if(ExtraUtilities.checkPress("v")){
			Player1.Yellow ();
		}



	}

}