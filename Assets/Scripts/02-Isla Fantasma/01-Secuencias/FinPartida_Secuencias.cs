using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinPartida_Secuencias : MonoBehaviour 
{
	public GameObject IfinJuego;
	public GameObject SiguienteSecuencia;
	
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

	// Use this for initialization
	void Start () 
	{
		IfinJuego.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void finjuego()
	{
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
		
		if (cs.intentos == 4 ) 
		{
			Invoke ("ActivarEstrella1", 1.0f);
			//ActivarEstrella1();
			SiguienteSecuencia.SetActive(true);
			if(cs.Secuencia<cs.Asecuencias.Length)
			{
				cs.Asecuencias[cs.Secuencia]=true;
			}
		}
		if (cs.intentos == 3 || cs.intentos == 2) 
		{
			Invoke ("ActivarEstrella1", 1.0f);
			Invoke ("ActivarEstrella2", 2.0f);
			SiguienteSecuencia.SetActive(true);
			if(cs.Secuencia<cs.Asecuencias.Length)
			{
				cs.Asecuencias[cs.Secuencia]=true;
			}
			//desbloquearportal
		}
		if (cs.intentos == 1) {
			Invoke ("ActivarEstrella1", 1.0f);
			Invoke ("ActivarEstrella2", 2.0f);
			Invoke ("ActivarEstrella3", 3.0f);
			SiguienteSecuencia.SetActive(true);
			if(cs.Secuencia<cs.Asecuencias.Length)
			{
				cs.Asecuencias[cs.Secuencia]=true;
			}
		}
		
		
		TpuntuacionFin.text = "\nINTENTOS: " + cs.intentos.ToString ();
		
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
		
		cs.intentos = 1;
		cM.monedas_secuencia = 0;
		cs.p1 = false;
		cs.p2 = false;
		cs.p3 = false;
	}

}
