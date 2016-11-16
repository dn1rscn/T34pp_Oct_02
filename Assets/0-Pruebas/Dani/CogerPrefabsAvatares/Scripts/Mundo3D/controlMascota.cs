using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlMascota : MonoBehaviour {

	//******************************************************************************************
	//
	//					I.A. DE SEGUIMIENTO PARA LA MASCOTA
	//
	//		Aplicar directamente al gameObject de la mascota 
	//
	//		Indicaciones:
	//			1.- Introducir, a traves del editor, un objetivo (Prota) al que seguir
	//			2.- El gameObject con este script debe tener:
	//				2.1- Rigidbody
	//				2.2- NavMeshAgent
	//				2.3- Animator
	//
	//******************************************************************************************

	public Transform gObj_Prota; //Prota que debemos definir en el editor
	public float distanciaProta; //Distancia entre la mascota y el Prota

	NavMeshAgent agente_mascota;
	Animator animator_mascota;

	bool seguir; //Booleana que debe estar activa siempre que queramos que la mascota avance hacia el objetivo
		
	void Start () 
	{
	//Obtenemos el navMeshAgent y el Animator de la mascota
		agente_mascota = gameObject.GetComponent<NavMeshAgent>();
		animator_mascota =GetComponent<Animator>();
	}

	void Update()
	{	
						//*** GESTION DE LAS ANIMACIONES ***

		// 1º.- Si la mascota esta a mas de 20 unidades del objetivo, ejecutamos y mantenemos la 
			// animacion de correr
		if (agente_mascota.remainingDistance>=13) 
		{
			agente_mascota.speed = 10f;
			animator_mascota.SetBool ("correr", true);
		}

		// 2º.- Si la mascota esta a menos de 15 pero a mas de 7 unidades del objetivo, ejecutamos y mantenemos la 
			// animacion de andar
		else if (agente_mascota.remainingDistance>=7)  //*Hacer coincidir este parametro con el stopping distance del NavMeshAgent
		{
			agente_mascota.speed = 4f;
			animator_mascota.SetBool ("andar", true);
			animator_mascota.SetBool ("correr", false);
		}

		// 3º.- Si la mascota esta a 7 unidades o menos del objetivo, ejecutamos la animacion de reposo
			// y sesactivamos la booleana "seguir"
		else
		{
			animator_mascota.SetBool ("andar", false);
			seguir=false;
		}
	}

	void FixedUpdate () 
	{
	//Calculamos la distancia entre la mascota y el prota en todo momento
		distanciaProta = Vector3.Distance (gObj_Prota.position, transform.position);
	//Si esa distancia es mayor que 10 unidades, activamos la booleana "seguir"
		if(distanciaProta>10){
			seguir=true;
		}
	//Siempre que este activa la booleana "seguir", mandamos a la mascota a la posicion del objetivo
		if(seguir)
		{
			agente_mascota.SetDestination(gObj_Prota.transform.position);
		}
	}
}
