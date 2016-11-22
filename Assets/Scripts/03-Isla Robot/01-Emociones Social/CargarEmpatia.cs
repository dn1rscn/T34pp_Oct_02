using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CargarEmpatia : MonoBehaviour 
{
	ControlEmociones CE;

	public GameObject[] GRPS_Canvas;
	public GameObject[] GRPS;
	public GameObject[] Ejercicios;

	// Use this for initialization
	void Start () 
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
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
	
	// Update is called once per frame
	void Update () 
	{
	
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
