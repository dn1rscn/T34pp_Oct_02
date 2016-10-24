using UnityEngine;
using System.Collections;

public class ControlDesbloqueoIslaFantasma : MonoBehaviour 
{
	int i;

	ControlDatosGlobales_Mundo3D cdg_3d;
	ControlMisiones CMisiones;

	// Use this for initialization
	void Start () 
	{
		cdg_3d=GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();


		//DESBLOQUEO ISLA FANTASMA
		i = 0;

		while (i<=cdg_3d.Ejer_Bosque.Length-1&&cdg_3d.Ejer_Bosque[i]==true )
		{
			print(cdg_3d.Ejer_Bosque.Length);
			print (i);
			print(cdg_3d.Ejer_Bosque[i]);

			if(i==cdg_3d.Ejer_Bosque.Length-1)
			{
				//desbloqueamos isla
				print("isla Desbloqueada");
				cdg_3d.IslaFantasma_Desbloqueada=true;
			}
		
			i++;

		}
		if (i<cdg_3d.Ejer_Bosque.Length && cdg_3d.Ejer_Bosque [i] == false) 
		{
			print("Ejercicio "+i+" no completado");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
