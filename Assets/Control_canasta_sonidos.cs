using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]



public class Control_canasta_sonidos : MonoBehaviour 
{
	public AudioSource encestar;
	public AudioSource musicacierto;

	void start () 
	{
		AudioSource[] SonidosCancha = GetComponents<AudioSource> ();
		encestar = SonidosCancha [0];
		musicacierto = SonidosCancha [1];

	}
	void Encestar() 
	{
		encestar.Play (); 
	}
	void Musicaacierto()
	{
		musicacierto.Play (); 
	}

}
