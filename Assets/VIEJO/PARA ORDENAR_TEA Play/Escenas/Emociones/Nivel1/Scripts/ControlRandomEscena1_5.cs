using UnityEngine;
using System.Collections;

public class ControlRandomEscena1_5 : MonoBehaviour 
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
	public GameObject Btn10;
	public GameObject Btn11;
	public GameObject Btn12;
	public GameObject Btn13;
	public GameObject Btn14;
	public GameObject Btn15;
	public GameObject Btn16;

	
	
	
	public int ImgRandom;
	
	// Use this for initialization
	void Start () 
	{
		ImgRandom = Random.Range(1,5);
		switch (ImgRandom)
		{
		case 5:
			//null;
			break;
		case 4:
			Btn1.SetActive(true);
			Btn2.SetActive(true);
			Btn3.SetActive(true);
			Btn4.SetActive(true);
			Btn5.SetActive(false);
			Btn6.SetActive(false);
			Btn7.SetActive(false);
			Btn8.SetActive(false);
			Btn9.SetActive(false);
			Btn10.SetActive(false);
			Btn11.SetActive(false);
			Btn12.SetActive(false);
			Btn13.SetActive(false);
			Btn14.SetActive(false);
			Btn15.SetActive(false);
			Btn16.SetActive(false);
			break;
			
		case 3:
			Btn1.SetActive(false);
			Btn2.SetActive(false);
			Btn3.SetActive(false);
			Btn4.SetActive(false);
			Btn5.SetActive(true);
			Btn6.SetActive(true);
			Btn7.SetActive(true);
			Btn8.SetActive(true);
			Btn9.SetActive(false);
			Btn10.SetActive(false);
			Btn11.SetActive(false);
			Btn12.SetActive(false);
			Btn13.SetActive(false);
			Btn14.SetActive(false);
			Btn15.SetActive(false);
			Btn16.SetActive(false);

			break;
		case 2:
			Btn1.SetActive(false);
			Btn2.SetActive(false);
			Btn3.SetActive(false);
			Btn4.SetActive(false);
			Btn5.SetActive(false);
			Btn6.SetActive(false);
			Btn7.SetActive(false);
			Btn8.SetActive(false);
			Btn9.SetActive(true);
			Btn10.SetActive(true);
			Btn11.SetActive(true);
			Btn12.SetActive(true);
			Btn13.SetActive(false);
			Btn14.SetActive(false);
			Btn15.SetActive(false);
			Btn16.SetActive(false);
			break;
		case 1:
			Btn1.SetActive(false);
			Btn2.SetActive(false);
			Btn3.SetActive(false);
			Btn4.SetActive(false);
			Btn5.SetActive(false);
			Btn6.SetActive(false);
			Btn7.SetActive(false);
			Btn8.SetActive(false);
			Btn9.SetActive(false);
			Btn10.SetActive(false);
			Btn11.SetActive(false);
			Btn12.SetActive(false);
			Btn13.SetActive(true);
			Btn14.SetActive(true);
			Btn15.SetActive(true);
			Btn16.SetActive(true);

			break;
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	
	
}