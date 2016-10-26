using UnityEngine;
using System.Collections;

public class Control_animacionrobot_saludar : MonoBehaviour 
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
			GameObject robot = GameObject.Find ("robot_animaciones_bake");
			Animator robot_animator = robot.GetComponent<Animator> ();
			robot_animator.SetBool ("bAccionRobot", true);
		}
		
	}
	void OnTriggerExit(Collider coli)
	{
		
		
	}
}