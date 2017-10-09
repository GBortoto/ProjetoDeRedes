using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraUtilities : MonoBehaviour {

	public static bool checkPress(string key){
		string tmp = Input.inputString;
		if(tmp.Equals(key)){
			return true;
		}
		return false;
	}
}
