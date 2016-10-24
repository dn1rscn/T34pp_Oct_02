using UnityEngine;
using System.Collections;

public class ControlProtaMouse_2 : MonoBehaviour {

	NavMeshAgent agente;
	Animator animatorProta;

	Ray rayoPantalla;

	Animator animatorHaloTarget;
	GameObject gObj_haloTarget;

	//public float distanciaMinima;

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	
	void Start () 
	{
		//Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

		gObj_haloTarget = GameObject.Find ("HaloTarget");

		//print ("HaloDetectado");

		animatorHaloTarget=gObj_haloTarget.GetComponent<Animator>();

		animatorProta =GetComponent<Animator>();

		agente = gameObject.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		rayoPantalla = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit impacto;

		if(agente.remainingDistance >= 0.1) //&& (impacto.point-agente.transform.position).magnitude>= distanciaMinima)
		{
			animatorProta.SetBool ("andar", true);
		}
		else
		{
			animatorProta.SetBool("andar",false);
		}
	

		if(Physics.Raycast(rayoPantalla,out impacto))
		{
			//print ("rayoDetectado");

			//Si queremos que el prota mire siempre al puntero
			//agente.transform.LookAt(impacto.point);
		
			if (Input.GetMouseButtonDown (0)) 
			{
				agente.SetDestination(impacto.point);

				gObj_haloTarget.transform.position = impacto.point;
				animatorHaloTarget.Play("animHalo");	
			}
		}




	
	}
}
