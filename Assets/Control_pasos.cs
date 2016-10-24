using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Control_pasos : MonoBehaviour 
{

	void Playsound()

	{
		GetComponent<AudioSource> ().Play ();
	}
	void  Stopsound ()
	{
		GetComponent<AudioSource> ().Stop ();
	}
}
