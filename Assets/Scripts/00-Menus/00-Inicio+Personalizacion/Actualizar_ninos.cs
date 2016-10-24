using UnityEngine;
using System.Collections;

public class Actualizar_ninos : MonoBehaviour 
{
	//public GameObject[] AGeo_complementos;
	//public Material[] AColor_Pelo;
	//public Material[] AColor_Piernas;
	//public Material[] AColor_Piel;
	//public Material[] AColor_camiseta;
	public Texture[] AtexturasNiño;
	public Texture[] AtexturasNiña;

	public GameObject Niño;
	public GameObject Niña;

	GameObject[] Piel;
	GameObject[] Pelo;
	GameObject[] Sudadera;
	GameObject[] Piernas;
	//public Texture[] Atexture_Piel;
	//public Texture[] Atexture_camiseta;

	control_datosGlobalesPersonalizacion cdgp;

	// Use this for initialization
	void Start () 
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();


		if (cdgp.Sexo == 0) 
		{
			Niño.SetActive(true);
			Niña.SetActive(false);
			Piel = GameObject.FindGameObjectsWithTag ("Piel");
			Pelo = GameObject.FindGameObjectsWithTag ("Pelo");
			Sudadera = GameObject.FindGameObjectsWithTag ("Sudadera");
			Piernas = GameObject.FindGameObjectsWithTag ("Piernas");
			for(int i=0;i<Pelo.Length;i++)
			{
				Pelo[i].GetComponent<Renderer> ().material.mainTexture = AtexturasNiño [cdgp.posicion_pelo];
			}
			for(int i=0;i<Piel.Length;i++)
			{
				Piel[i].GetComponent<Renderer> ().material.mainTexture = AtexturasNiño [cdgp.posicion_piel];
			}
			for(int i=0;i<Sudadera.Length;i++)
			{
				Sudadera[i].GetComponent<Renderer> ().material.mainTexture = AtexturasNiño [cdgp.posicion_camiseta];
			}
			for(int i=0;i<Piernas.Length;i++)
			{
				Piernas[i].GetComponent<Renderer> ().material.mainTexture = AtexturasNiño [cdgp.posicion_piernas];
			}
		} 
		else if (cdgp.Sexo == 1) 
		{
			Niño.SetActive(false);
			Niña.SetActive(true);
			Piel = GameObject.FindGameObjectsWithTag ("Piel2");
			Pelo = GameObject.FindGameObjectsWithTag ("Pelo2");
			Sudadera = GameObject.FindGameObjectsWithTag ("Sudadera2");
			Piernas = GameObject.FindGameObjectsWithTag ("Piernas2");
			for(int i=0;i<Pelo.Length;i++)
			{
				Pelo[i].GetComponent<Renderer> ().material.mainTexture = AtexturasNiña [cdgp.posicion_pelo];
			}
			for(int i=0;i<Piel.Length;i++)
			{
				Piel[i].GetComponent<Renderer> ().material.mainTexture = AtexturasNiña [cdgp.posicion_piel];
			}
			for(int i=0;i<Sudadera.Length;i++)
			{
				Sudadera[i].GetComponent<Renderer> ().material.mainTexture = AtexturasNiña [cdgp.posicion_camiseta];
			}
			for(int i=0;i<Piernas.Length;i++)
			{
				Piernas[i].GetComponent<Renderer> ().material.mainTexture = AtexturasNiña [cdgp.posicion_piernas];
			}
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
