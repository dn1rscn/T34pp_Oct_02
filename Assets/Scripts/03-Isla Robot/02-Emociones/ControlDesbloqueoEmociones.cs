using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlDesbloqueoEmociones : MonoBehaviour 
{

	ControlEmociones CE;
	public Sprite[] imagenes_unlocked;
	public Sprite[] imagenes_Locked;
	
	public GameObject[] Acontrol_Emociones;
	int i;
	
	// Use this for initialization
	void Start () 
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		
		for (i=0; i<CE.AEmociones.Length; i++) 
		{
			if(CE.AEmociones[i]==true)
			{
				Acontrol_Emociones[i].GetComponent<Image>().sprite = imagenes_unlocked[i];
				Acontrol_Emociones[i].GetComponent<Button>().enabled=true;
			}
			else if(CE.AEmociones[i]==false)
			{
				Acontrol_Emociones[i].GetComponent<Image>().sprite=imagenes_Locked[i];
				Acontrol_Emociones[i].GetComponent<Button>().enabled=false;
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
