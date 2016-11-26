using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RespuestaSonidos : MonoBehaviour 
{
	ControlDatosGlobales_Mundo3D cdg_3d;
	ControlMisiones CMisiones;
	ControlNotificaciones1 CNotificaciones;

	ControlSonidos CS;
	reproducirSonido RS;
	DatosDesbloqueo DD;
	ControlSlider CSlider;

	public GameObject[] vidas;

	public GameObject IfinJuego;
	public GameObject IfinJuego2;

	Control_monedas cM;
	GameObject ControlMonedas;
	
	GameObject puntuacion;
	Text Tpuntuacion;
	
	GameObject monedasSonidos;
	Text TmonedasSonidos;

	GameObject puntuacionfin;
	Text TpuntuacionFin;

	public bool respuesta = true;

	public GameObject BotonPlay;
	public GameObject BotonRepetir;
	public GameObject BotonSiguienteNivel;

	//public GameObject estrella1;
	//public GameObject estrella2;
	//public GameObject estrella3;

	//public GameObject MaquinaDiscos;

	// Use this for initialization
	void Start () 
	{
		DD = GameObject.Find ("ctrDesbloqueo").GetComponent<DatosDesbloqueo> ();
		CS = GameObject.Find ("ctrSonidos").GetComponent<ControlSonidos> ();
		RS = GameObject.Find ("reproducir sonido").GetComponent<reproducirSonido> ();
		CNotificaciones = GameObject.Find ("Notificaciones").GetComponent<ControlNotificaciones1> ();
		actualizarPuntuacion ();

		CNotificaciones.Nivel2.SetActive(false);
		CNotificaciones.Nivel3.SetActive(false);
		CNotificaciones.Isla.SetActive (false);
		for(int i=0;i < CNotificaciones.MisionDino.Length; i++)
		{
			CNotificaciones.MisionDino[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void respuesta1()
	{
		if (respuesta == false) 
		{
			//MaquinaDiscos.GetComponent<Animation> ().Play ("boton1");
			//GameObject.Find("IM_Botones").GetComponent<Animator> ().Play("AnimBoton1");
			if (RS.SonidoAleatorio == 0) 
			{
				correcto ();
				//gameObject.SetActive(false);
				respuesta = true;
			} 
			else 
			{
				incorrecto ();
			}
		} 
		else 
		{
			GameObject.Find("Isla_Bosque_Boton_Play").GetComponent<Animator>().Play ("anim_Play");
		}
		
	
	}

	public void respuesta2()
	{
		if (respuesta == false) 
		{
			//MaquinaDiscos.GetComponent<Animation> ().Play ("boton2");
			//GameObject.Find("IM_Botones").GetComponent<Animator> ().Play("AnimBoton2");
			if (RS.SonidoAleatorio == 1) 
			{
				correcto ();
				//gameObject.SetActive(false);
				respuesta=true;
			} 
			else 
			{
				incorrecto ();
			}
		}
		else 
		{
			GameObject.Find("Isla_Bosque_Boton_Play").GetComponent<Animator>().Play ("anim_Play");
		}
	}
	public void respuesta3()
	{
		if (respuesta == false) 
		{
			//MaquinaDiscos.GetComponent<Animation> ().Play ("boton3");
			//GameObject.Find("IM_Botones").GetComponent<Animator> ().Play("AnimBoton3");
			if (RS.SonidoAleatorio == 2) 
			{
				correcto ();
				//gameObject.SetActive(false);
				respuesta=true;
			} 
			else 
			{
				incorrecto ();
			}
		}
		else 
		{
			GameObject.Find("Isla_Bosque_Boton_Play").GetComponent<Animator>().Play ("anim_Play");
		}
	}
	public void respuesta4()
	{
		if (respuesta == false) 
		{
		//	MaquinaDiscos.GetComponent<Animation> ().Play ("boton4");
			//GameObject.Find("IM_Botones").GetComponent<Animator> ().Play("AnimBoton4");
			if (RS.SonidoAleatorio == 3) 
			{
				correcto ();
				//gameObject.SetActive(false);
				respuesta=true;
			} 
			else 
			{
				incorrecto ();
			}
		}
		else 
		{
			GameObject.Find("Isla_Bosque_Boton_Play").GetComponent<Animator>().Play ("anim_Play");
		}
	}

	void correcto()
	{
		CSlider = GameObject.Find ("Progreso").GetComponent<ControlSlider> ();
		CNotificaciones = GameObject.Find ("Notificaciones").GetComponent<ControlNotificaciones1> ();
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();
		CS = GameObject.Find ("ctrSonidos").GetComponent<ControlSonidos> ();
		cdg_3d = GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();

		GameObject.Find("Dinoi_animaciones_v3").GetComponent<Animator>().Play("Acierto_01_dino");
		
		GameObject.Find("Panel_Canvas").GetComponent<Animator>().Play("acierto");

		GameObject.Find("Isla_Bosque_Boton_Play").GetComponent<Animator>().Play ("anim_Play");

		CS.aciertos++;
		BotonPlay.SetActive (true);
		//BotonRepetir.SetActive (false);
		RS.StopSonido ();
		CSlider.progresoSonidos ();

		actualizarPuntuacion ();

		RS.SonidosOK [RS.SonidoAleatorio] = true;

		if(CS.aciertos==2)
		{
			if(CS.nivel==1&&DD.Nivel2Sonidos==false)
			{
				//Notificacion();
				DD.ASonidos[CS.nivel]=true;
				CNotificaciones.Nivel2.SetActive(true);
				CNotificaciones.Nivel3.SetActive(false);
				CNotificaciones.Isla.SetActive (false);
				for(int i=0;i < CNotificaciones.MisionDino.Length; i++)
				{
					CNotificaciones.MisionDino[i].SetActive(false);
				}
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
				DD.Nivel2Sonidos=true;

			}
			if(CS.nivel==2&&DD.Nivel3Sonidos==false)
			{
				//Notificacion();
				DD.ASonidos[CS.nivel]=true;
				CNotificaciones.Nivel3.SetActive(true);
				CNotificaciones.Nivel2.SetActive(false);
				CNotificaciones.Isla.SetActive (false);
				for(int i=0;i < CNotificaciones.MisionDino.Length; i++)
				{
					CNotificaciones.MisionDino[i].SetActive(false);
				}
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
				DD.Nivel3Sonidos=true;
			}
		}
		if (CS.aciertos == 3) 
		{
			if(CS.nivel==1&&CMisiones.Dado1_Completado==true)
			{
				cdg_3d.IslaFantasma_Desbloqueada=true;
				CNotificaciones.Isla.SetActive(true);
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
			}
		}

		if (CS.aciertos == 4) 
		{
			if(CS.nivel == 1 &&CMisiones.ejerB_3estrellas[2]==false)
			{
				CMisiones.ejerB_3estrellas[2]=true;
				CMisiones.Mision_Dino();
				CNotificaciones.Nivel2.SetActive(false);
				CNotificaciones.Nivel3.SetActive(false);
				CNotificaciones.Isla.SetActive (false);
				for(int i=0;i < CNotificaciones.MisionDino.Length; i++)
				{
					CNotificaciones.MisionDino[i].SetActive(false);
				}
				CNotificaciones.MisionDino[2].SetActive(true);
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
			}
			if(CS.nivel==2&&CMisiones.ejerB_3estrellas[3]==false)
			{
				CMisiones.ejerB_3estrellas[3]=true;
				CMisiones.Mision_Dino();
				CNotificaciones.Nivel2.SetActive(false);
				CNotificaciones.Nivel3.SetActive(false);
				CNotificaciones.Isla.SetActive (false);
				for(int i=0;i < CNotificaciones.MisionDino.Length; i++)
				{
					CNotificaciones.MisionDino[i].SetActive(false);
				}
				CNotificaciones.MisionDino[3].SetActive(true);
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
			}
			if(CS.nivel==3&&CMisiones.ejerB_3estrellas[4]==false)
			{
				CMisiones.ejerB_3estrellas[4]=true;
				CMisiones.Mision_Dino();
				CNotificaciones.Nivel2.SetActive(false);
				CNotificaciones.Nivel3.SetActive(false);
				CNotificaciones.Isla.SetActive (false);
				for(int i=0;i < CNotificaciones.MisionDino.Length; i++)
				{
					CNotificaciones.MisionDino[i].SetActive(false);
				}
				CNotificaciones.MisionDino[4].SetActive(true);
				GameObject.Find("Notificaciones").GetComponent<Animator>().Play("abrirNotificacion");
			}

			FinPartida();
		}

		print ("correcto");
	}
	void incorrecto()
	{
		CS.fallos++;

		GameObject.Find("Dinoi_animaciones_v3").GetComponent<Animator>().Play("Fallo_01_dino");
		GameObject.Find("Panel_Canvas").GetComponent<Animator>().Play("Fallo");

		if(CS.fallos==3)
		{
			vidas [CS.fallos-1].SetActive (false);
			FinPartida();
		}
		else
		{
			vidas [CS.fallos-1].SetActive (false);
		}
		print ("incorrecto");
	}
	void actualizarPuntuacion()
	{
		puntuacion = GameObject.Find ("puntuacion");
		Tpuntuacion = puntuacion.GetComponent<Text> ();
		
		Tpuntuacion.text = CS.aciertos.ToString();
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
	void FinPartida()
	{
		cdg_3d=GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();
		
		IfinJuego.SetActive (true);
		IfinJuego.GetComponent<Animator>().Play ("AnimFinPartida");
		
		RS.StopSonido();
		
		puntuacionfin = GameObject.Find ("puntuacionFin");
		TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
		
		monedasSonidos = GameObject.Find ("monedas");
		TmonedasSonidos = monedasSonidos.GetComponent<Text> ();
		
		cM=GameObject.Find("controlMonedas").GetComponent<Control_monedas>();
		
		cM.calcular_monedasSonidos ();
		cM.calcular_monedasGenerales ();
		
		if (CS.aciertos >= 1) 
		{
			Invoke ("ActivarEstrella1", 1.0f);
			//desbloquear su¡iguiente nivel
			BotonSiguienteNivel.SetActive(true);
			cdg_3d.IslaFantasma_Desbloqueada=true;
		}
		if (CS.aciertos >= 2) {
			Invoke ("ActivarEstrella2", 2.0f);
			if(CS.nivel<DD.ASonidos.Length)
			{
				DD.ASonidos[CS.nivel]=true;
			}
		}
		if (CS.aciertos >= 4) {
			Invoke ("ActivarEstrella3", 3.0f);
			if(CS.nivel == 1 &&CMisiones.ejerB_3estrellas[2]==false)
			{
				CMisiones.ejerB_3estrellas[2]=true;
				CMisiones.Mision_Dino();
			}
			if(CS.nivel==2&&CMisiones.ejerB_3estrellas[3]==false)
			{
				CMisiones.ejerB_3estrellas[3]=true;
				CMisiones.Mision_Dino();
			}
			if(CS.nivel==3&&CMisiones.ejerB_3estrellas[4]==false)
			{
				CMisiones.ejerB_3estrellas[4]=true;
				CMisiones.Mision_Dino();
			}
		}
		
		
		TpuntuacionFin.text = "\nACIERTOS: " + CS.aciertos.ToString ();
		
		TmonedasSonidos.text = cM.MonedasSonidos.ToString();
		
		CS.aciertos = 0;
		CS.fallos = 0;
		//cdg.aciertosSeguidos = 0;
		//cdg.combos = 0;
		cM.MonedasSonidos = 0;
	}

	public void Notificacion ()
	{
		cdg_3d=GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();
		
		IfinJuego2.SetActive (true);
		IfinJuego2.GetComponent<Animator>().Play ("AnimFinPartida");
		
		RS.StopSonido();
		
		puntuacionfin = GameObject.Find ("puntuacionFin");
		TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
		
		monedasSonidos = GameObject.Find ("monedas");
		TmonedasSonidos = monedasSonidos.GetComponent<Text> ();
		
		cM=GameObject.Find("controlMonedas").GetComponent<Control_monedas>();
		
		cM.calcular_monedasSonidos ();
		cM.calcular_monedasGenerales ();
		
		if (CS.aciertos >= 1) 
		{
			Invoke ("ActivarEstrella1", 1.0f);
			//desbloquear su¡iguiente nivel
			BotonSiguienteNivel.SetActive(true);
		
			cdg_3d.IslaFantasma_Desbloqueada=true;
		}
		if (CS.aciertos >= 2) {
			Invoke ("ActivarEstrella2", 2.0f);
			if(CS.nivel<DD.ASonidos.Length)
			{
				DD.ASonidos[CS.nivel]=true;
			}
		}
		if (CS.aciertos >= 4) {
			Invoke ("ActivarEstrella3", 3.0f);
			if(CS.nivel == 1 &&CMisiones.ejerB_3estrellas[2]==false)
			{
				CMisiones.ejerB_3estrellas[2]=true;
				CMisiones.Mision_Dino();
			}
			if(CS.nivel==2&&CMisiones.ejerB_3estrellas[3]==false)
			{
				CMisiones.ejerB_3estrellas[3]=true;
				CMisiones.Mision_Dino();
			}
			if(CS.nivel==3&&CMisiones.ejerB_3estrellas[4]==false)
			{
				CMisiones.ejerB_3estrellas[4]=true;
				CMisiones.Mision_Dino();
			}
		}
		
		
		TpuntuacionFin.text ="\nACIERTOS: " + CS.aciertos.ToString ();
		
		TmonedasSonidos.text = cM.MonedasSonidos.ToString();
		
		cdg_3d.IslaFantasma_Desbloqueada=true;
		//DD.ASonidos[CS.nivel]=true;
	}

	public void seguirJugando()
	{
		IfinJuego2.SetActive (false);
		cM.monedas = cM.monedas - cM.MonedasSonidos;
	}
}
