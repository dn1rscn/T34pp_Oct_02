using UnityEngine;
using System.Collections;

public class control_triggersPosicion : MonoBehaviour {

	ControlDatosGlobales_Mundo3D CDG_Mundo3D;


	// Use this for initialization
	void Start () {
		//ACCEDEMOS AL SCRIPT DE DATOS GLOBALES
		CDG_Mundo3D = GameObject.Find("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D>();

		gameObject.GetComponent<NavMeshAgent>().enabled=false;
		GameObject grupoSuperiorProta = transform.parent.gameObject;

		switch (CDG_Mundo3D.posicionPersonaje) {
		case 3:
		{
			//posicionFinal
			grupoSuperiorProta.transform.position = GameObject.Find ("posicionInicialProta_03").transform.position;
			
			break;
		}	
		case 2:
		{	//posicionMedia
			grupoSuperiorProta.transform.position = GameObject.Find ("posicionInicialProta_02").transform.position;
			break;
			
		}	
		case 1:
		{	//posicionInicial
			grupoSuperiorProta.transform.position = GameObject.Find ("posicionInicialProta_01").transform.position;
			
			break;
		}
		default: 
		{
			break;
		}
		}


		gameObject.GetComponent<NavMeshAgent>().enabled=true;


	}
	
	void OnTriggerEnter(Collider coli){
		print (coli.gameObject.name);

		switch (coli.gameObject.name)
		{
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
