using UnityEngine;
using System.Collections;

public class ControlDesbloqueoIslaMecanica : MonoBehaviour 
{
	int i;
	
	ControlDatosGlobales_Mundo3D cdg_3d;
	// Use this for initialization
	void Start () 
	{
		cdg_3d=GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
		
		i = 0;
		
		while (i<=cdg_3d.Ejer_Fantasma.Length-1&&cdg_3d.Ejer_Fantasma[i]==true )
		{
			print(cdg_3d.Ejer_Fantasma.Length);
			print (i);
			print(cdg_3d.Ejer_Fantasma[i]);
			
			if(i==cdg_3d.Ejer_Fantasma.Length-1)
			{
				//desbloqueamos isla
				print("isla Desbloqueada");
				cdg_3d.IslaMec_Desbloqueada=true;
			}
			
			i++;
			
		}
		if (i<cdg_3d.Ejer_Fantasma.Length && cdg_3d.Ejer_Fantasma [i] == false) 
		{
			print("Ejercicio "+i+" no completado");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
