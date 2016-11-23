using UnityEngine;
using System.Collections;

public class ControlMenu : MonoBehaviour 
{
	ControlEmociones CE;
	ControlDesbloqueoSocial1 CDE;

	// Use this for initialization
	void Start () 
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CDE = GameObject.Find ("ctrDesloqueoSocial").GetComponent<ControlDesbloqueoSocial1> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void MenuEjercicios()
	{
		GameObject.Find ("Canvas").GetComponent<Animator> ().Play ("Bajar");
	}
	public void MenuNiveles()
	{
		GameObject.Find ("Canvas").GetComponent<Animator> ().Play ("Subir");
	}
	public void Globo()
	{
		CE.EjercicioSocial = 1;
		Application.LoadLevel ("Emociones_Empatia");

	}
	public void helado()
	{
		CE.EjercicioSocial = 2;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void Tormenta()
	{
		CE.EjercicioSocial = 3;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void Nivel1()
	{
		CE.NivelEmpatia = 1;
		CDE.Desbloqueo_Nivel1 ();
		GameObject.Find ("Canvas").GetComponent<Animator> ().Play ("Bajar");
	}
	public void Nivel2()
	{
		CE.NivelEmpatia = 2;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void Nivel3()
	{
		CE.NivelEmpatia = 3;
		CDE.Desbloqueo_Nivel3 ();
		GameObject.Find ("Canvas").GetComponent<Animator> ().Play ("Bajar");
	}
}
