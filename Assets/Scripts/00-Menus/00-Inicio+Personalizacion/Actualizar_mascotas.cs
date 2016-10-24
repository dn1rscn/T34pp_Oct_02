using UnityEngine;
using System.Collections;

public class Actualizar_mascotas : MonoBehaviour 
{
	control_datosGlobalesPersonalizacion cdgp;
	public GameObject[] Amascotas;

	// Use this for initialization
	void Start () 
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();
		Amascotas [cdgp.mascota].SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
