using UnityEngine;
using System.Collections;

public class controlInteraccionFantasma : MonoBehaviour {

	SpriteRenderer spr_bocadilloFantasma_01;
	SpriteRenderer spr_bocadilloFantasma_02;
	
	Vector3 posicionConversarConFantasma;

	ControlProtaMouse_2 ctrlProta;

	NavMeshAgent agente;

	GameObject Fantasma;
	public GameObject gObj_botonPasarBocadillo;

	Animator animator_Fantasma;
	Animator animator_Canvas;
	Animator animator_Cam;
	Animator animator_Prota;

	public bool posicionCorrecta=false;

	// Use this for initialization
	void Start () {

		Fantasma = GameObject.Find("fantasma_bake_v2");

		spr_bocadilloFantasma_01 = GameObject.Find("bocadillo_Fantasma").GetComponent<SpriteRenderer>();
		spr_bocadilloFantasma_02 = GameObject.Find("bocadillo_Fantasma_02").GetComponent<SpriteRenderer>();

		agente = GameObject.Find ("Chico_TEAPlay").GetComponent<NavMeshAgent>();
		posicionConversarConFantasma = GameObject.Find("Posicion_ConversarConFantasma").transform.position; 

		animator_Fantasma = Fantasma.GetComponent <Animator> ();
		animator_Cam = GameObject.Find ("PivoteCamaraPrincipal").GetComponent <Animator> ();
		animator_Canvas = GameObject.Find ("Canvas_Mundo3D").GetComponent <Animator> ();
		animator_Prota = GameObject.Find ("Chico_TEAPlay").GetComponent<Animator>();

		ctrlProta = GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2>();
	}

	void OnTriggerEnter(Collider coli)
	{
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			//Activamos el "Modo Dialogo" desde el animator del canvas
			animator_Canvas.Play("Canvas_AparecerDialogos");

			//Desactivamos el control del prota mientras estemos conversando
			ctrlProta.enabled = false;

			//Y mandamos su NavMeshAgent a la posicion de conversar con el Dino
			agente.SetDestination(posicionConversarConFantasma);

			//Activamos la animacion de zoom de la camara
			animator_Cam.SetBool("ZoomCam_Fantasma", true);

			//Activamos el primer bocadillo de conversacion y el boton para pasar de bocadillos en el canvas
			spr_bocadilloFantasma_01.enabled=true;
			gObj_botonPasarBocadillo.SetActive(true);
		}
		
	}

	void OnTriggerStay(Collider coli)
	{
		//Colocamos al personaje en la posicion correcta.
		if (coli.gameObject.name == "Chico_TEAPlay" && !posicionCorrecta) 
		{
			//agente.transform.LookAt(Dino.transform.position);

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
					animator_Cam.SetBool("ZoomCam_Fantasma", false);
					animator_Canvas.Play("Canvas_DesaparecerDialogos");

			posicionCorrecta=false;

		}
		
	}
	

	public void activarBocadillo2 (){
		spr_bocadilloFantasma_01.enabled=false;
		spr_bocadilloFantasma_02.enabled=true;

		//A los 3 segundos, salimos del "Modo Dialogo"
		Invoke("salirDialogo",3.0f);

	}

	void salirDialogo(){

		ctrlProta.enabled = true;

		spr_bocadilloFantasma_02.enabled=false;
		gObj_botonPasarBocadillo.SetActive(false);

		animator_Cam.SetBool("ZoomCam_Fantasma", false);
		animator_Canvas.Play("Canvas_DesaparecerDialogos");
		
		posicionCorrecta=true;


	}
}
