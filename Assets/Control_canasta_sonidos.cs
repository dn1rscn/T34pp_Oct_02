using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]



public class Control_canasta_sonidos : MonoBehaviour 
{
	public AudioSource encestar;
	public AudioSource musicacierto;
	public AudioSource botar; 
	public AudioSource fallo;  
	public AudioSource rebote; 
	public AudioSource golpefantasma;

	void start () 
	{
		AudioSource[] SonidosCancha = GetComponents<AudioSource> ();
		encestar = SonidosCancha [0];
		musicacierto = SonidosCancha [1];
		botar = SonidosCancha [2]; 
		fallo = SonidosCancha [3]; 
		rebote = SonidosCancha [4]; 
		golpefantasma = SonidosCancha [5]; 
		 

	}
	void Encestar() 
	{
		encestar.Play (); 
	}
	void Musicaacierto()
	{
		musicacierto.Play (); 
	}
	void Botar()
	{
		botar.Play (); 
	}
	void Fallo()
	{
		fallo.Play (); 
	}
	void Rebote ()
	{
		rebote.Play (); 
	}
	void Golpefantasma ()
	{
		golpefantasma.Play (); 
	}


}
