using UnityEngine;
using System.Collections;

public class controlHuevoDino : MonoBehaviour {

	ControlDatosGlobales_Mundo3D CDG_Mundo3D;

	
	// Use this for initialization
	void Start () {
		//ACCEDEMOS AL SCRIPT DE DATOS GLOBALES
		CDG_Mundo3D = GameObject.Find("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D>();
	}

	void OnTriggerEnter(Collider coli)
	{
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{

		}
	}

}
