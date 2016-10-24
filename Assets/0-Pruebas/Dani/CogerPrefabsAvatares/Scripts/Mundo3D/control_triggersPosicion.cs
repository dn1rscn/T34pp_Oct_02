using UnityEngine;
using System.Collections;

public class control_triggersPosicion : MonoBehaviour {

	ControlDatosGlobales_Mundo3D CDG_Mundo3D;


	// Use this for initialization
	void Start () {
		//ACCEDEMOS AL SCRIPT DE DATOS GLOBALES
		CDG_Mundo3D = GameObject.Find("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D>();

	}
	
	void OnTriggerEnter(Collider coli){
		print (coli.gameObject.name);
		if(coli.gameObject.name=="Prota_TEAPlay")
		{
			switch (gameObject.name){
			case "PosicionInicial" :
				CDG_Mundo3D.posicionPersonaje = 1;
				break;
			case "PosicionMedia":
				CDG_Mundo3D.posicionPersonaje = 2;
				break;
			case "PosicionFinal":
				CDG_Mundo3D.posicionPersonaje = 3;
				break;

			}

		}
	}
}
