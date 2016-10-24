using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RespuestaSonidos : MonoBehaviour 
{
	ControlDatosGlobales_Mundo3D cdg_3d;
	ControlMisiones CMisiones;

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
		actualizarPuntuacion ();
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
				respuesta=true;
			} 
			else 
			{
				incorrecto ();
			}
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
				respuesta=true;
			} 
			else 
			{
				incorrecto ();
			}
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
				respuesta=true;
			} 
			else 
			{
				incorrecto ();
			}
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
				respuesta=true;
			} 
			else 
			{
				incorrecto ();
			}
		}
	}

	void correcto()
	{
		CSlider = GameObject.Find ("Progreso").GetComponent<ControlSlider> ();

		CS.aciertos++;
		BotonPlay.SetActive (true);
		//BotonRepetir.SetActive (false);
		RS.StopSonido ();
		CSlider.progresoSonidos ();

		actualizarPuntuacion ();

		if(CS.aciertos==10)
		{

			if(CS.nivel==1&&DD.Nivel2Sonidos==false)
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
				
				if (CS.aciertos >= 5) 
				{
					Invoke ("ActivarEstrella1", 1.0f);
					//desbloquear su¡iguiente nivel
					BotonSiguienteNivel.SetActive(true);
					if(CS.nivel<DD.ASonidos.Length)
					{
						DD.ASonidos[CS.nivel]=true;
					}
					cdg_3d.IslaFantasma_Desbloqueada=true;
				}
				if (CS.aciertos >= 10) {
					Invoke ("ActivarEstrella2", 2.0f);
				}
				if (CS.aciertos >= 15) {
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
					if(CS.nivel==2&&CMisiones.ejerB_3estrellas[4]==false)
					{
						CMisiones.ejerB_3estrellas[4]=true;
						CMisiones.Mision_Dino();
					}
				}
				
				
				TpuntuacionFin.text ="NIVEL "+ (CS.nivel+1)+ " DESBLOQUEADO" + "\n" + "\nACIERTOS: " + CS.aciertos.ToString ();
				
				TmonedasSonidos.text = cM.MonedasSonidos.ToString();
				
				cdg_3d.IslaFantasma_Desbloqueada=true;
				DD.ASonidos[CS.nivel]=true;

			}
			if(CS.nivel==2&&DD.Nivel3Sonidos==false)
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
				
				if (CS.aciertos >= 5) 
				{
					Invoke ("ActivarEstrella1", 1.0f);
					//desbloquear su¡iguiente nivel
					BotonSiguienteNivel.SetActive(true);
					if(CS.nivel<DD.ASonidos.Length)
					{
						DD.ASonidos[CS.nivel]=true;
					}
					cdg_3d.IslaFantasma_Desbloqueada=true;
				}
				if (CS.aciertos >= 10) {
					Invoke ("ActivarEstrella2", 2.0f);
				}
				if (CS.aciertos >= 15) {
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
					if(CS.nivel==2&&CMisiones.ejerB_3estrellas[4]==false)
					{
						CMisiones.ejerB_3estrellas[4]=true;
						CMisiones.Mision_Dino();
					}
				}
				
				
				TpuntuacionFin.text = "\nACIERTOS: " + CS.aciertos.ToString ();
				
				TmonedasSonidos.text = cM.MonedasSonidos.ToString();

				cdg_3d.IslaFantasma_Desbloqueada=true;
				DD.ASonidos[CS.nivel]=true;

			}
		}

		print ("correcto");
	}
	void incorrecto()
	{
		CS.fallos++;
		if(CS.fallos==3)
		{
			vidas [CS.fallos-1].SetActive (false);

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
			
			if (CS.aciertos >= 5) 
			{
				Invoke ("ActivarEstrella1", 1.0f);
				//desbloquear su¡iguiente nivel
				BotonSiguienteNivel.SetActive(true);
				if(CS.nivel<DD.ASonidos.Length)
				{
					DD.ASonidos[CS.nivel]=true;
				}
				cdg_3d.IslaFantasma_Desbloqueada=true;
			}
			if (CS.aciertos >= 10) {
				Invoke ("ActivarEstrella2", 2.0f);
			}
			if (CS.aciertos >= 15) {
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
				if(CS.nivel==2&&CMisiones.ejerB_3estrellas[4]==false)
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
	public void seguirJugando()
	{
		IfinJuego2.SetActive (false);
	}
}
