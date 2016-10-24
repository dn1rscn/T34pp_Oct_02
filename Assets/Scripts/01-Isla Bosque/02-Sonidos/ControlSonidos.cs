using UnityEngine;
using System.Collections;

public class ControlSonidos : MonoBehaviour 
{
	public static ControlSonidos cont;

	public int nivel=0;
	public int fallos=0;
	public int aciertos=0;
	public int posicion;
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void Awake ()
	{
		
		if (cont == null) {
			cont = this;
			DontDestroyOnLoad (gameObject);
		} else if (cont != this) {
			Destroy(gameObject);
		}
	}
}
