using UnityEngine;
using System.Collections;

public class AddButtons3 : MonoBehaviour 
{
	[SerializeField]
	private Transform puzzleField;
	
	[SerializeField]
	private GameObject btn;
	
	
	/*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
		
		void Awake ()
	{
		for (int i = 0; i < 16; i++)
		{
			GameObject boton = Instantiate(btn);
			boton.name = i.ToString();
			boton.transform.SetParent(puzzleField, false);
		}
	}
}
