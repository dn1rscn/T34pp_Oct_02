using UnityEngine;
using System.Collections;

public class controlPersonajesEnEscena : MonoBehaviour {

	ControlDatosGlobales_Mundo3D CDG_Mundo3D;

	public GameObject AVATARES_Chico;
	public GameObject AVATARES_Chica;

	public GameObject MASCOTAS_Fantasma;
	public GameObject MASCOTAS_Robot;
	public GameObject MASCOTAS_Dino;

	// Use this for initialization
	void Start () {

		//ACCEDEMOS AL SCRIPT DE DATOS GLOBALES
		CDG_Mundo3D = GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();

		if (Application.loadedLevelName != "03_2-Nivel1-PICTOGRAMAS"&&Application.loadedLevelName != "03_3-Nivel2-PICTOGRAMAS") {
				
			GameObject Prota = GameObject.Find("Prota_TEAPlay");
			GameObject personajes = GameObject.Find ("Personajes");

			Prota.GetComponent<NavMeshAgent>().enabled=false;
			MASCOTAS_Dino.GetComponent<NavMeshAgent>().enabled = false;
			MASCOTAS_Fantasma.GetComponent<NavMeshAgent>().enabled = false;
			MASCOTAS_Robot.GetComponent<NavMeshAgent>().enabled = false;


			switch (CDG_Mundo3D.posicionPersonaje) {
				case 3:
				{
					//posicionFinal
					personajes.transform.position = GameObject.Find ("PosicionFinal").transform.position;
					
					break;
				}	
				case 2:
				{	//posicionMedia
					personajes.transform.position= GameObject.Find ("PosicionMedia").transform.position;
					break;
					
				}	
				case 1:
				{	//posicionInicial
					personajes.transform.position = GameObject.Find ("PosicionInicial").transform.position;
					
					break;
				}
				default: 
				{
					break;
				}
			}
		
			
			actualizarPersonajesEnEscena ();

			
			Prota.GetComponent<NavMeshAgent>().enabled=true;
			MASCOTAS_Dino.GetComponent<NavMeshAgent>().enabled = true;
			MASCOTAS_Fantasma.GetComponent<NavMeshAgent>().enabled = true;
			MASCOTAS_Robot.GetComponent<NavMeshAgent>().enabled = true;


			if (Application.loadedLevelName == "03_1-Mundo3D_IslaDino") {
				MASCOTAS_Dino.SetActive (true);
			} else if (Application.loadedLevelName == "04_1-Mundo3D_IslaRobot") {
				MASCOTAS_Robot.SetActive (true);
			} else if (Application.loadedLevelName == "05_1-Mundo3D_IslaFantasma") {
				MASCOTAS_Fantasma.SetActive (true);
			}

		}
		else {
			actualizarPersonajesEnEscena ();
		}

	}

	public void actualizarPersonajesEnEscena(){
		//Colocamos los personajes en la posicion correcta
	
		//Mostramos el personaje seleccionado
		switch (CDG_Mundo3D.AvatarSeleccionado)
		{
		case 2:
		{
			print ("CHICA");

			AVATARES_Chico.SetActive(false);
			AVATARES_Chica.SetActive(true);

			break;
		}
		case 1:
		{
			print ("CHICO");

			AVATARES_Chica.SetActive(false);
			AVATARES_Chico.SetActive(true);

			break;
		}
		case 0:
		{
			print ("ERROR_NO HAY AVATAR SELECCIONADO");
			break;
		}

		default: 
		{
			break;
		}
		}


		//Mostramos la mascota seleccionada

		switch (CDG_Mundo3D.MascotaSeleccionada)
		{
		case 3:
		{
			print ("DINO");

			MASCOTAS_Fantasma.SetActive(false);
			MASCOTAS_Robot.SetActive(false);

			MASCOTAS_Dino.SetActive(true);

			break;
		}
		case 2:
		{
			print ("FANTASMA");

			MASCOTAS_Robot.SetActive(false);
			MASCOTAS_Dino.SetActive(false);

			MASCOTAS_Fantasma.SetActive(true);

			break;
		}
		case 1:
		{
			print ("ROBOT");

			MASCOTAS_Fantasma.SetActive(false);
			MASCOTAS_Dino.SetActive(false);

			MASCOTAS_Robot.SetActive(true);


			break;
		}
		case 0:
		{
			print ("ERROR_NO HAY MASCOTA SELECCIONADA");

			break;
		}
		default: 
		{
			break;
		}
	}

	}
}
