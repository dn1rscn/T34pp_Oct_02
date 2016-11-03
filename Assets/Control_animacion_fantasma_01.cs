using UnityEngine;
using System.Collections;

public class Control_animacion_fantasma_01 : MonoBehaviour 
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
			GameObject fantasma = GameObject.Find ("fantasma_bake_v2");
			Animator fantasma_animator = fantasma.GetComponent<Animator> ();
			fantasma_animator.SetBool ("bSaludar", true);
		}

		
		
		
	}
	void OnTriggerExit(Collider coli)
	{
		
		
		if (coli.gameObject.name == "Chico_TEAPlay") 
		{
			GameObject fantasma = GameObject.Find ("fantasma_bake_v2");
			Animator fantasma_animator = fantasma.GetComponent<Animator> ();
			fantasma_animator.SetBool ("bSaludar", false);
		}

		
	}
}
