using UnityEngine;
using System.Collections;

public class AddButtons2 : MonoBehaviour 
{
	[SerializeField]
	private Transform puzzleField;
	
	[SerializeField]
	private GameObject btn;
	public int numeroDeFotos;
	
	
	/*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
		
		void Awake ()
	{
		for (int i = 0; i < numeroDeFotos; i++)
		{
			GameObject boton = Instantiate(btn);
			boton.name = i.ToString();
			boton.transform.SetParent(puzzleField, false);
		}
	}
}
