using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class Control_sonidos_fantasma : MonoBehaviour
{
	public AudioSource fallofantasma; 
	public AudioSource aciertofantasma;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void Aciertofantasma ()
	{
		aciertofantasma.Play (); 
	}
	void Fallofantasma ()
	{
		fallofantasma.Play (); 
	}
}
