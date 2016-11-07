using UnityEngine;
using System.Collections;

public class ControlDado : MonoBehaviour 
{
	Rigidbody rbd;

	public float fuerzaSalto;

	float fuerzaGiroX;
	float fuerzaGiroY;
	float fuerzaGiroZ;

	Renderer miRender;		 

	public float tiempo;

	int PicAleat;

	ControlDatosGlobales_PICTOGRAMAS cdg;
	GameObject DGlobales;

	ControlCartel CC;
	GameObject cartel;

	bool lanzar = true;


	void Start () 
	{
		DGlobales = GameObject.Find ("DatosGlobales");			
		cdg = DGlobales.GetComponent<ControlDatosGlobales_PICTOGRAMAS> ();
		
		cartel = GameObject.Find ("carteles");
		CC = cartel.GetComponent<ControlCartel> ();

		rbd = GetComponent<Rigidbody> ();


		cdg.resp=true;


	//inicio de la escena aleatorio

		/*cdg.PicAleat = Random.Range (0, pictogramas.Length);		
		miRender = GetComponent<Renderer> ();
		miRender.sharedMaterial = pictogramas [cdg.PicAleat];
		CC.carteles ();
		*/
	}
	

	void salto()			//funcion salto dado
	{
		//rbd.AddForce (0f, fuerzaSalto, 0f); 						//fuerza para el salto
		//rbd.AddTorque (fuerzaGiroX, fuerzaGiroY, fuerzaGiroZ); 		//fuerza de giro
		GameObject.Find ("Dado").GetComponent<Animator> ().Play ("Salto_Dado");
	}


	void OnMouseDown ()
	{
		DGlobales = GameObject.Find ("DatosGlobales");
		cdg = DGlobales.GetComponent<ControlDatosGlobales_PICTOGRAMAS> ();

		cartel = GameObject.Find ("carteles");
		CC = cartel.GetComponent<ControlCartel> ();

		//LANZAMIENTO
		if (lanzar == true && cdg.resp==true) 				//si no hay respuesta y el dado no esta en el suelo no se puede lanzar			
		{

			//fuerzaGiroX = Random.Range (200f, 200000f);      			//fuerza de giro (x, y, z) aleatorias
			//fuerzaGiroY = Random.Range (200f, 200000f);
			//fuerzaGiroZ = Random.Range (200f, 200000f);


			cdg.PicAleat = Random.Range (0, cdg.pictogramas.Length); 			//pictograma aleatorio

			miRender = GetComponent<Renderer> ();
			Invoke("pictogramaAleatorio",tiempo);			//pictograma aleatorio


			salto ();

			CC.carteles ();
			lanzar = false;			//dado no esta en suelo
			cdg.resp = false;		//no hay respuesta
		}
		//MENSAJE CUANDO NO HAY RESPUESTA
		else 
		{
			print ("no respuesta");	
		}


	}

	//SUELO
	void OnCollisionEnter (Collision coli)			//detectamos que el dado esta en el suelo
	{
		if (coli.gameObject.name == "Suelo") 
		{
			lanzar = true;
		} 
	}

	void pictogramaAleatorio()
	{
		miRender.sharedMaterial = cdg.ImDado [cdg.PicAleat];			//cambio de pictograma DEL DADO Y DE LA RESPUESTA CORRECTA

	}

}
