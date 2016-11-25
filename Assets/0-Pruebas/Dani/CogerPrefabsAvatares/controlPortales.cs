using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlPortales : MonoBehaviour {

	Animator animator_PanelCanvas;
	Animator animator_botonesPortal;

	Text textoNombrePortal;

	string destinoPortal;

	ControlDatosGlobales_Mundo3D CDG_Mundo3D;

	// Use this for initialization
	void Start ()
	{
		//ACCEDEMOS AL SCRIPT DE DATOS GLOBALES
//		CDG_Mundo3D = GameObject.Find("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D>();

		animator_PanelCanvas = GameObject.Find ("CanvasPortal_Verde").GetComponent<Animator> ();
		animator_botonesPortal = GameObject.Find("botonesPortal").GetComponent<Animator>();

	}
	
	void OnTriggerEnter(Collider coli)
	{
		if (coli.gameObject.tag == "Portal")
		{
			//Recogemos el texto que contiene el gameObject "nombrePortal" en el momento de colisionar con el trigger
			textoNombrePortal = GameObject.Find("nombrePortal").GetComponent<Text>();


			print ("Colision con: "+coli.gameObject.name);
			//Ejecutamos la animacion del canvas al entrar en algun portal
 			animator_PanelCanvas.Play("CanvasPortal_animIntro");
			animator_botonesPortal.Play("IntroBotonesPortales");

			print ("Colision con: "+coli.gameObject.name);

			//TRIGGERS ISLA BOSQUE
			if(coli.gameObject.name=="trigger_EjercicioPictogramas")
			{
				//CDG_Mundo3D.posicionPersonaje = 2;
				destinoPortal= "ejercicioDado";
				print(destinoPortal);
			}
			else if(coli.gameObject.name=="trigger_EjercicioSonidos")
			{
				//CDG_Mundo3D.posicionPersonaje = 2;
				destinoPortal= "ejercicioSonidos";
				print(destinoPortal);

				//animator_PanelCanvas.Play("pasarABlanco");
				//Invoke("cargarPictogramas2",100*Time.deltaTime);
			}
			else if(coli.gameObject.name=="trigger_IslaFantasma")
			{
				//CDG_Mundo3D.posicionPersonaje = 2;
				destinoPortal= "islaFantasma";
				print(destinoPortal);
				
				//animator_PanelCanvas.Play("pasarABlanco");
				//Invoke("cargarPictogramas2",100*Time.deltaTime);
			}

			//TRIGGERS ISLA FANTASMA
			else if(coli.gameObject.name=="trigger_ejercicioSecuencias")
			{
				//CDG_Mundo3D.posicionPersonaje = 2;
				destinoPortal= "ejercicioSecuencias";
				print(destinoPortal);
				
				//animator_PanelCanvas.Play("pasarABlanco");
				//Invoke("cargarPictogramas2",100*Time.deltaTime);
			}
			else if(coli.gameObject.name=="trigger_ejercicioCanasta")
			{
				//CDG_Mundo3D.posicionPersonaje = 2;
				destinoPortal= "juegoCanasta";
				print(destinoPortal);
				
			}
			else if(coli.gameObject.name=="trigger_islaMecanica")
			{
				//CDG_Mundo3D.posicionPersonaje = 2;
				destinoPortal= "islaMecanica";
				print(destinoPortal);
				
			}


			//TRIGGERS ISLA MECANICA
			else if(coli.gameObject.name=="trigger_ejercicioEmocionesSocial")
			{
				//CDG_Mundo3D.posicionPersonaje = 2;
				destinoPortal= "emocionesSocial";
				print(destinoPortal);
				
			}
			else if(coli.gameObject.name=="trigger_ejercicioEmociones")
			{
				//CDG_Mundo3D.posicionPersonaje = 2;
				destinoPortal= "ejercicioEmociones";
				print(destinoPortal);
				
			}
			else if(coli.gameObject.name=="trigger_altarFinal")
			{
				//CDG_Mundo3D.posicionPersonaje = 2;
				destinoPortal= "altarFinal";
				print(destinoPortal);
				
			}

			//Actualizamos el texto contiene el gameObject "nombrePortal"
			textoNombrePortal.text = destinoPortal;


		}
	}

	void OnTriggerExit(Collider coli)
	{
		if (coli.gameObject.tag == "Portal")
		{
			//Ejecutamos la animacion de salida canvas al salir del portal
			animator_PanelCanvas.Play("CanvasPortal_animSalida");
			animator_botonesPortal.Play("SalidaBotonesPortales");
			textoNombrePortal.text = "";
		}
	}


	public void usarPortal(){
		switch (destinoPortal)
		{
		
		//ISLA BOSQUE
		case "ejercicioDado":
			Application.LoadLevel("Dado_SeleccionNivel");
			break;
		case "ejercicioSonidos":
			Application.LoadLevel("Sonidos_menu_Seleccion");
			print ("Cargando ejercicio sonidos...");
			break;
		case "islaFantasma":
			Application.LoadLevel("Isla_fantasma");
			print ("Cargando islaFantasma...");
			CDG_Mundo3D.islaBosque = false;
			CDG_Mundo3D.islaMec = false;
			CDG_Mundo3D.islaFant = true;
			break;

		//ISLA FANTASMA
		case "ejercicioSecuencias":
			Application.LoadLevel("SECUENCIAS_menu_seleccion");
			print ("Cargando ejercicio secuencias...");
			break;
		case "juegoCanasta":
			Application.LoadLevel("10_iFantasma_P2_Canasta");
			print ("Cargando ejercicio canasta...");
			break;
		case "islaMecanica":
			Application.LoadLevel("Isla_Mecanica_v3");
			print ("Cargando islaMecanica...");
			CDG_Mundo3D.islaBosque = false;
			CDG_Mundo3D.islaMec = true;
			CDG_Mundo3D.islaFant = false;
			break;

		//ISLA MECANICA
		case "emocionesSocial":
			Application.LoadLevel("Empatia_MenusSeleccion");
			print ("Cargando ejercicio emociones social...");
			break;
		case "ejercicioEmociones":
			Application.LoadLevel("2-Emociones_SelecNivel");
			print ("Cargando ejercicio emociones...");
			break;
		case "altarFinal":
			Application.LoadLevel("Isla_altar");
			print ("Cargando altarFINAL...");
			CDG_Mundo3D.islaBosque = true;
			CDG_Mundo3D.islaMec = false;
			CDG_Mundo3D.islaFant = false;
			break;

		}
	}

}
