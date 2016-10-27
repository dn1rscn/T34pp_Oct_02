using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlRespuestaEmociones : MonoBehaviour 
{
	ControlEmocionesAleatorio CEA;
	ControlEmociones CE;
	ControlSlider CSlider;
	
	public GameObject IfinJuego;
	
	//public GameObject BotonVolverGrande;
	
	public GameObject SiguienteSecuencia;
	
	Control_monedas cM;
	GameObject ControlMonedas;
	
	GameObject puntuacion;
	Text Tpuntuacion;
	
	GameObject monedasEmociones;
	Text TmonedasEmociones;
	
	GameObject puntuacionfin;
	Text TpuntuacionFin;
	// Use this for initialization
	void Start () 
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CSlider = GameObject.Find ("Progreso").GetComponent<ControlSlider> ();
		CEA = GameObject.Find ("ctrAleatorio").GetComponent<ControlEmocionesAleatorio> ();

		if (CEA.ARespuesta.Length == 3) 
		{
			CSlider.progresoEmocionesNivel1();
		}
		if (CEA.ARespuesta.Length == 5) 
		{
			CSlider.progresoEmocionesNivel2();
		}
		if (CEA.ARespuesta.Length == 7) 
		{
			CSlider.progresoEmocionesNivel3();
		}
		CE.respuesta = false;
		actualizarPuntuacion ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Respuesta()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		if (CE.respuesta == false) 
		{
			CEA = GameObject.Find ("ctrAleatorio").GetComponent<ControlEmocionesAleatorio> ();

			if ("P" + gameObject.GetComponent<Image> ().sprite.name == GameObject.Find ("Pregunta").GetComponent<Image> ().sprite.name) {
				Correcto ();
			} else {
				Error ();
			}
		}
	}

	void Correcto()
	{
		print ("correcto");
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		print (CEA.ARespuesta.Length);
		//Nivel 1
		if (CEA.ARespuesta.Length == 3) 
		{
			IfinJuego.SetActive(true);
			
			ControlMonedas = GameObject.Find ("controlMonedas");
			cM = ControlMonedas.GetComponent<Control_monedas> ();
			
			puntuacionfin = GameObject.Find ("puntuacionFin");
			TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
			
			monedasEmociones = GameObject.Find ("monedas");
			TmonedasEmociones = monedasEmociones.GetComponent<Text> ();
			
			cM.calcular_monedasEmocionesNivel1 ();
			cM.calcular_monedasGenerales ();

			print(CE.Intentos);
			if (CE.Intentos == 3) 
			{
				Invoke ("ActivarEstrella1", 1.0f);

				SiguienteSecuencia.SetActive(true);
				if(CE.NivelEmociones<CE.AEmociones.Length)
				{
					CE.AEmociones[CE.NivelEmociones]=true;
				}
			}
			if (CE.Intentos == 2) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				Invoke ("ActivarEstrella2", 2.0f);
				SiguienteSecuencia.SetActive(true);
				if(CE.NivelEmociones<CE.AEmociones.Length)
				{
					CE.AEmociones[CE.NivelEmociones]=true;
				}
			}
			if (CE.Intentos == 1) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				Invoke ("ActivarEstrella2", 2.0f);
				Invoke ("ActivarEstrella3", 3.0f);
				SiguienteSecuencia.SetActive(true);
				if(CE.NivelEmociones<CE.AEmociones.Length)
				{
					CE.AEmociones[CE.NivelEmociones]=true;
				}
			}
			
			
			TpuntuacionFin.text = "\nIntentos: " + CE.Intentos.ToString ();
			
			TmonedasEmociones.text = cM.monedasEmociones.ToString();
			
			cM.monedasEmociones=0;
			CE.Intentos=1;
			CE.respuesta=true;
		}
		//nivel2
		if (CEA.ARespuesta.Length == 5) 
		{
			IfinJuego.SetActive(true);
			
			ControlMonedas = GameObject.Find ("controlMonedas");
			cM = ControlMonedas.GetComponent<Control_monedas> ();
			
			puntuacionfin = GameObject.Find ("puntuacionFin");
			TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
			
			monedasEmociones = GameObject.Find ("monedas");
			TmonedasEmociones = monedasEmociones.GetComponent<Text> ();
			
			cM.calcular_monedasEmocionesNivel2 ();
			cM.calcular_monedasGenerales ();
			
			if (CE.Intentos == 4) 
			{
				Invoke ("ActivarEstrella1", 1.0f);

				SiguienteSecuencia.SetActive(true);
				if(CE.NivelEmociones<CE.AEmociones.Length)
				{
					CE.AEmociones[CE.NivelEmociones]=true;
				}
			}
			if (CE.Intentos == 2||CE.Intentos==3) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				Invoke ("ActivarEstrella2", 2.0f);

				SiguienteSecuencia.SetActive(true);
				if(CE.NivelEmociones<CE.AEmociones.Length)
				{
					CE.AEmociones[CE.NivelEmociones]=true;
				}
			}
			if (CE.Intentos == 1) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				Invoke ("ActivarEstrella2", 2.0f);
				Invoke ("ActivarEstrella3", 3.0f);
				SiguienteSecuencia.SetActive(true);
				if(CE.NivelEmociones<CE.AEmociones.Length)
				{
					CE.AEmociones[CE.NivelEmociones]=true;
				}
			}
			
			
			TpuntuacionFin.text = "\nIntentos: " + CE.Intentos.ToString ();
			
			TmonedasEmociones.text = cM.monedasEmociones.ToString();
			
			cM.monedasEmociones=0;
			CE.Intentos=0;
			CE.respuesta=true;
		}
		//nivel3
		if (CEA.ARespuesta.Length == 7) 
		{
			IfinJuego.SetActive(true);
			
			ControlMonedas = GameObject.Find ("controlMonedas");
			cM = ControlMonedas.GetComponent<Control_monedas> ();
			
			puntuacionfin = GameObject.Find ("puntuacionFin");
			TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
			
			monedasEmociones = GameObject.Find ("monedas");
			TmonedasEmociones = monedasEmociones.GetComponent<Text> ();
			
			cM.calcular_monedasEmocionesNivel3 ();
			cM.calcular_monedasGenerales ();
			
			if (CE.Intentos==5||CE.Intentos == 6) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				//SiguienteSecuencia.SetActive(true);
				if(CE.NivelEmociones<CE.AEmociones.Length)
				{
					CE.AEmociones[CE.NivelEmociones]=true;
				}
			}
			if (CE.Intentos == 2||CE.Intentos==3 || CE.Intentos==4) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				Invoke ("ActivarEstrella2", 2.0f);
				//SiguienteSecuencia.SetActive(true);
				if(CE.NivelEmociones<CE.AEmociones.Length)
				{
					CE.AEmociones[CE.NivelEmociones]=true;
				}
			}
			if (CE.Intentos == 1) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				Invoke ("ActivarEstrella2", 2.0f);
				Invoke ("ActivarEstrella3", 3.0f);
				//SiguienteSecuencia.SetActive(true);
				if(CE.NivelEmociones<CE.AEmociones.Length)
				{
					CE.AEmociones[CE.NivelEmociones]=true;
				}
			}
			
			
			TpuntuacionFin.text = "\nIntentos: " + CE.Intentos.ToString ();
			
			TmonedasEmociones.text = cM.monedasEmociones.ToString();
			
			cM.monedasEmociones=0;
			CE.Intentos=1;
			CE.respuesta=true;
		}
	}
	void Error()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		print ("fallo");
		CE.Intentos++;
		actualizarPuntuacion ();
		if (CEA.ARespuesta.Length == 3) 
		{
			CSlider.progresoEmocionesNivel1();
		}
		if (CEA.ARespuesta.Length == 5) 
		{
			CSlider.progresoEmocionesNivel2();
		}
		if (CEA.ARespuesta.Length == 7) 
		{
			CSlider.progresoEmocionesNivel3();
		}

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
	void actualizarPuntuacion()
	{
		puntuacion = GameObject.Find ("puntuacion");
		Tpuntuacion = puntuacion.GetComponent<Text> ();
		
		Tpuntuacion.text = CE.Intentos.ToString();
	}
}
