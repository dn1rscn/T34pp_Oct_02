using UnityEngine;
using System.Collections;

public class ControlMisiones : MonoBehaviour 
{
	public static ControlMisiones cont;

	public bool dado1;
	public bool dado2;

	public bool sonidos1;
	public bool sonidos2;
	public bool sonidos3;

	public bool Dado1_Completado;
	public bool Sonidos1_Completado;

	public bool[] ejerB_3estrellas;
	public bool[] ejerF_3estrellas;
	public bool[] ejerM_3estrellas;

	public bool misionDinoCompletada;
	public bool misionFantasmaCompletada;
	public bool misionRobotCompletada;

	int i;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Mision_Dino()
	{
		i = 0;

		while (i<=ejerB_3estrellas.Length-1 && ejerB_3estrellas[i]==true) 
		{
			if(i==ejerB_3estrellas.Length-1)
			{
				//mision completada
				print("Mision completada");
				misionDinoCompletada=true;
			}
			
			i++;
			
		}
		if (i<ejerB_3estrellas.Length && ejerB_3estrellas [i] == false) 
		{
			print("Ejercicio "+i+" no completado FULL");
		}
	}

	public void Mision_Fantasma()
	{
		i = 0;

		while (i<=ejerF_3estrellas.Length-1 && ejerF_3estrellas[i]==true) 
		{
			if(i==ejerF_3estrellas.Length-1)
			{
				//mision completada
				misionFantasmaCompletada=true;
			}
			i++;
		}
		if (i < ejerF_3estrellas.Length && ejerF_3estrellas [i] == false) 
		{
			print("Ejercicio "+i+" no completado FULL");
		}
	}

	public void Mision_Robot()
	{
		i = 0;
		
		while (i<=ejerM_3estrellas.Length-1 && ejerM_3estrellas[i]==true) 
		{
			if(i==ejerM_3estrellas.Length-1)
			{
				//mision completada
				misionRobotCompletada=true;
			}
			i++;
		}
		if (i < ejerM_3estrellas.Length && ejerM_3estrellas [i] == false) 
		{
			print("Ejercicio "+i+" no completado FULL");
		}

	}
	void Awake ()
	{
		
		if (cont == null) {
			cont = this;
			DontDestroyOnLoad (gameObject);
		} else if (cont != this) {
			Destroy(gameObject);
		}
	}
}
