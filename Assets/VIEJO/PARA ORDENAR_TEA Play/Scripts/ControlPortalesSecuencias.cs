using UnityEngine;
using System.Collections;

public class ControlPortalesSecuencias : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision coli)
	{
		if (coli.gameObject.name == "Prota_TEAPlay") 
		{
			Application.LoadLevel ("menu_select_emociones");
		}
	}
}
