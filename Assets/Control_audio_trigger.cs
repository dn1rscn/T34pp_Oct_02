using UnityEngine;
using System.Collections;

public class Control_audio_trigger : MonoBehaviour 

{
	public AudioClip mush; 
	// Use this for initialization
	void Start ()
	{
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = mush;

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter(Collider coli)

	{
		GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().volume=0.35f;
		GetComponent<AudioSource> ().Play ();
	}

	void OnTriggerExit(Collider coli)

	{
		GetComponent<AudioSource> ().volume=0.15f;
		Invoke("pararSonido",1);

	}

	void pararSonido()
	{
		GetComponent<AudioSource> ().Stop ();


	}
}
