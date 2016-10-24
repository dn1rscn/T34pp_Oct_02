using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlSituaciones : MonoBehaviour 
{
	public Sprite[] Asituacion;
	public Button Sit1;
	public Button Sit2;
	public Button Sit3;
	int situa1;
	int situa2;
	int situa3;

	// Use this for initialization
	void Start () 
	{
		situacion1 ();
		situacion2 ();
		situacion3 ();
		print (Sit1.GetComponent<Image>().sprite);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void situacion1()
	{
		situa1 = Random.Range (0, 3);
		Sit1.GetComponent<Image> ().sprite = Asituacion [situa1];
	}
	void situacion2()
	{
		situa2 = Random.Range (0, 3);
		while (situa2==situa1)
		{
			situa2 = Random.Range (0,3);
		}

		Sit2.GetComponent<Image> ().sprite = Asituacion [situa2];
	}
	void situacion3()
	{
		situa3 = Random.Range (0, 3);
		while (situa3==situa1||situa3==situa2)
		{
			situa3 = Random.Range (0,3);
		}
		
		Sit3.GetComponent<Image> ().sprite = Asituacion [situa3];
	}
}
