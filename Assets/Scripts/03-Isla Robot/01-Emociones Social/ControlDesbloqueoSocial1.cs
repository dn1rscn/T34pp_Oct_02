using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlDesbloqueoSocial1 : MonoBehaviour 
{
	ControlEmociones CE;
	public Sprite[] imagenes_unlocked;
	public Sprite[] imagenes_Locked;

	public GameObject[] Acontrol_Social1;
	int i;

	// Use this for initialization
	void Start () 
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		
		for (i=0; i<CE.ASocialNivel1.Length; i++) 
		{
			if(CE.ASocialNivel1[i]==true)
			{
				Acontrol_Social1[i].GetComponent<Image>().sprite = imagenes_unlocked[i];
				Acontrol_Social1[i].GetComponent<Button>().enabled=true;
			}
			else if(CE.ASocialNivel1[i]==false)
			{
				Acontrol_Social1[i].GetComponent<Image>().sprite=imagenes_Locked[i];
				Acontrol_Social1[i].GetComponent<Button>().enabled=false;
			}
		}

		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void Desbloqueo_Nivel1()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		
		for (i=0; i<CE.ASocialNivel1.Length; i++) 
		{
			if(CE.ASocialNivel1[i]==true)
			{
				Acontrol_Social1[i].GetComponent<Image>().sprite = imagenes_unlocked[i];
				Acontrol_Social1[i].GetComponent<Button>().enabled=true;
			}
			else if(CE.ASocialNivel1[i]==false)
			{
				Acontrol_Social1[i].GetComponent<Image>().sprite=imagenes_Locked[i];
				Acontrol_Social1[i].GetComponent<Button>().enabled=false;
			}
		}
	}
	public void Desbloqueo_Nivel3()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		
		for (i=0; i<CE.ASocialNivel1.Length; i++) 
		{
			if(CE.ASocialNivel3[i]==true)
			{
				Acontrol_Social1[i].GetComponent<Image>().sprite = imagenes_unlocked[i];
				Acontrol_Social1[i].GetComponent<Button>().enabled=true;
			}
			else if(CE.ASocialNivel3[i]==false)
			{
				Acontrol_Social1[i].GetComponent<Image>().sprite=imagenes_Locked[i];
				Acontrol_Social1[i].GetComponent<Button>().enabled=false;
			}
		}

	}
}
