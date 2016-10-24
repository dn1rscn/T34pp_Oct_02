﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlRespuesta : MonoBehaviour 
{
	ControlDatosGlobales_Mundo3D cdg_3d;
	ControlMisiones CMisiones;

	ControlDatosGlobales_PICTOGRAMAS cdg;
	GameObject DGlobales;

	Control_monedas cM;
	GameObject ControlMonedas;

	DatosDesbloqueo DD;
	
	GameObject puntuacion;
	Text Tpuntuacion;

	GameObject monedasDado;
	Text TmonedasDado;

	ControlSlider CSlider;

	public GameObject[] vidas;

	public GameObject IfinJuego;
	public GameObject IfinJuego2;

	public GameObject estrella1;
	public GameObject estrella2;
	public GameObject estrella3;
	
	GameObject puntuacionfin;
	Text TpuntuacionFin;

	Animator animator_Cartel1;
	Animator animator_Cartel2;
	Animator animator_Cartel3;


	// Use this for initialization
	void Start () 
	{
		DD = GameObject.Find ("ctrDesbloqueo").GetComponent<DatosDesbloqueo> ();
		DGlobales = GameObject.Find ("DatosGlobales");
		cdg = DGlobales.GetComponent<ControlDatosGlobales_PICTOGRAMAS> ();
		resetearDado ();
		actualizarPuntuacion ();
		IfinJuego.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SeleccionRespuesta ()
	{
		DGlobales = GameObject.Find ("DatosGlobales");
		cdg = DGlobales.GetComponent<ControlDatosGlobales_PICTOGRAMAS> ();

		if (!cdg.resp) {

			//print (gameObject.name);
			//print (cdg.correcto);
			//FUNCION PARA DETECTAR LA RESPUESTA
			if (gameObject.name == "Cartel1" && cdg.correcto == 1) {
				cdg.resp = true;
				correcto ();
			} else {
				if (gameObject.name == "Cartel2" && cdg.correcto == 2) {
					cdg.resp = true;
					correcto ();
				} else {

					if (gameObject.name == "Cartel3" && cdg.correcto == 3) {
						cdg.resp = true;
						correcto ();
					}

					//FALLO DE REPUESTA
					else {
						error ();

					}
				}
			}
		} 
		else 
		{
			print("tira otra vez el dado");
			GameObject.Find("Dado").GetComponent<Animator>().Play ("Tirar_dado");
		}
	}

	void correcto()
	{
		CSlider = GameObject.Find ("Progreso").GetComponent<ControlSlider> ();

		print ("correcto");

		cdg.aciertos++;
		cdg.aciertosSeguidos++;
		CSlider.ProgresoDado ();

		//ejecutarSonidoAcierto
		//GameObject.Find("SonidoAcierto").GetComponent<AudioSource>().Play();

		GameObject.Find("Fantasma_bake").GetComponent<Animator>().Play("Fantasmaacierto");
		
		GameObject.Find("Panel_Canvas").GetComponent<Animator>().Play("acierto");

		actualizarPuntuacion ();

		if (cdg.aciertosSeguidos == 3) 
		{
			cdg.combos++;
			cdg.aciertosSeguidos=0;
		}
		if (cdg.aciertos == 10 && DD.Nivel2Dado == false) 
		{
			if(DD.Posicion+1<DD.ADado.Length)
			{
				DD.ADado[DD.Posicion=DD.Posicion+1]=true;
			}

			DD.Nivel2Dado=true;

			IfinJuego2.SetActive (true);
			IfinJuego2.GetComponent<Animator>().Play ("AnimFinPartida");
			
			puntuacionfin = GameObject.Find ("puntuacionFin");
			TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
			
			monedasDado = GameObject.Find ("monedas");
			TmonedasDado = monedasDado.GetComponent<Text> ();
			
			cM.calcular_monedasDado ();
			cM.calcular_monedasGenerales ();
			
			if (cdg.aciertos >= 5) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				if(cdg_3d.Ejer_Bosque[0]==false)
				{
					cdg_3d.Ejer_Bosque[0]=true;
				}
			}
			if (cdg.aciertos >= 10) 
			{
				Invoke ("ActivarEstrella2", 2.0f);
				
			}
			if (cdg.aciertos >= 15) 
			{
				Invoke ("ActivarEstrella3", 3.0f);
			}
			
			
			TpuntuacionFin.text = "NIVEL 2 DESBLOQUEADO"+"\n"+"\nACIERTOS: " + cdg.aciertos.ToString () + "\nCOMBOS: " + cdg.combos.ToString () + "\nLOGROS: ";
			
			TmonedasDado.text = cM.monedas_dado.ToString();
		}
	}
	void error()
	{
		ControlMonedas = GameObject.Find ("controlMonedas");
		cM = ControlMonedas.GetComponent<Control_monedas> ();

		print ("error");
		GameObject.Find("Fantasma_bake").GetComponent<Animator>().Play("Fantasmafallo");

		cdg.fallos++;
		cdg.aciertosSeguidos=0;


		//ejecutar animacionError
		GameObject.Find("Panel_Canvas").GetComponent<Animator>().Play("Fallo");
		
		//ejecutarSonidoFallo
		//GameObject.Find("SonidoFallo").GetComponent<AudioSource>().Play();

		if (cdg.fallos == 3) 
		{
			vidas [cdg.fallos-1].SetActive (false);

			cdg_3d=GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
			CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();

			IfinJuego.SetActive (true);
			IfinJuego.GetComponent<Animator>().Play ("AnimFinPartida");
			
			puntuacionfin = GameObject.Find ("puntuacionFin");
			TpuntuacionFin = puntuacionfin.GetComponent<Text> ();

			monedasDado = GameObject.Find ("monedas");
			TmonedasDado = monedasDado.GetComponent<Text> ();

			cM.calcular_monedasDado ();
			cM.calcular_monedasGenerales ();

			if (cdg.aciertos >= 5) 
			{
				Invoke ("ActivarEstrella1", 1.0f);

				if(cdg_3d.Ejer_Bosque[0]==false)
				{
					cdg_3d.Ejer_Bosque[0]=true;
				}
			}
			if (cdg.aciertos >= 10) 
			{
				Invoke ("ActivarEstrella2", 2.0f);
			
			}
			if (cdg.aciertos >= 15) 
			{
				Invoke ("ActivarEstrella3", 3.0f);
				if(CMisiones.dado1==true&&CMisiones.ejerB_3estrellas[0]==false)
				{
					CMisiones.ejerB_3estrellas[0]=true;
					CMisiones.Mision_Dino();
				}
				if(CMisiones.dado2==true&&CMisiones.ejerB_3estrellas[1]==false)
				{
					CMisiones.ejerB_3estrellas[1]=true;
					CMisiones.Mision_Dino();
				}
			}

			
			TpuntuacionFin.text = "\nACIERTOS: " + cdg.aciertos.ToString () + "\nCOMBOS: " + cdg.combos.ToString () + "\nLOGROS: ";

			TmonedasDado.text = cM.monedas_dado.ToString();

			resetearDado();

		} 
		else 
		{
			vidas [cdg.fallos-1].SetActive (false);
		}
	}

	void actualizarPuntuacion()
	{
		puntuacion = GameObject.Find ("puntuacion");
		Tpuntuacion = puntuacion.GetComponent<Text> ();

		Tpuntuacion.text = cdg.aciertos.ToString();
	}


	void ActivarEstrella1()
	{
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
	void resetearDado()
	{
		ControlMonedas = GameObject.Find ("controlMonedas");
		cM = ControlMonedas.GetComponent<Control_monedas> ();

		cdg.aciertos = 0;
		cdg.fallos = 0;
		cdg.aciertosSeguidos = 0;
		cdg.combos = 0;
		cM.monedas_dado = 0;
	}
	public void seguirJugando()
	{
		IfinJuego2.SetActive (false);
	}
}
