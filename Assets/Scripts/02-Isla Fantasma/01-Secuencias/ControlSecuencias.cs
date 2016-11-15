using UnityEngine;
using System.Collections;

public class ControlSecuencias : MonoBehaviour 
{
	public static ControlSecuencias cont;

	public bool p1=false;
	public bool p2=false;
	public bool p3=false;
	public int fallos=0;
	public bool[] Asecuencias;
	public int Secuencia;

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
