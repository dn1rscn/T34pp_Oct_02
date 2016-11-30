using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class Control_sonidos_robot : MonoBehaviour
{
	public AudioSource fallorobot; 
	public AudioSource aciertorobot;
	
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void Aciertorobot ()
	{
		aciertorobot.Play (); 
	}
	void Fallorobot ()
	{
		fallorobot.Play (); 
	}
}