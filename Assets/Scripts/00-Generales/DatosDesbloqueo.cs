using UnityEngine;
using System.Collections;

public class DatosDesbloqueo : MonoBehaviour 
{
	public static DatosDesbloqueo cont;

	public int Posicion;

	public bool Nivel2Dado=false;

	public bool Nivel2Sonidos=false;
	public bool Nivel3Sonidos=false;

	public bool[] ADado;
	public bool[] ASonidos;
	public bool[] AEmpatia;

	// Use this for initialization
	void Start () 
	{
		ADado [0] = true;
		ASonidos [0] = true;
		AEmpatia [0] = true;
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
	
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
