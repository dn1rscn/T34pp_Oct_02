//Control Camara 2
using UnityEngine;
using System.Collections;

public class ControlCamara : MonoBehaviour {
	
	// Control para que la camara siga al jugador desde una distancia fija.
	
	
	public GameObject jugador;

	GameObject FlechaDer;
	GameObject FlechaIzq;
	int estadoRotacion;
	
	Rigidbody rb_jugador;
	
	private Vector3 offset;
	private float zoomCamara;
	Animator animatorPivote;
	
	void Start ()
	{
		FlechaDer = GameObject.Find("mover_camIzq");
		FlechaIzq = GameObject.Find("mover_camDer");

		FlechaDer.SetActive(false);


		offset = transform.position - jugador.transform.position;
		rb_jugador = jugador.GetComponent<Rigidbody>();

		animatorPivote = gameObject.GetComponent<Animator>();
		
	}
	
	void LateUpdate ()
	{
		//zoomCamara=rb_jugador.velocity.z;
		//Vector3 zoomV3 = new Vector3 (8*zoomCamara,8*zoomCamara,0f); 

		//MovimientoNormal
		transform.position =  new Vector3( jugador.transform.position.x + offset.x,jugador.transform.position.y + offset.y,jugador.transform.position.z + offset.z);

		//Movimiento con zoom y cambio de altura
		//transform.position =  new Vector3( 4*jugador.transform.position.x/5 + offset.x,jugador.transform.position.x/5 + offset.y,jugador.transform.position.z + offset.z);
	}


	public void rotarCam_Izq(){
		if(estadoRotacion<=1){
			estadoRotacion++;
			print (estadoRotacion);

			actualizarRotarCam();

		} else {
			print ("La camara no gira mas hacia la der");
		}
	}
	public void rotarCam_Der(){
		if(estadoRotacion>=1){
			estadoRotacion--;
			print (estadoRotacion);

			actualizarRotarCam();

		} else {
			print ("La camara no gira mas hacia la izq");
		}
	}

	private void actualizarRotarCam(){
	
		switch(estadoRotacion)
		{
		case 0: 
			animatorPivote.SetBool("Pivote30",false);
			FlechaDer.SetActive(false);
			FlechaIzq.SetActive(true);

			break;
		case 1: 
			animatorPivote.SetBool("Pivote30",true);
			animatorPivote.SetBool("Pivote60",false);
			FlechaDer.SetActive(true);
			FlechaIzq.SetActive(true);

			break;
		case 2: 
			animatorPivote.SetBool("Pivote30",false);
			animatorPivote.SetBool("Pivote60",true);
			FlechaIzq.SetActive(false);
			FlechaDer.SetActive(true);

			break;	
			
		}

	}


}