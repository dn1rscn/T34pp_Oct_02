using UnityEngine;
using System.Collections;

public class Control_animacion_mascotas_altar_01 : MonoBehaviour 
{
	
	public bool bAccion;
	
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
			dino_animator.SetBool ("bSaludo", true);
		}
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			GameObject robot = GameObject.Find ("robot_animaciones_bake_v2");
			Animator robot_animator = robot.GetComponent<Animator> ();
			robot_animator.SetBool ("bSaludo", true);
		}
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			GameObject fantasma = GameObject.Find ("fantasma_bake_v2");
			Animator fantasma_animator = fantasma.GetComponent<Animator> ();
			fantasma_animator.SetBool ("bSaludo", true);
		}
		
		
		
	}
	void OnTriggerExit(Collider coli)
	{
		
		
		
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			GameObject dino = GameObject.Find ("Dinoi_animaciones_v3");
			Animator dino_animator = dino.GetComponent<Animator> ();
			dino_animator.SetBool ("bSaludo", false);
		}
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			GameObject robot = GameObject.Find ("robot_animaciones_bake_v2");
			Animator robot_animator = robot.GetComponent<Animator> ();
			robot_animator.SetBool ("bSaludo", false);
		}
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			GameObject fantasma = GameObject.Find ("fantasma_bake_v2");
			Animator fantasma_animator = fantasma.GetComponent<Animator> ();
			fantasma_animator.SetBool ("bSaludo", false);
		}
		
		
		
	}
}
