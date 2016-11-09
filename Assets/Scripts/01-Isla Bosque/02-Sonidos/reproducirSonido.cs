using UnityEngine;
using System.Collections;

public class reproducirSonido : MonoBehaviour 
{

	public AudioSource[] ASonidos;
	public bool[] SonidosOK;

	ControlSonidos CS;
	RespuestaSonidos RS;

	//public GameObject MaquinaDiscos;


	/*public AudioSource Olla;
	public AudioSource Timbre;
	public AudioSource Telefono;
	public AudioSource Micro;*/
	public GameObject BotonPlay;
	public GameObject BotonRepetir;
	public ParticleSystem Particulasmusica; 


	
	public int SonidoAleatorio;
	int sonidoOK;
	
	// Use this for initialization
	void Start () 
	{
		CS = GameObject.Find ("ctrSonidos").GetComponent<ControlSonidos> ();
		//BotonPlay.SetActive (true);
		//BotonRepetir.SetActive (false);
		Particulasmusica.gameObject.SetActive (false); 

	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void Repetir()
	{
		if (RS.respuesta == true) 
		{
			//animacion boton play
			GameObject.Find("Isla_Bosque_Boton_Play").GetComponent<Animator>().Play ("anim_Play");
		} 
		else 
		{
			ASonidos [SonidoAleatorio].Play ();

		}

	}
	
	public void StopSonido()
	{
		ASonidos [SonidoAleatorio].Stop ();
		Particulasmusica.Stop(); 
		/*for (int i=0; i<ASonidos.Length; i++) 
		{
			ASonidos [i].Stop ();
		}*/
	}

	public void Reproducir()
	{
		RS = GameObject.Find ("control respuesta").GetComponent<RespuestaSonidos> ();

		if (RS.respuesta == true) 
		{
			RS.respuesta = false;

			//MaquinaDiscos.GetComponent<Animation> ().Play ("play");
			//MaquinaDiscos.GetComponent<Animation> ().Play ("disco");


			while(SonidosOK[SonidoAleatorio]==true)
			{
				SonidoAleatorio = Random.Range (0, 4);

			}
			sonidoOK = SonidoAleatorio;
			ASonidos [sonidoOK].Play ();
			Particulasmusica.gameObject.SetActive (true); 
			Particulasmusica.Play(); 
			//BotonPlay.SetActive (false);
			//BotonRepetir.SetActive (true);

		} else if (RS.respuesta == false) 
		{
			//MENSAJE MASCOTA NO HAY RESPUESTA
		}
		
	}
}