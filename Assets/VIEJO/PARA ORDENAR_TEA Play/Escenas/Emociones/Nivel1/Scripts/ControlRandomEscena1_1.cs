using UnityEngine;
using System.Collections;

public class ControlRandomEscena1_1 : MonoBehaviour 
{
	public GameObject Btn1;
	public GameObject Btn2;
	public GameObject Btn3;
	public GameObject Btn4;

	public int ImgRandom;

	// Use this for initialization
	void Start () 
	{
		ImgRandom = Random.Range(1,3);
		switch (ImgRandom)
		{
		case 3:
			//null
			break;
		case 2:
			Btn1.SetActive(false);
			Btn2.SetActive(false);
			Btn3.SetActive(true);
			Btn4.SetActive(true);
			break;
		case 1:
			Btn1.SetActive(true);
			Btn2.SetActive(true);
			Btn3.SetActive(false);
			Btn4.SetActive(false);
			break;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}



}
