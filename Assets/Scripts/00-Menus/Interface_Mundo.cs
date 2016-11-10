using UnityEngine;
using System.Collections;

public class Interface_Mundo : MonoBehaviour 
{
	control_datosGlobalesPersonalizacion cdgP;

	NavMeshAgent agente;

	public GameObject Bcerrar;
	public GameObject Babrir;

	// Use this for initialization
	void Start () 
	{
		//GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		agente = GameObject.Find ("Chico_TEAPlay").GetComponent<NavMeshAgent> ();
		//print (agente.remainingDistance);
	
	}
	public void cerrar()
	{
		Bcerrar.SetActive (false);
		Babrir.SetActive (true);
		GameObject.Find ("cuadro").GetComponent<Animator> ().Play ("cerrar");
		GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2> ().enabled = true;
		Time.timeScale = 1;
	}
	public void abrir()
	{
		GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2> ().enabled = false;
		Bcerrar.SetActive (true);
		Babrir.SetActive (false);
		agente = GameObject.Find ("Chico_TEAPlay").GetComponent<NavMeshAgent> ();
		GameObject.Find ("cuadro").GetComponent<Animator> ().Play ("abrir");
		agente.destination = GameObject.Find ("Chico_TEAPlay").transform.position;
		GameObject.Find ("Chico_TEAPlay").GetComponent<Animator> ().SetBool("andar",false);
		

		//Time.timeScale = 0;
	}
	public void Mapa()
	{
		GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2> ().enabled = true;
		Time.timeScale = 1;
		Application.LoadLevel ("Mapa");
	}
	public void PersonalizacionJuego()
	{
		GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2> ().enabled = true;
		cdgP = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();
		Time.timeScale = 1;
		//print ("hola");
		cdgP.inicio = false;
		Application.LoadLevel ("personalizacion2.0");
	}
	public void pause()
	{
		//Time.timeScale = 0;
	}
}
