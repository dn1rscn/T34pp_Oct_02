using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlRespuestaSocialNivel1 : MonoBehaviour 
{
	controlRespAleatoria CRA;

	ControlEmociones CE;
	ControlSlider CSlider;
	DatosDesbloqueo DD;

	public GameObject IfinJuego;
	
	//public GameObject BotonVolverGrande;
	
	public GameObject SiguienteSituacion;
	
	Control_monedas cM;
	GameObject ControlMonedas;
	
	GameObject puntuacion;
	Text Tpuntuacion;
	
	GameObject monedasSocialNivel1;
	Text TmonedasSocialNivel1;
	
	GameObject puntuacionfin;
	Text TpuntuacionFin;
	// Use this for initialization
	void Start () 
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CSlider = GameObject.Find ("Progreso").GetComponent<ControlSlider> ();

		CE.respuesta = false;
		actualizarPuntuacion ();
		CSlider.progresoEmocionesSNivel1 ();


	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void respuesta()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();

		if (CE.respuesta == false) 
		{
			CRA = GameObject.Find ("crtRespuesta").GetComponent<controlRespAleatoria> ();
			//print (gameObject.GetComponent<Image> ().sprite);
			print (CRA.RespuestaAleat);
			print (gameObject.name);

			if (gameObject.name == "respuesta1" && CRA.RespuestaAleat == 1) 
			{
				//cdg.resp = true;
				correcto ();
			} else { 
				if (gameObject.name == "respuesta2" && CRA.RespuestaAleat == 2) 
				{
					//cdg.resp = true;
					correcto ();
				} else {
					error ();
				}
			}
		}


	}

	void correcto()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		DD = GameObject.Find ("ctrDesbloqueo").GetComponent<DatosDesbloqueo> ();

		GameObject.Find("Panel_Canvas").GetComponent<Animator>().Play("acierto");

		print ("correcto");
		IfinJuego.SetActive(true);
		
		ControlMonedas = GameObject.Find ("controlMonedas");
		cM = ControlMonedas.GetComponent<Control_monedas> ();
		
		puntuacionfin = GameObject.Find ("puntuacionFin");
		TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
		
		monedasSocialNivel1 = GameObject.Find ("monedas");
		TmonedasSocialNivel1 = monedasSocialNivel1.GetComponent<Text> ();
		
		cM.calcular_monedaSocialNivel1 ();
		cM.calcular_monedasGenerales ();
		if (CE.Intentos == 1) 
		{
			Invoke ("ActivarEstrella1", 1.0f);
			Invoke ("ActivarEstrella2", 2.0f);
			Invoke ("ActivarEstrella3", 3.0f);

			SiguienteSituacion.SetActive (true);
			if(CE.EjercicioSocial<CE.ASocialNivel1.Length)
			{
				CE.ASocialNivel1[CE.EjercicioSocial]=true;
			}
			DD.AEmpatia[1] = true;
		} 
		else 
		{
			if (CE.Intentos == 2) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				Invoke ("ActivarEstrella2", 2.0f);

				SiguienteSituacion.SetActive (true);
				if(CE.EjercicioSocial<CE.ASocialNivel1.Length)
				{
					CE.ASocialNivel1[CE.EjercicioSocial]=true;
				}
				DD.AEmpatia[1] = true;
			} 
			else if (CE.Intentos == 3)
			{
				Invoke ("ActivarEstrella1", 1.0f);

				SiguienteSituacion.SetActive (true);
				if(CE.EjercicioSocial<CE.ASocialNivel1.Length)
				{
					CE.ASocialNivel1[CE.EjercicioSocial]=true;
				}
				DD.AEmpatia[1] = true;
			}
		}


		TpuntuacionFin.text = "\nIntentos: " + CE.Intentos.ToString();
		
		TmonedasSocialNivel1.text = cM.monedasSocialNivel1.ToString();


		CE.Intentos = 1;
		cM.monedasSocialNivel1 = 0;
		CE.respuesta = true;

	}
	void error()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		print ("error");
		GameObject.Find("Panel_Canvas").GetComponent<Animator>().Play("Fallo");

		CE.Intentos++;
		actualizarPuntuacion ();
		CSlider.progresoEmocionesSNivel1 ();
	}
	void actualizarPuntuacion()
	{
		puntuacion = GameObject.Find ("puntuacion");
		Tpuntuacion = puntuacion.GetComponent<Text> ();
		
		Tpuntuacion.text = CE.Intentos.ToString();
	}
	void ActivarEstrella1()
	{
		Debug.Log("estrella1");
		//yield return new WaitForSeconds (2.0f);
		GameObject.Find ("estrellas").GetComponent<Animator> ().Play ("AnimEstrella1");
	}
	void ActivarEstrella2()
	{
		//yield return new WaitForSeconds (2.0f);
		GameObject.Find ("estrellas").GetComponent<Animator> ().Play ("AnimEstrella2");
	}
	void ActivarEstrella3()
	{
		//yield return new WaitForSeconds (2.0f);
		GameObject.Find ("estrellas").GetComponent<Animator> ().Play ("AnimEstrella3");
	}
}
