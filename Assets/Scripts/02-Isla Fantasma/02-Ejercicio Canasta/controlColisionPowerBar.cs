using UnityEngine;
using System.Collections;

public class controlColisionPowerBar : MonoBehaviour {

	public bool zonaAcierto;
	
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider coli)
	{
		if (coli.gameObject.name == "barra_ZonaAcierto") {
			zonaAcierto = true;
			//print ("Acierto: "+zonaAcierto);
		}
	}

	void OnTriggerExit(Collider coli)
	{
		if (coli.gameObject.name == "barra_ZonaAcierto") {
			zonaAcierto = false;
			//print ("Acierto: "+zonaAcierto);
		}
	}
}
