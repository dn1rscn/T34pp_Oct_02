using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinPartida_Secuencias : MonoBehaviour 
{
	public GameObject IfinJuego;
	public GameObject SiguienteSecuencia;
	public GameObject ISalir;
	
	Control_monedas cM;
	GameObject ControlMonedas;
	
	GameObject puntuacion;
	Text Tpuntuacion;
	
	GameObject monedasSecuencia;
	Text TmonedasSecuencia;
	
	GameObject puntuacionfin;
	Text TpuntuacionFin;
	ControlSecuencias cs;
	GameObject ctrlsecuencias;
	ControlMisiones CMisiones;
	DatosDesbloqueo DD;
	ControlNotificaciones2 CNotificaciones;

	// Use this for initialization
	void Start () 
	{
		CNotificaciones = GameObject.Find ("Notificaciones").GetComponent<ControlNotificaciones2> ();

		IfinJuego.SetActive (false);
		CNotificaciones.Siguiente_Secuencia.SetActive(false);
		CNotificaciones.Portal.SetActive(false);
		for(int i=0;i < CNotificaciones.MisionFantasma.Length; i++)
		{
			CNotificaciones.MisionFantasma[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void finjuego()
	{
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();
		DD = GameObject.Find ("ctrDesbloqueo").GetComponent<DatosDesbloqueo> ();
		CNotificaciones = GameObject.Find ("Notificaciones").GetComponent<ControlNotificaciones2> ();

		ctrlsecuencias = GameObject.Find ("DatosGlobalesSecuencias");
		cs = ctrlsecuencias.GetComponent<ControlSecuencias> ();
		Debug.Log("finjuego2");
		IfinJuego.SetActive(true);
		IfinJuego.GetComponent<Animator>().Play ("AnimFinPartida");
		
		ControlMonedas = GameObject.Find ("controlMonedas");
		cM = ControlMonedas.GetComponent<Control_monedas> ();
		
		puntuacionfin = GameObject.Find ("puntuacionFin");
		TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
		
		monedasSecuencia = GameObject.Find ("monedas");
		TmonedasSecuencia = monedasSecuencia.GetComponent<Text> ();
		
		cM.calcular_monedasSecuencia ();
		cM.calcular_monedasGenerales ();
		
		if (cs.fallos == 2 ) 
		{
			Invoke ("ActivarEstrella1", 1.0f);
			//ActivarEstrella1();
			SiguienteSecuencia.SetActive(true);
			if(cs.Asecuencias[cs.Secuencia]==false)
			{
				GameObject.Find("Notificaciones1").GetComponent<Animator>().Play("abrirNotificacion");
				CNotificaciones.Siguiente_Secuencia.SetActive(true);
				if(cs.Secuencia<cs.Asecuencias.Length)
				{
					cs.Asecuencias[cs.Secuencia]=true;
				}
			}
		}
		if (cs.fallos == 1) 
		{
			Invoke ("ActivarEstrella1", 1.0f);
			Invoke ("ActivarEstrella2", 2.0f);
			SiguienteSecuencia.SetActive(true);
			if(cs.Asecuencias[cs.Secuencia]==false)
			{
				CNotificaciones.Siguiente_Secuencia.SetActive(true);
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
				if(cs.Secuencia<cs.Asecuencias.Length)
				{
					cs.Asecuencias[cs.Secuencia]=true;
				}
			}
			//desbloquearportal
			if(cs.Secuencia==2&&DD.Portal2Fantasma==false)
			{
				DD.Portal2Fantasma=true;
				CNotificaciones.Portal.SetActive(true);
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
			}
		}
		if (cs.fallos == 0) {
			Invoke ("ActivarEstrella1", 1.0f);
			Invoke ("ActivarEstrella2", 2.0f);
			Invoke ("ActivarEstrella3", 3.0f);
			SiguienteSecuencia.SetActive(true);
			if(cs.Asecuencias[cs.Secuencia]==false)
			{
				CNotificaciones.Siguiente_Secuencia.SetActive(true);
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
				if(cs.Secuencia<cs.Asecuencias.Length)
				{
					cs.Asecuencias[cs.Secuencia]=true;
				}
			}
			if(CMisiones.ejerF_3estrellas[cs.Secuencia-1]==false)
			{
				CMisiones.ejerF_3estrellas[cs.Secuencia-1]=true;
				CNotificaciones.MisionFantasma[cs.Secuencia-1].SetActive(true);
				//GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
			}
			if(cs.Secuencia==2&&DD.Portal2Fantasma==false)
			{
				DD.Portal2Fantasma=true;
				CNotificaciones.Portal.SetActive(true);
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
			}
		}
		
		
		TpuntuacionFin.text = "\nFALLOS: " + cs.fallos.ToString ();
		
		TmonedasSecuencia.text = cM.monedas_secuencia.ToString();
		
		resetar_secuencias ();
		
	}
	
	void ActivarEstrella1()
	{
		print ("ZZZZZZZ");
		//estrella1.SetActive (true);
		GameObject.Find ("estrellas").GetComponent<Animator> ().Play ("AnimEstrella1");
		//estrella1.SetActive (true);
	}
	void ActivarEstrella2()
	{
		//estrella2.SetActive (true);
		GameObject.Find ("estrellas").GetComponent<Animator> ().Play ("AnimEstrella2");
		//estrella2.SetActive (true);
	}
	void ActivarEstrella3()
	{
		//estrella3.SetActive (true);
		GameObject.Find ("estrellas").GetComponent<Animator> ().Play ("AnimEstrella3");
		//estrella3.SetActive (true);
	}
	
	public void resetar_secuencias()
	{
		ctrlsecuencias = GameObject.Find ("DatosGlobalesSecuencias");
		cs = ctrlsecuencias.GetComponent<ControlSecuencias> ();
		
		ControlMonedas = GameObject.Find ("controlMonedas");
		cM = ControlMonedas.GetComponent<Control_monedas> ();
		
		cs.fallos = 0;
		cM.monedas_secuencia = 0;
		cs.p1 = false;
		cs.p2 = false;
		cs.p3 = false;
	}

	public void SalirSecuencias()
	{
		ISalir.SetActive (true);
		ISalir.GetComponent<Animator>().Play ("AnimFinPartida");

		ControlMonedas = GameObject.Find ("controlMonedas");
		cM = ControlMonedas.GetComponent<Control_monedas> ();
		
		puntuacionfin = GameObject.Find ("puntuacionFin");
		TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
		
		monedasSecuencia = GameObject.Find ("monedas");
		TmonedasSecuencia = monedasSecuencia.GetComponent<Text> ();

		TpuntuacionFin.text = "\nQUIERES SALIR? ";
		
		TmonedasSecuencia.text = cM.monedas_secuencia.ToString();
	}
	public void SeguirJugando()
	{
		ISalir.SetActive (false);
	}

}
