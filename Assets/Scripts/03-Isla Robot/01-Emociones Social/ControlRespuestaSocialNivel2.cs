using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlRespuestaSocialNivel2 : MonoBehaviour 
{
	ControlAleatorioSocialNivel2 CAN2;

	ControlEmociones CE;
	DatosDesbloqueo DD;
	ControlSlider CSlider;
	
	public GameObject IfinJuego;
	
	//public GameObject BotonVolverGrande;
	
	//public GameObject SiguienteSituacion;
	
	Control_monedas cM;
	GameObject ControlMonedas;
	
	GameObject puntuacion;
	Text Tpuntuacion;
	
	GameObject monedasSocialNivel2;
	Text TmonedasSocialNivel2;
	
	GameObject puntuacionfin;
	Text TpuntuacionFin;
	// Use this for initialization
	void Start () 
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CSlider = GameObject.Find ("Progreso").GetComponent<ControlSlider> ();

		CSlider.progresoEmocionesSNivel1 ();
		CE.respuesta = false;
		actualizarPuntuacion ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void respuesta()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		if (CE.respuesta == false) 
		{
			CAN2 = GameObject.Find ("ctrlAleatorio").GetComponent<ControlAleatorioSocialNivel2> ();
			switch (CAN2.PreguntaAleat) {

			case 1:
				if (gameObject.GetComponent<Image> ().sprite.name == "Enfado") 
				{
					correcto ();
				} 
				else {
					error ();
				}
				break;
			case 2:
				if (gameObject.GetComponent<Image> ().sprite.name == "Asco") 
				{
					correcto ();
				} 
				else {
					error ();
				}
				break;
			case 3:
				if (gameObject.GetComponent<Image> ().sprite.name == "Verguenza") 
				{
					correcto ();
				} 
				else {
					error ();
				}
				break;
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
		
		monedasSocialNivel2 = GameObject.Find ("monedas");
		TmonedasSocialNivel2 = monedasSocialNivel2.GetComponent<Text> ();
		
		cM.calcular_monedaSocialNivel1 ();
		cM.calcular_monedasGenerales ();
		
		if (CE.Intentos == 1) 
		{
			Invoke ("ActivarEstrella1", 1.0f);
			Invoke ("ActivarEstrella2", 2.0f);
			Invoke ("ActivarEstrella3", 3.0f);
			DD.AEmpatia[2] = true;
			DD.Portal2Fantasma=true;
		} 
		else 
		{
			if (CE.Intentos == 2) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				Invoke ("ActivarEstrella2", 2.0f);
				DD.AEmpatia[2] = true;
				DD.Portal2Fantasma=true;
			} 
			else if(CE.Intentos == 3)
			{
				Invoke ("ActivarEstrella1", 1.0f);
				DD.AEmpatia[2] = true;
				DD.Portal2Fantasma=true;
			}
		}
		
		//SiguienteSituacion.SetActive (true);
		
		TpuntuacionFin.text = "\nIntentos: " + CE.Intentos.ToString();
		
		TmonedasSocialNivel2.text = cM.monedasSocialNivel1.ToString();

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
