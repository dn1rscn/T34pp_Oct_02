using UnityEngine;
using System.Collections;

public class ControlInterface : MonoBehaviour 
{
	control_datosGlobalesPersonalizacion cdgP;
	ControlDatosGlobales_Mundo3D CDG_Mundo3D;

	public GameObject BotonInicio;
	public GameObject BotonJuego;

	public GameObject PersonajeInicio;
	public GameObject Personajejuego;

	public GameObject MascotaInicio;
	public GameObject Mascotajuego;

	public GameObject CamInicio;
	public GameObject CamJuego;

	public GameObject FondoRobot;
	public GameObject FondoFantasma;
	public GameObject FondoDino;

	// Use this for initialization
	void Start () 
	{
		cdgP = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();
		CDG_Mundo3D = GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();

		if (CDG_Mundo3D.IKKI == true) 
		{
			if (cdgP.nuevoJuego == true) 
			{
				BotonInicio.SetActive (true);
				PersonajeInicio.SetActive (true);
				MascotaInicio.SetActive (true);
				CamInicio.SetActive (true);
				
				BotonJuego.SetActive (false);
				Personajejuego.SetActive (false);
				Mascotajuego.SetActive (false);
				CamJuego.SetActive (false);

				cdgP.inicio=true;
			} 
			else if (cdgP.nuevoJuego == false) 
			{
				BotonInicio.SetActive (false);
				CamInicio.SetActive (true);
				
				BotonJuego.SetActive (true);
				CamJuego.SetActive (false);
			}

			CDG_Mundo3D.IKKI=false;
		} 
		else if (CDG_Mundo3D.IKKI == false) 
		{

			if (cdgP.inicio == true)
			{
				BotonInicio.SetActive (true);
				PersonajeInicio.SetActive (true);
				MascotaInicio.SetActive (true);
				CamInicio.SetActive (true);

				BotonJuego.SetActive (false);
				Personajejuego.SetActive (false);
				Mascotajuego.SetActive (false);
				CamJuego.SetActive (false);

			} 
			else if (cdgP.inicio == false) 
			{
				BotonInicio.SetActive (false);
				PersonajeInicio.SetActive (false);
				MascotaInicio.SetActive (false);
				CamInicio.SetActive (false);

				BotonJuego.SetActive (true);
				Personajejuego.SetActive (true);
				Mascotajuego.SetActive (true);
				CamJuego.SetActive (true);
			}
		}


		switch (cdgP.mascota)
		{
		case 0:
			FondoRobot.SetActive (true);
			FondoFantasma.SetActive (false);
			FondoDino.SetActive (false);
			break;

		case 1:
			FondoRobot.SetActive (false);
			FondoFantasma.SetActive (true);
			FondoDino.SetActive (false);
			break;

		case 2:
			FondoRobot.SetActive (false);
			FondoFantasma.SetActive (false);
			FondoDino.SetActive (true);
			break;
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void Mapa()
	{
		Application.LoadLevel ("Mapa");
	}
	public void Volver_mundo ()
	{
		CDG_Mundo3D = GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
		if (CDG_Mundo3D.islaBosque == true) {
			Application.LoadLevel ("Isla_bosque");
		}
		else if (CDG_Mundo3D.islaMec == true) {
			Application.LoadLevel ("Isla_Mecanica_v3");
		}
		else if (CDG_Mundo3D.islaFant == true) {
			Application.LoadLevel ("Isla_fantasma");
		}
	}
	public void RA_personalizacion()
	{
		Application.LoadLevel("personalizar_RA");
	}
	public void PersonalizacionInicial()
	{
		print ("cam personaje");
		if (cdgP.inicio == true) {
			GameObject.Find ("camara_Inicio").GetComponent<Animator> ().Play ("CamPersonaje");
		} else if (cdgP.inicio == false) 
		{
			GameObject.Find ("camara_Juego").GetComponent<Animator> ().Play ("ACamMascPersonaje");
		}
	}
	public void PersonalizacionJuego()
	{
		print ("hola");
		cdgP.inicio = false;
	}
	public void mascotas()
	{
		if (cdgP.inicio == true) {
			GameObject.Find ("camara_Inicio").GetComponent<Animator> ().Play ("CamMascota");
		} else if (cdgP.inicio == false) 
		{
			GameObject.Find ("camara_Juego").GetComponent<Animator> ().Play ("ACamPerMascota");
		}
	}
	public void robot()
	{
		FondoRobot.SetActive (true);
		FondoFantasma.SetActive (false);
		FondoDino.SetActive (false);

		cdgP.mascota = 0;
	}
	public void fantasma()
	{
		FondoRobot.SetActive (false);
		FondoFantasma.SetActive (true);
		FondoDino.SetActive (false);

		cdgP.mascota = 1;
	}
	public void Dino()
	{
		FondoRobot.SetActive (false);
		FondoFantasma.SetActive (false);
		FondoDino.SetActive (true);

		cdgP.mascota = 2;
	}
	public void Facebook ()
	{
		Application.OpenURL ("https://www.facebook.com/Ikki-Studios-1854126904821934");
	}
	public void twitter ()
	{
		Application.OpenURL ("https://twitter.com/Studiosikki");
	}

}
