using UnityEngine;
using System.Collections;

public class ControlCamara_Static : MonoBehaviour {

	//Control para que la camara siga al jugador desde una distancia fija.

	public GameObject jugador;
	Rigidbody rb_jugador;

	//ControlDatosGlobales_Mundo3D CDG_Mundo3D;
	
	private Vector3 offset;

	void Start ()
	{
		//ACCEDEMOS AL SCRIPT DE DATOS GLOBALES
		//CDG_Mundo3D = GameObject.Find("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D>();

		offset = transform.position - jugador.transform.position;

		//if (CDG_Mundo3D.primeraVez_IslaDino == true){
		//	CDG_Mundo3D.primeraVez_IslaDino = false;
		//}
		//else {
		//	GameObject.Find ("Camara_Inicio").SetActive (false);
		//}
	}

	public void deshabilitarCamara(){
		gameObject.SetActive (false);
	}

	void LateUpdate (){
		transform.position = jugador.transform.position + offset;
	}
}

	/*
//Control Camara 2
using UnityEngine;
using System.Collections;

public class ControlCamara : MonoBehaviour {
	
	// Control para que la camara siga al jugador desde una distancia fija.
	
	
	public GameObject jugador;
	
	Rigidbody rb_jugador;
	
	private Vector3 offset;
	private float zoomCamara;
	
	void Start ()
	{
		offset = transform.position - jugador.transform.position;
		rb_jugador = jugador.GetComponent<Rigidbody>();
		
	}
	
	void LateUpdate ()
	{
		zoomCamara=rb_jugador.velocity.z;
		Vector3 zoomV3 = new Vector3 (8*zoomCamara,8*zoomCamara,0f); 
		
		transform.position =  new Vector3( 4*jugador.transform.position.x/5 + offset.x,jugador.transform.position.x/5 + offset.y,jugador.transform.position.z + offset.z);
	}
}
*/