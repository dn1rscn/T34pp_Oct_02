using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlCartel : MonoBehaviour 
{
	//Renderer RenderCartel1;
	//Renderer RenderCartel2;
	//Renderer RenderCartel3;
	Sprite ImCartel1;
	Sprite ImCartel2;
	Sprite ImCartel3;

	ControlDatosGlobales_PICTOGRAMAS cdg;
	GameObject DGlobales;

	// Use this for initialization
	void Start () 
	{
		DGlobales = GameObject.Find ("DatosGlobales");
		cdg = DGlobales.GetComponent<ControlDatosGlobales_PICTOGRAMAS> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//RESPUESTA CORRECTA EN CARTEL
	public void carteles()
	{
		DGlobales = GameObject.Find ("DatosGlobales");
		cdg = DGlobales.GetComponent<ControlDatosGlobales_PICTOGRAMAS> ();

		cdg.correcto = Random.Range (1,4);
		print ("cartel correcto "+cdg.correcto);
		switch (cdg.correcto) 
		{
		case 1:					//respuesta correcta en cartel1
			//ImCartel1 = cdg.Cartel1.GetComponent<Image> ().sprite;
			//ImCartel1 = cdg.pictogramas[cdg.PicAleat];
			cdg.Cartel1.GetComponent<Image> ().sprite=cdg.pictogramas[cdg.PicAleat];
			cartel2();
			cartel3();
			break;
			
		case 2:					//respuesta correcta en cartel2
			//ImCartel2 = cdg.Cartel2.GetComponent<Image> ().sprite;
			//ImCartel2 = cdg.pictogramas[cdg.PicAleat];
			cdg.Cartel2.GetComponent<Image> ().sprite=cdg.pictogramas[cdg.PicAleat];
			cartel1 ();
			cartel3 ();
			break;
			
		case 3:					//respuesta correcta en carte3
			//ImCartel3 = cdg.Cartel3.GetComponent<Renderer> ();
			//ImCartel3 = cdg.Cartel3.GetComponent<Image>().sprite; 
			//RenderCartel3.sharedMaterial = cdg.pictogramas[cdg.PicAleat];
			//ImCartel3 = cdg.pictogramas[cdg.PicAleat];
			cdg.Cartel3.GetComponent<Image> ().sprite=cdg.pictogramas[cdg.PicAleat];
			cartel1 ();
			cartel2 ();
			break;
		
		default:
			break;
		}

	}

	//FUNCIONES PARA LOS CARTELES. NO SE REPITEN OPCIONES
	void cartel1 ()
	{
		cdg.cart1 = Random.Range (0, cdg.pictogramas.Length);
		while (cdg.cart1==cdg.PicAleat||cdg.cart1==cdg.cart2||cdg.cart1==cdg.cart3)
		{
			cdg.cart1 = Random.Range (0, cdg.pictogramas.Length);
		}
	
		//RenderCartel1 = cdg.Cartel1.GetComponent<Renderer> ();
		//RenderCartel1.sharedMaterial = cdg.pictogramas[cdg.cart1];
		cdg.Cartel1.GetComponent<Image> ().sprite=cdg.pictogramas[cdg.cart1];
	}
	void cartel2 ()
	{
		cdg.cart2 = Random.Range (0, cdg.pictogramas.Length);
		while (cdg.cart2==cdg.PicAleat||cdg.cart2==cdg.cart1||cdg.cart2==cdg.cart3)
		{
			cdg.cart2 = Random.Range (0, cdg.pictogramas.Length);
		}
	
		//RenderCartel2 = cdg.Cartel2.GetComponent<Renderer> ();
		//RenderCartel2.sharedMaterial = cdg.pictogramas[cdg.cart2];
		cdg.Cartel2.GetComponent<Image> ().sprite=cdg.pictogramas[cdg.cart2];
	}
	void cartel3 ()
	{	
		cdg.cart3 = Random.Range (0, cdg.pictogramas.Length);
		while (cdg.cart3==cdg.PicAleat||cdg.cart3==cdg.cart2||cdg.cart3==cdg.cart1)
		{
			//print ("cambio cartel 3");
			cdg.cart3 = Random.Range (0,cdg.pictogramas.Length);
			//print (cdg.cart3);
		}
		//RenderCartel3 = cdg.Cartel3.GetComponent<Renderer> ();
		//RenderCartel3.sharedMaterial = cdg.pictogramas[cdg.cart3];
		cdg.Cartel3.GetComponent<Image> ().sprite=cdg.pictogramas[cdg.cart3];
	}
}
