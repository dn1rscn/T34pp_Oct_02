using UnityEngine;
using System.Collections;

public class DatosDesbloqueo : MonoBehaviour 
{
	public static DatosDesbloqueo cont;

	public int Posicion;

	public bool Portal2Bosque=false;
	public bool Portal2Fantasma=false;

	public bool Nivel2Dado=false;

	public bool Nivel2Sonidos=false;
	public bool Nivel3Sonidos=false;

	public bool[] ADado;  //control niveles dado
	public bool[] ASonidos;  //niveles Sonidos
	public bool[] AEmpatia;	//niveles empatia

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
