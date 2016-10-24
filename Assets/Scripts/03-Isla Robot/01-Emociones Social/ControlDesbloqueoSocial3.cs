using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlDesbloqueoSocial3 : MonoBehaviour {

	ControlEmociones CE;
	public Sprite[] imagenes_unlocked;
	public Sprite[] imagenes_Locked;
	
	public GameObject[] Acontrol_Social3;
	int i;
	
	// Use this for initialization
	void Start () 
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		
		for (i=0; i<CE.ASocialNivel1.Length; i++) 
		{
			if(CE.ASocialNivel3[i]==true)
			{
				Acontrol_Social3[i].GetComponent<Image>().sprite = imagenes_unlocked[i];
				Acontrol_Social3[i].GetComponent<Button>().enabled=true;
			}
			else if(CE.ASocialNivel3[i]==false)
			{
				Acontrol_Social3[i].GetComponent<Image>().sprite=imagenes_Locked[i];
				Acontrol_Social3[i].GetComponent<Button>().enabled=false;
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
