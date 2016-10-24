using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlDatosGlobales_PICTOGRAMAS : MonoBehaviour 
{

	public int PicAleat;

	public int cart1=0;
	public int cart2=0;
	public int cart3=0;
	public int correcto=0;
	public bool resp=false;
	public int aciertos=0;
	public int fallos=0;
	public int aciertosSeguidos=0;
	public int combos=0;

	//public Material [] palabras;
	public Sprite [] pictogramas;
	public Material[] ImDado;

	public GameObject Cartel1;
	public GameObject Cartel2;
	public GameObject Cartel3;

	// Use this for initialization
	void Start () 
	{

	}

	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
