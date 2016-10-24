using UnityEngine;
using System.Collections;

public class controlEjerciciosEmociones : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EmocionesNivel1()
	{
		Application.LoadLevel ("Escena1.1");
	}
	public void EmocionesNivel2()
	{
		print ("CARGARNIVEL2");
		//Application.LoadLevel ("");
	}
	public void EmocionesNivel3()
	{
		//Application.LoadLevel ("");
		print ("CARGARNIVEL3");
	}
}
