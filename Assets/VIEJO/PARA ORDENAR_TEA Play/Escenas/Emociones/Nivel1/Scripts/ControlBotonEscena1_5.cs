using UnityEngine;
using System.Collections;

public class ControlBotonEscena1_5 : MonoBehaviour 
{
	ControlDatosGlobales_Mundo3D CDG_Mundo3D;
	// Use this for initialization
	void Start () 
	{
		CDG_Mundo3D = GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void Salir()
	{
		//CDG_Mundo3D = GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
		//CDG_Mundo3D.posicionPersonaje = 2;
		Application.LoadLevel ("menu_select_emociones");
	}
}
