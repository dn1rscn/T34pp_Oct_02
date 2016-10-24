using UnityEngine;
using System.Collections;

public class ControlRandomEscena1_3 : MonoBehaviour 
{
	public GameObject Btn1;
	public GameObject Btn2;
	public GameObject Btn3;
	public GameObject Btn4;
	public GameObject Btn5;
	public GameObject Btn6;
	public GameObject Btn7;
	public GameObject Btn8;
	public GameObject Btn9;



	public int ImgRandom;

	// Use this for initialization
	void Start () 
	{
		ImgRandom = Random.Range(1,4);
		switch (ImgRandom)
		{
		
		case 4:
			//null;
			break;

		case 3:
			Btn1.SetActive(true);
			Btn2.SetActive(true);
			Btn3.SetActive(true);
			Btn4.SetActive(false);
			Btn5.SetActive(false);
			Btn6.SetActive(false);
			Btn7.SetActive(false);
			Btn8.SetActive(false);
			Btn9.SetActive(false);
			break;
		case 2:
			Btn1.SetActive(false);
			Btn2.SetActive(false);
			Btn3.SetActive(false);
			Btn4.SetActive(true);
			Btn5.SetActive(true);
			Btn6.SetActive(true);
			Btn7.SetActive(false);
			Btn8.SetActive(false);
			Btn9.SetActive(false);
			break;
		case 1:
			Btn1.SetActive(false);
			Btn2.SetActive(false);
			Btn3.SetActive(false);
			Btn4.SetActive(false);
			Btn5.SetActive(false);
			Btn6.SetActive(false);
			Btn7.SetActive(true);
			Btn8.SetActive(true);
			Btn9.SetActive(true);
			break;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}



}
