using UnityEngine;
using System.Collections;

public class ControlEscenaIKKI : MonoBehaviour 
{
	ControlDatosGlobales_Mundo3D CDG_Mundo3D;

	// Use this for initialization
	void Start () 
	{
		CDG_Mundo3D = GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();

		CDG_Mundo3D.IKKI = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
