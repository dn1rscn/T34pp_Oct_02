using UnityEngine;
using System.Collections;

public class Interface_Mundo : MonoBehaviour 
{
	control_datosGlobalesPersonalizacion cdgP;

	public GameObject Bcerrar;
	public GameObject Babrir;

	// Use this for initialization
	void Start () 
	{
		GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
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
		Bcerrar.SetActive (true);
		Babrir.SetActive (false);
		GameObject.Find ("cuadro").GetComponent<Animator> ().Play ("abrir");
		GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2> ().enabled = false;
		//Time.timeScale = 0;
	}
	public void Mapa()
	{
		Time.timeScale = 1;
		Application.LoadLevel ("Mapa");
	}
	public void PersonalizacionJuego()
	{
		cdgP = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();
		Time.timeScale = 1;
		//print ("hola");
		cdgP.inicio = false;
		Application.LoadLevel ("personalizacion2.0");
	}
	public void pause()
	{
		Time.timeScale = 0;
	}
}
