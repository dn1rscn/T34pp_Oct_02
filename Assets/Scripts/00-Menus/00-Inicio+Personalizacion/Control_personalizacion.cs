using UnityEngine;
using System.Collections;

public class Control_personalizacion : MonoBehaviour 
{
	control_datosGlobalesPersonalizacion cdgp;
	//Actualizar_mascotas CMasc;
	Actualizar_ninos CNiños;

	GameObject[] Piel;
	GameObject[] Pelo;
	GameObject[] Sudadera;
	GameObject[] Piernas;

	//Renderer piel;
	//public GameObject Geo_piel;

	// Use this for initialization
	void Start () 
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();
		//CMasc = GameObject.Find ("Grupo_Mascotas").GetComponent<Actualizar_mascotas> ();
		CNiños = GameObject.Find ("AvataresParaMenu").GetComponent<Actualizar_ninos> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void cambiar_sexo()
	{
		CNiños = GameObject.Find ("AvataresParaMenu").GetComponent<Actualizar_ninos> ();

		if (cdgp.Sexo == 0) 
		{
			cdgp.Sexo=1;

			CNiños.Niño.SetActive(false);
			CNiños.Niña.SetActive(true);

			Piel = GameObject.FindGameObjectsWithTag ("Piel2");
			Pelo = GameObject.FindGameObjectsWithTag ("Pelo2");
			Sudadera = GameObject.FindGameObjectsWithTag ("Sudadera2");
			Piernas = GameObject.FindGameObjectsWithTag ("Piernas2");

			for(int i=0;i<Pelo.Length;i++)
			{
				Pelo[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_pelo];
			}
			for(int i=0;i<Piel.Length;i++)
			{
				Piel[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piel];
			}
			for(int i=0;i<Sudadera.Length;i++)
			{
				Sudadera[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_camiseta];
			}
			for(int i=0;i<Piernas.Length;i++)
			{
				Piernas[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piernas];
			}
		} 
		else if (cdgp.Sexo == 1) 
		{
			cdgp.Sexo=0;
			
			CNiños.Niño.SetActive(true);
			CNiños.Niña.SetActive(false);

			Piel = GameObject.FindGameObjectsWithTag ("Piel");
			Pelo = GameObject.FindGameObjectsWithTag ("Pelo");
			Sudadera = GameObject.FindGameObjectsWithTag ("Sudadera");
			Piernas = GameObject.FindGameObjectsWithTag ("Piernas");

			for(int i=0;i<Pelo.Length;i++)
			{
				Pelo[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_pelo];
			}
			for(int i=0;i<Piel.Length;i++)
			{
				Piel[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piel];
			}
			for(int i=0;i<Sudadera.Length;i++)
			{
				Sudadera[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_camiseta];
			}
			for(int i=0;i<Piernas.Length;i++)
			{
				Piernas[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piernas];
			}
		}

	}
	public void cambiar_der()
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();
		CNiños = GameObject.Find ("AvataresParaMenu").GetComponent<Actualizar_ninos> ();

		//NIÑO
		if (cdgp.Sexo == 0) 
		{
			Piel = GameObject.FindGameObjectsWithTag ("Piel");
			Pelo = GameObject.FindGameObjectsWithTag ("Pelo");
			Sudadera = GameObject.FindGameObjectsWithTag ("Sudadera");
			Piernas = GameObject.FindGameObjectsWithTag ("Piernas");
//*****************************PELO*****************************************
			if (cdgp.pelo == true) {
				if (cdgp.posicion_pelo == CNiños.AtexturasNiño.Length - 1) {

					cdgp.posicion_pelo = 0;
					for (int i=0; i<Pelo.Length; i++) {
						Pelo [i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_pelo];
					}
				} else {
					cdgp.posicion_pelo++;
					for (int i=0; i<Pelo.Length; i++) {
						Pelo [i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_pelo];
					}
				}
			}

//*****************************PIEL*****************************************
			if (cdgp.piel == true) {
				if (cdgp.posicion_piel == CNiños.AtexturasNiño.Length - 1) {
					cdgp.posicion_piel = 0;
					for (int i=0; i<Piel.Length; i++) {
						Piel [i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piel];
					}
				} else {
					cdgp.posicion_piel++;
					for (int i=0; i<Piel.Length; i++) {
						Piel [i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piel];
					}
				}
			}
//*****************************CAMISETA*****************************************
			if (cdgp.camiseta == true) {
				if (cdgp.posicion_camiseta == CNiños.AtexturasNiño.Length - 1) {
					cdgp.posicion_camiseta = 0;
					for (int i=0; i<Sudadera.Length; i++) {
						Sudadera [i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_camiseta];
					}
				} else {
					cdgp.posicion_camiseta++;
					for (int i=0; i<Sudadera.Length; i++) {
						Sudadera [i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_camiseta];
					}
					;
				}
			}
//*****************************PIERNAS*****************************************
			if (cdgp.piernas == true) {
				if (cdgp.posicion_piernas == CNiños.AtexturasNiño.Length - 1) {
					cdgp.posicion_piernas = 0;
					for (int i=0; i<Piernas.Length; i++) {
						Piernas [i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piernas];
					}
				} else {
					cdgp.posicion_piernas++;
					for (int i=0; i<Piernas.Length; i++) {
						Piernas [i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piernas];
					}
				}
			}
		}

			//NIÑA

			else if (cdgp.Sexo==1)
			{
			Piel = GameObject.FindGameObjectsWithTag ("Piel2");
			Pelo = GameObject.FindGameObjectsWithTag ("Pelo2");
			Sudadera = GameObject.FindGameObjectsWithTag ("Sudadera2");
			Piernas = GameObject.FindGameObjectsWithTag ("Piernas2");
				//*****************************PELO*****************************************
				if (cdgp.pelo == true) {
					if (cdgp.posicion_pelo == CNiños.AtexturasNiña.Length - 1) {
						
						cdgp.posicion_pelo = 0;
						for(int i=0;i<Pelo.Length;i++)
						{
							Pelo[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_pelo];
						}
					} else {
						cdgp.posicion_pelo++;
						for(int i=0;i<Pelo.Length;i++)
						{
							Pelo[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_pelo];
						}
					}
				}
				
				//*****************************PIEL*****************************************
				if (cdgp.piel == true) {
					if (cdgp.posicion_piel == CNiños.AtexturasNiña.Length - 1) {
						cdgp.posicion_piel = 0;
						for(int i=0;i<Piel.Length;i++)
						{
							Piel[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piel];
						}
					} else {
						cdgp.posicion_piel++;
						for(int i=0;i<Piel.Length;i++)
						{
							Piel[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piel];
						}
					}
				}
				//*****************************CAMISETA*****************************************
				if (cdgp.camiseta == true) {
					if (cdgp.posicion_camiseta == CNiños.AtexturasNiña.Length - 1) {
						cdgp.posicion_camiseta = 0;
						for(int i=0;i<Sudadera.Length;i++)
						{
							Sudadera[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_camiseta];
						}
					} else {
						cdgp.posicion_camiseta++;
						for(int i=0;i<Sudadera.Length;i++)
						{
							Sudadera[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_camiseta];
						}
					}
				}
				//*****************************PIERNAS*****************************************
				if (cdgp.piernas == true) {
					if (cdgp.posicion_piernas == CNiños.AtexturasNiña.Length - 1) {
						cdgp.posicion_piernas = 0;
						for(int i=0;i<Piernas.Length;i++)
						{
							Piernas[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piernas];
						}
					} else {
						cdgp.posicion_piernas++;
						for(int i=0;i<Piernas.Length;i++)
						{
							Piernas[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piernas];
						}
					}
				}
			}
	}

	public void cambiar_izq()
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();
		CNiños = GameObject.Find ("AvataresParaMenu").GetComponent<Actualizar_ninos> ();
		if (cdgp.Sexo == 0) 
		{
			Piel = GameObject.FindGameObjectsWithTag ("Piel");
			Pelo = GameObject.FindGameObjectsWithTag ("Pelo");
			Sudadera = GameObject.FindGameObjectsWithTag ("Sudadera");
			Piernas = GameObject.FindGameObjectsWithTag ("Piernas");
//*****************************PELO*****************************************
			if (cdgp.pelo == true) {
				if (cdgp.posicion_pelo == 0) 
				{
					cdgp.posicion_pelo = CNiños.AtexturasNiño.Length - 1;
					for(int i=0;i<Pelo.Length;i++)
					{
						Pelo[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_pelo];
					}
				} else {
					cdgp.posicion_pelo--;
					for(int i=0;i<Pelo.Length;i++)
					{
						Pelo[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_pelo];
					}
				}
			}
//*****************************PIEL*****************************************
			if (cdgp.piel == true) {
				if (cdgp.posicion_piel == 0) {
					cdgp.posicion_piel = CNiños.AtexturasNiño.Length - 1;
					for(int i=0;i<Piel.Length;i++)
					{
						Piel[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piel];
					}
				} else {
					cdgp.posicion_piel--;
					for(int i=0;i<Piel.Length;i++)
					{
						Piel[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piel];
					}
				}
			}
//*****************************CAMISETA*****************************************
			if (cdgp.camiseta == true) {
				if (cdgp.posicion_camiseta == 0) {
					cdgp.posicion_camiseta = CNiños.AtexturasNiño.Length - 1;
					for(int i=0;i<Sudadera.Length;i++)
					{
						Sudadera[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_camiseta];
					}
				} else {
					cdgp.posicion_camiseta--;
					for(int i=0;i<Sudadera.Length;i++)
					{
						Sudadera[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_camiseta];
					}
				}
			}
//*****************************PIERNAS*****************************************
			if (cdgp.piernas == true) {
				if (cdgp.posicion_piernas == 0) {
					cdgp.posicion_piernas = CNiños.AtexturasNiño.Length - 1;
					for(int i=0;i<Piernas.Length;i++)
					{
						Piernas[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piernas];
					}
				} else {
					cdgp.posicion_piernas--;
					for(int i=0;i<Piernas.Length;i++)
					{
						Piernas[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiño [cdgp.posicion_piernas];
					}
				}
			}

		} 
		else if (cdgp.Sexo == 1) 
		{
			Piel = GameObject.FindGameObjectsWithTag ("Piel2");
			Pelo = GameObject.FindGameObjectsWithTag ("Pelo2");
			Sudadera = GameObject.FindGameObjectsWithTag ("Sudadera2");
			Piernas = GameObject.FindGameObjectsWithTag ("Piernas2");
			if (cdgp.pelo == true)
			{
				if (cdgp.posicion_pelo == 0) 
				{
					cdgp.posicion_pelo = CNiños.AtexturasNiña.Length - 1;
					for(int i=0;i<Pelo.Length;i++)
					{
						Pelo[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_pelo];
					}
				} else {
					cdgp.posicion_pelo--;
					for(int i=0;i<Pelo.Length;i++)
					{
						Pelo[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_pelo];
					}
					
				}
			}
			//*****************************PIEL*****************************************
			if (cdgp.piel == true) 
			{
				if (cdgp.posicion_piel == 0) 
				{
					cdgp.posicion_piel = CNiños.AtexturasNiña.Length - 1;
					for(int i=0;i<Piel.Length;i++)
					{
						Piel[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piel];
					}
				} else {
					cdgp.posicion_piel--;
					for(int i=0;i<Piel.Length;i++)
					{
						Piel[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piel];
					}
				}
			}
			//*****************************CAMISETA*****************************************
			if (cdgp.camiseta == true) {
				if (cdgp.posicion_camiseta == 0) {
					cdgp.posicion_camiseta = CNiños.AtexturasNiña.Length - 1;
					for(int i=0;i<Sudadera.Length;i++)
					{
						Sudadera[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_camiseta];
					}
				} else {
					cdgp.posicion_camiseta--;
					for(int i=0;i<Sudadera.Length;i++)
					{
						Sudadera[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_camiseta];
					}
				}
			}
			//*****************************PIERNAS*****************************************
			if (cdgp.piernas == true) {
				if (cdgp.posicion_piernas == 0) {
					cdgp.posicion_piernas = CNiños.AtexturasNiña.Length - 1;
					for(int i=0;i<Piernas.Length;i++)
					{
						Piernas[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piernas];
					}
				} else {
					cdgp.posicion_piernas--;
					for(int i=0;i<Piernas.Length;i++)
					{
						Piernas[i].GetComponent<Renderer> ().material.mainTexture = CNiños.AtexturasNiña [cdgp.posicion_piernas];
					}
				}
			}
		}
	}
}
