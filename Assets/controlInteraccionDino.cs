using UnityEngine;
using System.Collections;

public class controlInteraccionDino : MonoBehaviour {

	SpriteRenderer spr_flechaDestino_Dino;
	SpriteRenderer spr_bocadilloDino_01;
	SpriteRenderer spr_bocadilloDino_02;
	
	Vector3 posicionConversarConDino;

	ControlProtaMouse_2 ctrlProta;

	NavMeshAgent agente;

	GameObject Dino;
	public GameObject gObj_botonPasarBocadillo;

	Animator animator_Dino;
	Animator animator_Canvas;
	Animator animator_Cam;
	Animator animator_Prota;

	public bool posicionCorrecta=false;

	// Use this for initialization
	void Start () {

		Dino= GameObject.Find("Dinoi_animaciones_v3");

		spr_flechaDestino_Dino = GameObject.Find("flechaDestino_Dino").GetComponent<SpriteRenderer>();
		spr_bocadilloDino_01 = GameObject.Find("bocadillo_Dino").GetComponent<SpriteRenderer>();
		spr_bocadilloDino_02 = GameObject.Find("bocadillo_Dino_02").GetComponent<SpriteRenderer>();

		agente = GameObject.Find ("Chico_TEAPlay").GetComponent<NavMeshAgent>();
		posicionConversarConDino = GameObject.Find("Posicion_ConversarConDino").transform.position; 

		animator_Dino = GameObject.Find ("Dinoi_animaciones_v3").GetComponent <Animator> ();
		animator_Cam = GameObject.Find ("PivoteCamaraPrincipal").GetComponent <Animator> ();
		animator_Canvas = GameObject.Find ("Canvas_Mundo3D").GetComponent <Animator> ();
		animator_Prota = GameObject.Find ("Chico_TEAPlay").GetComponent<Animator>();

		ctrlProta = GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2>();
	}

	void OnTriggerEnter(Collider coli)
	{
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			//Desactivamos la flecha de destino sobre el dino
			spr_flechaDestino_Dino.enabled = false;

			//Activamos el "Modo Dialogo" desde el animator del canvas
			animator_Canvas.Play("Canvas_AparecerDialogos");

			//Desactivamos el control del prota mientras estemos conversando
			ctrlProta.enabled = false;

			//Y mandamos su NavMeshAgent a la posicion de conversar con el Dino
			agente.SetDestination(posicionConversarConDino);

			//Activamos la animacion de zoom de la camara
			animator_Cam.SetBool("ZoomCam", true);

			//Activamos el primer bocadillo de conversacion y el boton para pasar de bocadillos en el canvas
			spr_bocadilloDino_01.enabled=true;
			gObj_botonPasarBocadillo.SetActive(true);
		}
		
	}

	void OnTriggerStay(Collider coli)
	{
		//Colocamos al personaje en la posicion correcta.
		if (coli.gameObject.name == "Chico_TEAPlay" && !posicionCorrecta) 
		{
			agente.transform.LookAt(Dino.transform.position);

			if(agente.remainingDistance >= 0.1) //&& (impacto.point-agente.transform.position).magnitude>= distanciaMinima)
			{
				posicionCorrecta=false;
				animator_Prota.SetBool ("andar", true);
			}
			else
			{
				posicionCorrecta=true;
				animator_Prota.SetBool("andar",false);
			}

		}
	}

	void OnTriggerExit(Collider coli)
	{
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
		//	animator_Cam.SetBool("ZoomCam", false);
		//	animator_Dino.SetBool ("fallo_Dino", false);
		//	animator_Canvas.Play("Canvas_DesaparecerDialogos");

			posicionCorrecta=false;
			animator_Dino.SetBool ("fallo_Dino", false);


		}
		
	}

	public void DinoAnimFallo_activar(){
		animator_Dino.SetBool ("fallo_Dino", true);
	}

	public void DinoAnimFallo_desactivar(){
		animator_Dino.SetBool ("fallo_Dino", false);
	}

	public void activarBocadillo2 (){
		spr_bocadilloDino_01.enabled=false;
		spr_bocadilloDino_02.enabled=true;
		animator_Dino.SetBool("fallo_Dino",true);

		//A los 3 segundos, salimos del "Modo Dialogo"
		Invoke("salirDialogo",3.0f);

	}

	void salirDialogo(){

		ctrlProta.enabled = true;

		spr_bocadilloDino_02.enabled=false;
		gObj_botonPasarBocadillo.SetActive(false);

		animator_Cam.SetBool("ZoomCam", false);
		animator_Dino.SetBool ("fallo_Dino", false);
		animator_Canvas.Play("Canvas_DesaparecerDialogos");
		
		posicionCorrecta=true;


	}
}
