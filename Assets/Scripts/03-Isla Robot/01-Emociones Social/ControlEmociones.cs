using UnityEngine;
using System.Collections;

public class ControlEmociones : MonoBehaviour 
{
	public static ControlEmociones cont;

	public int Intentos=1;
	public int aciertos=0;
	public bool[] ASocialNivel1;
	public bool[] ASocialNivel3;
	public bool[] AEmociones;
	public int EjercicioSocial=0;
	public int NivelEmpatia=0;
	public int NivelEmociones=0;

	public bool respuesta;
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
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
