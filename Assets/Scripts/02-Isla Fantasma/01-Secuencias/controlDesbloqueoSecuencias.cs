using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlDesbloqueoSecuencias : MonoBehaviour 
{
	GameObject ctrlsecuencias;
	ControlSecuencias cs;
	public Sprite[] imagenes_unlocked;
	public Sprite[] imagenes_Locked;


	public GameObject[] Acontrol_secuencias;
	int i;

	// Use this for initialization
	void Start () 
	{
		ctrlsecuencias = GameObject.Find ("DatosGlobalesSecuencias");
		cs = ctrlsecuencias.GetComponent<ControlSecuencias> ();

		for (i=0; i<cs.Asecuencias.Length; i++) 
		{
			if(cs.Asecuencias[i]==true)
			{
				Acontrol_secuencias[i].GetComponent<Image>().sprite = imagenes_unlocked[i];
				Acontrol_secuencias[i].GetComponent<Button>().enabled=true;
			}
			else if(cs.Asecuencias[i]==false)
			{
				Acontrol_secuencias[i].GetComponent<Image>().sprite=imagenes_Locked[i];
				Acontrol_secuencias[i].GetComponent<Button>().enabled=false;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
