using UnityEngine;
using System.Collections;

public class ControlTriggersDialogos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider coli){
		if (coli.gameObject.name == "Prota_TEAPlay") {
			if (gameObject.name == "Trigger_HablaConDINO") {	
				GameObject.Find ("Dino_Mascota").GetComponent<controlMascota> ().enabled = true;
			}
		}
	} 
}
