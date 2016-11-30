using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class Control_sonidos_dino : MonoBehaviour
{
	public AudioSource fallodino; 
	public AudioSource aciertodino;
	
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void Aciertodino ()
	{
		aciertodino.Play (); 
	}
	void Fallodino ()
	{
		fallodino.Play (); 
	}
}