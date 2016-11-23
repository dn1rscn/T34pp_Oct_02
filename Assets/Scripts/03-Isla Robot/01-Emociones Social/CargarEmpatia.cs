using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CargarEmpatia : MonoBehaviour 
{
	ControlEmociones CE;
	controlRespAleatoria CRA;
	ControlAleatorioSocialNivel2 CA2;

	public GameObject[] GRPS_Canvas;
	public GameObject[] GRPS;
	public GameObject[] Ejercicios;
	public GameObject finpartida;
	public GameObject estrella1;
	public GameObject estrella2;
	public GameObject estrella3;

	// Use this for initialization
	void Start () 
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();

		Actualizar_Escena ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void Cambio_escena()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CRA = GameObject.Find ("crtRespuesta").GetComponent<controlRespAleatoria> ();

		if (CE.NivelEmpatia == 1) //Nivel 1
		{
			switch(CE.EjercicioSocial)
			{
			case 1:
				CE.NivelEmpatia=1;
				CE.EjercicioSocial=2;
				estrella1.SetActive(false);
				estrella2.SetActive(false);
				estrella3.SetActive(false);
				finpartida.SetActive(false);
				CE.respuesta=false;
				CRA.RespuesAleatoria();
				Actualizar_Escena();
				break;
			case 2:
				CE.NivelEmpatia=1;
				CE.EjercicioSocial=3;
				estrella1.SetActive(false);
				estrella2.SetActive(false);
				estrella3.SetActive(false);
				finpartida.SetActive(false);
				CE.respuesta=false;
				CRA.RespuesAleatoria();
				Actualizar_Escena();
				break;
			case 3:
				break;
			}
		}
		if (CE.NivelEmpatia == 3) //Nivel 3
		{
			switch(CE.EjercicioSocial)
			{
			case 1:
				CE.NivelEmpatia=3;
				CE.EjercicioSocial=2;
				estrella1.SetActive(false);
				estrella2.SetActive(false);
				estrella3.SetActive(false);
				finpartida.SetActive(false);
				CE.respuesta=false;
				CRA.RespuesAleatoria();
				Actualizar_Escena();
				break;
			case 2:
				CE.NivelEmpatia=3;
				CE.EjercicioSocial=3;
				estrella1.SetActive(false);
				estrella2.SetActive(false);
				estrella3.SetActive(false);
				finpartida.SetActive(false);
				CE.respuesta=false;
				CRA.RespuesAleatoria();
				Actualizar_Escena();
				break;
			case 3:
				break;
			}
		}

	}
	public void Volver_a_jugar()
	{
		estrella1.SetActive(false);
		estrella2.SetActive(false);
		estrella3.SetActive(false);
		finpartida.SetActive(false);
		CE.respuesta=false;
		if (CE.NivelEmpatia == 1 || CE.NivelEmpatia == 3) 
		{
			CRA = GameObject.Find ("crtRespuesta").GetComponent<controlRespAleatoria> ();
			CRA.RespuesAleatoria ();
		} 
		else if (CE.NivelEmpatia == 2) 
		{
			CA2 = GameObject.Find ("ctrlAleatorio").GetComponent<ControlAleatorioSocialNivel2> ();
			CA2.AleatorioResp();
		}
		Actualizar_Escena ();
	}
	public void Salir()
	{
		if (CE.NivelEmpatia == 1) //Nivel 1
		{
			switch(CE.EjercicioSocial)
			{
			case 1:
				Application.LoadLevel("Empatia_MenusSeleccion");
				break;
			case 2:
				Application.LoadLevel("Empatia_MenusSeleccion");
				break;
			case 3:
				Application.LoadLevel("Isla_Mecanica_v3");
				break;
			}
		}
		if (CE.NivelEmpatia == 2) 
		{
			Application.LoadLevel("Empatia_MenusSeleccion");
		}
		if (CE.NivelEmpatia == 3) //Nivel 3
		{
			switch(CE.EjercicioSocial)
			{
			case 1:
				Application.LoadLevel("Empatia_MenusSeleccion");
				break;
			case 2:
				Application.LoadLevel("Empatia_MenusSeleccion");
				break;
			case 3:
				Application.LoadLevel("Isla_Mecanica_v3");
				break;
			}
		}

	}
	public void Actualizar_Escena()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		//animacion/efecto cambio pantallas
		for (int i = 0; i<GRPS.Length; i++) 
		{
			GRPS[i].SetActive(false);
			GRPS_Canvas[i].SetActive(false);
		}
		for (int i = 0; i<Ejercicios.Length; i++) 
		{
			Ejercicios[i].SetActive(false);
		}
		
		
		switch (CE.NivelEmpatia) 
		{
		case 1:
			GRPS[0].SetActive(true);
			GRPS_Canvas[0].SetActive(true);
			Cargar_Ejercicio();
			break;
		case 2:
			GRPS[1].SetActive(true);
			GRPS_Canvas[1].SetActive(true);
			break;
		case 3:
			GRPS[2].SetActive(true);
			GRPS_Canvas[2].SetActive(true);
			Cargar_Ejercicio();
			break;
		}
	}
	void Cargar_Ejercicio()
	{
		switch (CE.EjercicioSocial) 
		{
		case 1:
			Ejercicios[0].SetActive(true);
			break;
		case 2:
			Ejercicios[1].SetActive(true);
			break;
		case 3:
			Ejercicios[2].SetActive(true);
			break;
		}
	}
}
