using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlRespAleatoria : MonoBehaviour 
{
	public Sprite[] AImRespuesta;
	public GameObject[] ARespuestas;
	
	public int RespuestaAleat;

	// Use this for initialization
	void Start () 
	{
		RespuestaAleat = Random.Range (1, 3);
		//ARespuestas [0].GetComponent<Image> ().sprite = AImRespuesta [RespuestaAleat];
		switch (RespuestaAleat) 
		{
		case 1:					//respuesta correcta en cartel1
			ARespuestas [0].GetComponent<Image> ().sprite = AImRespuesta [1];
			ARespuestas [1].GetComponent<Image> ().sprite = AImRespuesta [0];
			break;
			
		case 2:					//respuesta correcta en cartel2
			ARespuestas [1].GetComponent<Image> ().sprite = AImRespuesta [1];
			ARespuestas [0].GetComponent<Image> ().sprite = AImRespuesta [0];
			break;
			
		default:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
