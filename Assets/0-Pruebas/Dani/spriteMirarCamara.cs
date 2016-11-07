using UnityEngine;
using System.Collections;

public class spriteMirarCamara : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void LateUpdate (){
		transform.forward=Camera.main.transform.forward;
	}
}
