using UnityEngine;
using System.Collections;

public class Control_animaciondino_saludar : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnTriggerEnter(Collider coli)
		
	{
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			GameObject dino = GameObject.Find ("Dinoi_animaciones_v3");
			Animator dino_animator = dino.GetComponent<Animator> ();
			dino_animator.SetBool ("bAccionDino", true);
		}
		
	}
	void OnTriggerExit(Collider coli)
	{
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			GameObject dino = GameObject.Find ("Dinoi_animaciones_v3");
			Animator dino_animator = dino.GetComponent<Animator> ();
			dino_animator.SetBool ("bAccionDino", false);
		}
		
	}
}
