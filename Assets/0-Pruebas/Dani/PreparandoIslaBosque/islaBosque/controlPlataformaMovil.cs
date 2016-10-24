using UnityEngine;
using System.Collections;

public class controlPlataformaMovil : MonoBehaviour {


	public GameObject Prota;
	public GameObject parentOriginal;

	Animator animator_Plataforma;
	Animator animator_Avatar;

	NavMeshAgent agente_Prota;

	bool comprobarEstadoPlataforma = false;
	bool triggerActivo=true;

	void Start(){
		animator_Plataforma = GameObject.Find ("Isla_Bosque_V02Puente_Activado").GetComponent<Animator>();
		agente_Prota = Prota.GetComponent<NavMeshAgent>();
		animator_Avatar =Prota.GetComponent<Animator>();

	}

	void OnTriggerEnter(Collider coli){
		if (coli.gameObject.name == Prota.name && triggerActivo) {
			triggerActivo=false;  //desactivamos el trigger de subida una vez usado para no tener problemas despues

			//DESHABILITAR EL CONTROL DEL JUGADOR
			Prota.GetComponent<ControlProtaMouse_2>().enabled=false;

			//MANDAR AL PROTA A LA POSICION 1 DE LA PLATAFORMA
			agente_Prota.SetDestination(GameObject.Find("point_dn_entrar").transform.position);

			Invoke("pararAnimacionAndar",1);
				
			//DESACTIVAR NAVMESHAGENT Y RIGIDBODY
			Invoke("desactivarNavMeshAgent_Prota",1);

			//ACTIVAR LA ANIMACION DE SUBIR PLATAFORMA
			Invoke("subirPlataforma",5/4);
			print ("SUBIENDO EN LA PLATAFORMA");
		}
		
	}

	public void bajarPlataforma(){
		print("bajar de la plataforma");
		//Prota=GameObject.Find("Prota_TEAPlay");

		GameObject.Find("Prota_TEAPlay").transform.parent = parentOriginal.transform;

		print("devueltoAlParentOriginal");

		//ACTIVAR EL NAVMESHAGENT Y EL RIGIDBODY
		GameObject.Find("Prota_TEAPlay").GetComponent<Rigidbody>().isKinematic=false;
		GameObject.Find("Prota_TEAPlay").GetComponent<NavMeshAgent>().enabled=true;

		//MANDAR AL PROTA A LA POSICION 3 DE LA PLATAFORMA (en la isla de arriba)
		//agente_Prota.SetDestination(GameObject.Find("point_up_salir").transform.position);

		//HABILITAR EL CONTROL DEL JUGADOR
		GameObject.Find("Prota_TEAPlay").GetComponent<ControlProtaMouse_2>().enabled=true;
	}

	void pararAnimacionAndar(){
		animator_Avatar.SetBool("andar",false);
		Prota.transform.parent = gameObject.transform;
	}
	void desactivarNavMeshAgent_Prota(){
		agente_Prota.Stop();

		agente_Prota.enabled=false;
		print ("navMeshDesactivado");

		Prota.GetComponent<Rigidbody>().isKinematic=true;
		print ("RigidBodyDesactivado");
		
	}
	void subirPlataforma(){
		animator_Plataforma.SetBool("subir",true);
	}
	
	
}
