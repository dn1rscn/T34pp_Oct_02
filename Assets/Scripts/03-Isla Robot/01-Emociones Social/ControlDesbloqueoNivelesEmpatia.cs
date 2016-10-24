using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlDesbloqueoNivelesEmpatia : MonoBehaviour 
{
	DatosDesbloqueo DD;

	public Sprite[] UnLock;
	public Sprite[] Lock;

	public GameObject[] Niveles;

	int i;

	// Use this for initialization
	void Start () 
	{
		DD = GameObject.Find ("ctrDesbloqueo").GetComponent<DatosDesbloqueo> ();

		for (i=0; i<DD.AEmpatia.Length; i++) 
		{
			if(DD.AEmpatia[i]==true)
			{
				Niveles[i].GetComponent<Image>().sprite = UnLock[i];
				Niveles[i].GetComponent<Button>().enabled=true;
			}
			else if(DD.AEmpatia[i]==false)
			{
				Niveles[i].GetComponent<Image>().sprite=Lock[i];
				Niveles[i].GetComponent<Button>().enabled=false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
