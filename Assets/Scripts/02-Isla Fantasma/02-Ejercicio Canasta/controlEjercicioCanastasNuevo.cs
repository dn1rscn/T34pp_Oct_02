using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlEjercicioCanastasNuevo : MonoBehaviour {

	public GameObject botonStart;

	public GameObject botonTurnoMascota;
	public GameObject botonTurnoJugador;

	public GameObject barraPotencia;

	public float lanzamientoMascota;
	public int num_turnoMascota=1;
	public int num_turnoJugador=0;

	public int puntuacionMascota;
	public int puntuacionJugador;

	public int miniAciertos=1;

	GameObject Confeti;

	string marcador;
	
	//controlColisionPowerBar cPB_ejercicioCanasta;
	
	Animator animatorEscena;
	Animator animatorSlider;

	Control_monedas cM;
	GameObject ControlMonedas;
	
	GameObject puntuacion;
	Text Tpuntuacion;
	
	GameObject monedasCanasta;
	Text Tmonedascanasta;
	
	public GameObject IfinJuego;
	
	GameObject puntuacionfin;
	Text TpuntuacionFin;

	ControlMisiones CMisiones;
	ControlNotificaciones2 CNotificaciones;
	ControlDatosGlobales_Mundo3D cdg_3d;


	// Use this for initialization
	void Start () {

		Confeti = GameObject.Find("confeti");
		Confeti.SetActive(false);
		//Accedemos al animator global de la escena
		animatorEscena = gameObject.GetComponent<Animator>();
		animatorSlider = barraPotencia.GetComponent<Animator>();
		//turnoMascota();
		botonTurnoJugador.SetActive(false);

		ControlMonedas = GameObject.Find ("controlMonedas");
		cM = ControlMonedas.GetComponent<Control_monedas> ();
		CNotificaciones = GameObject.Find ("Notificaciones2").GetComponent<ControlNotificaciones2> ();
		IfinJuego.SetActive (false);

		CNotificaciones.Siguiente_Secuencia.SetActive(false);
		CNotificaciones.Portal.SetActive(false);
		CNotificaciones.Isla.SetActive (false);
		for(int i=0;i < CNotificaciones.MisionFantasma.Length; i++)
		{
			CNotificaciones.MisionFantasma[i].SetActive(false);
		}

	}
	
//1-- TURNO DE LA MASCOTA*********************************************************
	public void turnoMascota(){

		botonStart.SetActive(false);
		botonTurnoJugador.SetActive(false);

		if (num_turnoMascota < 6) {
			//numero random, acierto o fallo de la mascota
			lanzamientoMascota = Random.Range (0, 2);
			print (lanzamientoMascota + "\n");
			
			if (lanzamientoMascota == 0) {

				falloMascota ();
				print ("LA MASCOTA HA FALLADO");
			} else {
				aciertoMascota ();
				print ("LA MASCOTA HA ENCESTADO");
			}

			//mostramos el marcador actual;
			//actualizarMarcadorMascota();
			//print (marcador);

		} else {
			finDelJuego();
		}
	}
//***********************************************************************************

//2-- TURNO DEL JUGADOR***************************************************************
	public void turnoJugador(){
		//Si hemos acertado:
		if(barraPotencia.GetComponent <Slider> ().value > 0.51){
			print ("MINI ACIERTO!!");
			miniAciertos++;

			switch(miniAciertos)
			{
			case 1: 
				animatorSlider.Play("animSlider_01");
				break;
			case 2: 
				animatorSlider.Play("animSlider_02");
				break;
			case 3: 
				animatorSlider.Play("animSlider_03");
				break;
			case 4: 
				animatorSlider.Play("animSlider_Acierto");
				aciertoJugador ();
				//botonTurnoJugador.SetActive(false);
				break;
				
			}

		} else {
			print ("FALLO!!");
			animatorSlider.Play("animSlider_Fallo");

			falloJugador();
		}



		//Las 4 primeras veces que tiramos la pelota:
		if (num_turnoJugador <= 4) {
				
			//aciertoJugador ();

			print (marcador);

			//botonTurnoJugador.SetActive(false);

			//Cuando estamos en nuestro ultimo turno,
		} else if (num_turnoJugador == 4) {

			aciertoJugador ();


		}
	}

//***********************************************************************************



	//SI LA MASCOTA ENCESTA
	void aciertoMascota(){
		//activamos la animacion de acierto de la mascota*********************************************
		animatorEscena.Play("Fantasma_Acierto");
		
		puntuacionMascota++;

		GameObject pngFalloActual= GameObject.Find("png_mascota_fallo_"+num_turnoJugador);
		Destroy(pngFalloActual);

	}

	//SI LA MASCOTA FALLA EL TIRO
	void falloMascota(){
		//activamos la animacion de fallo de la mascota*********************************************
		animatorEscena.Play("Fantasma_Fallo");

		//borramos del marcador de juego el png con la pelota verde correspondiente
		GameObject pngAciertoActual= GameObject.Find("png_mascota_acierto_"+num_turnoJugador);
		Destroy(pngAciertoActual);
	}
	
	//SI EL JUGADOR ENCESTA
	void aciertoJugador(){
		//activamos la animacion de acierto del avatar*********************************************
		animatorEscena.Play("Avatar_Acierto");
		miniAciertos=1;
		puntuacionJugador++;
		print ("HAS ENCESTADO!");

		//borramos del marcador de juego el png con la pelota gris correspondiente
		//GameObject pngFalloActual= GameObject.Find("png_jugador_fallo_"+num_turnoJugador);
		//Destroy(pngFalloActual);

	}

	//SI EL JUGADOR FALLA EL TIRO
	void falloJugador(){
		//activamos la animacion de fallo del avatar*********************************************
		animatorEscena.Play("Avatar_Fallo");
		miniAciertos=1;

		print ("HAS FALLADO!");

		GameObject pngAciertoActual= GameObject.Find("png_jugador_acierto_"+num_turnoJugador);
		Destroy(pngAciertoActual);
	}

	//funcion que actualiza el marcador dependiendo de los aciertos y fallos del jugador
	void actualizarMarcadorJugador(){
		marcador = puntuacionJugador+" - "+puntuacionMascota;

		GameObject pngIntentoActual= GameObject.Find("png_jugador_intento_"+num_turnoJugador);
		Destroy(pngIntentoActual);
		num_turnoJugador++;
		
		actualizarMarcadorGlobal();

	}

	//funcion que actualiza el marcador dependiendo de los aciertos y fallos de la mascota
	void actualizarMarcadorMascota(){
		marcador = puntuacionJugador+" - "+puntuacionMascota;

		GameObject pngIntentoActual= GameObject.Find("png_mascota_intento_"+num_turnoMascota);
		Destroy(pngIntentoActual);
		num_turnoMascota++;

		actualizarMarcadorGlobal();

	}

	//ACTUALIZA EL MARCADOR GENERAL
	void actualizarMarcadorGlobal(){
		//buscamos el gameObject que contiene el texto
		Text txt_marcador = GameObject.Find("txt_marcadorGlobal").GetComponent<Text>();
		txt_marcador.text = marcador;
	}

	//MUESTRA LA INTERFAZ DE TIRO PARA EL JUGADOR
	public void mostrarBotonJugador(){
		//mostramos los botones de juego para el jugador
		botonTurnoMascota.SetActive(false);
		botonTurnoJugador.SetActive(true);
	}

	//CERRAR LA PANTALLA DE TUTORIAL
	public void CerrarPantallaTutorial(){
		GameObject.Find("botonTutorial").SetActive(false);
		botonStart.SetActive(true);

	}

	//REINICIAR LA ESCENA
	public void reiniciarEscena(){
		Application.LoadLevel(Application.loadedLevel);
		botonStart.SetActive(true);
		
	}

	//FIN DEL JUEGO
	public void finDelJuego()
	{
		
	print ("FIN DEL JUEGO!!");
	
	//escondemos los botones de juego
	botonTurnoMascota.SetActive(false);
	botonTurnoJugador.SetActive(false);
	
	if(puntuacionMascota>puntuacionJugador){
		
		//*****************************************************************
		//HAS PERDIDO!!
		
		animatorEscena.Play("Fantasma_Acierto_FinDelJuego");

		print ("<color=red><size=20>HAS PERDIDO!!</size></color>");

		Invoke ("activar_FinJuego_lose", 3);
		
		//*****************************************************************
		
	}else if(puntuacionMascota<puntuacionJugador){
		if(puntuacionJugador==5){
			//activar animacion de mate
			animatorEscena.SetBool("avatar_PERFECT",true);
		}
		//*****************************************************************
		//HAS GANADO!!
		animatorEscena.Play("Avatar_Acierto_FinDelJuego");

			Confeti.SetActive(true);


		print ("<color=green><size=20>HAS GANADO!!</size></color>");
		
		Invoke ("activar_FinJuego_win", 3);
		
		//*****************************************************************

	}else{

		//HAS EMPATADO!!
	
		print ("<size=20>HAS EMPATADO!!</size>");
		
		Invoke ("activar_FinJuego_lose", 3);
		
	}
	//mostramos el marcador final
	print (marcador);

	}

	void ActivarEstrella1()
	{
		GameObject.Find ("estrellas").GetComponent<Animator> ().Play ("AnimEstrella1");
	}
	void ActivarEstrella2()
	{
		GameObject.Find ("estrellas").GetComponent<Animator> ().Play ("AnimEstrella2");
	}
	void ActivarEstrella3()
	{
		GameObject.Find ("estrellas").GetComponent<Animator> ().Play ("AnimEstrella3");
	}
	void activar_FinJuego_win()
	{
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();
		cdg_3d=GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();

		IfinJuego.SetActive (true);
		IfinJuego.GetComponent<Animator>().Play ("AnimFinPartida");
		puntuacionfin = GameObject.Find ("puntuacionFin");
		TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
		monedasCanasta = GameObject.Find ("monedas");
		Tmonedascanasta = monedasCanasta.GetComponent<Text> ();
		cM.calcular_monedasCanasta ();
		cM.calcular_monedasGenerales ();
		
		if (puntuacionJugador >= 1) 
		{
			Invoke ("ActivarEstrella1", 1.0f);
			if(cdg_3d.IslaMec_Desbloqueada==false)
			{
				cdg_3d.IslaMec_Desbloqueada=true;
				CNotificaciones.Isla.SetActive(true);
				GameObject.Find("Notificaciones2").GetComponent<Animator>().Play("abrirNotificacion");
			}
		}
		if (puntuacionJugador >= 3) {
			Invoke ("ActivarEstrella2", 2.0f);
		}
		if (puntuacionJugador >= 5) {
			Invoke ("ActivarEstrella3", 3.0f);
			if(CMisiones.ejerF_3estrellas[4]==false)
			{
				CMisiones.ejerF_3estrellas[4]=true;
				CNotificaciones.MisionFantasma[4].SetActive(true);
				GameObject.Find("Notificaciones2").GetComponent<Animator>().Play("abrirNotificacion");
			}
		}
		TpuntuacionFin.text ="HAS GANADO" + "\nACIERTOS: " + puntuacionJugador.ToString ();
		
		Tmonedascanasta.text = cM.MonedasGenerales_canasta.ToString();
		
		puntuacionJugador = 0;
		cM.MonedasGenerales_canasta = 0;
	}
	void activar_FinJuego_lose()
	{
		IfinJuego.SetActive (true);
		IfinJuego.GetComponent<Animator>().Play ("AnimFinPartida");
		puntuacionfin = GameObject.Find ("puntuacionFin");
		TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
		monedasCanasta = GameObject.Find ("monedas");
		Tmonedascanasta = monedasCanasta.GetComponent<Text> ();
		cM.calcular_monedasCanasta ();
		cM.calcular_monedasGenerales ();
		
		TpuntuacionFin.text ="HAS PERDIDO" + "\nACIERTOS: " + puntuacionJugador.ToString ();
		
		Tmonedascanasta.text = cM.MonedasGenerales_canasta.ToString();
		
		puntuacionJugador = 0;
		cM.MonedasGenerales_canasta = 0;
	}

}
