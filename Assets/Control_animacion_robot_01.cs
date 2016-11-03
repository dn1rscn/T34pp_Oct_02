using UnityEngine;
using System.Collections;

public class Control_animacion_robot_01 : MonoBehaviour 
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
			GameObject robot = GameObject.Find ("robot_animaciones_bake_v2");
			Animator robot_animator = robot.GetComponent<Animator> ();
			robot_animator.SetBool ("bSaludar", true);
		}
		
		
		
		
	}
	void OnTriggerExit(Collider coli)
	{
		
		

			if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			GameObject robot = GameObject.Find ("robot_animaciones_bake_v2");
			Animator robot_animator = robot.GetComponent<Animator> ();
			robot_animator.SetBool ("bSaludar", false);
		}
		
		
	}
}