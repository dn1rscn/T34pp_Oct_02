using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlEjercicioCanastas : MonoBehaviour {

	public GameObject botonTurnoMascota;
	public GameObject botonTurnoJugador;
	public GameObject barraPower;
	public GameObject scriptPunteroMovil;
	
	float lanzamientoMascota;
	int num_turnoMascota=1;
	public int num_turnoJugador=1;
	
	int puntuacionMascota;
	public int puntuacionJugador;
	
	string marcador;
	
	controlColisionPowerBar cPB_ejercicioCanasta;
	
	Animator animatorFantasma;
	Animator animatorAvatar;
	
	Control_monedas cM;
	GameObject ControlMonedas;
	
	GameObject puntuacion;
	Text Tpuntuacion;
	
	GameObject monedasCanasta;
	Text Tmonedascanasta;
	
	public GameObject IfinJuego;
	
	GameObject puntuacionfin;
	Text TpuntuacionFin;
	
	public GameObject estrella1;
	public GameObject estrella2;
	public GameObject estrella3;


	// Use this for initialization
	void Start () {
		//mostramos los botones de juego para la mascota
		botonTurnoMascota.SetActive(true);
		botonTurnoJugador.SetActive(false);
		barraPower.SetActive(false);

		//ACCEDEMOS AL SCRIPT DE COLISION DE LA BARRA DE POTENCIA
		cPB_ejercicioCanasta = scriptPunteroMovil.GetComponent<controlColisionPowerBar>();

		animatorFantasma = GameObject.Find("fantasma").GetComponent<Animator>();
		animatorAvatar = GameObject.Find("avatar").GetComponent<Animator>();
		ControlMonedas = GameObject.Find ("controlMonedas");
		cM = ControlMonedas.GetComponent<Control_monedas> ();
		IfinJuego.SetActive (false);

	}
	
//1-- TURNO DE LA MASCOTA*********************************************************
	public void turnoMascota(){
		//print (num_turnoMascota);
		botonTurnoMascota.SetActive(false);

		if (num_turnoMascota <= 5) {
			//numero random, acierto o fallo de la mascota
			lanzamientoMascota = Random.Range (0, 2);
			//print (lanzamientoMascota + "\n");
			
			if (lanzamientoMascota == 0) {

				falloMascota ();
				print ("LA MASCOTA HA FALLADO");
			} else {
				aciertoMascota ();
				print ("LA MASCOTA HA ENCESTADO");
			}

			//mostramos el marcador actual;
			actualizarMarcadorMascota();
			print (marcador);
			num_turnoMascota++;


		} else {
			print ("FIN DEL JUEGO PARA LA MASCOTA");
		}
	}
//***********************************************************************************

//2-- TURNO DEL JUGADOR***************************************************************
	public void turnoJugador(){
		//print (num_turnoJugador);

		//paramos la animacion de la barra movil
		GameObject.Find("barra_PunteroMóvil").GetComponent<Animator>().Stop();

		//Las 4 primeras veces que tiramos la pelota:
		if (num_turnoJugador <= 4) {
			if (cPB_ejercicioCanasta.zonaAcierto) {
				aciertoJugador ();

			} else {
				falloJugador ();
			}
			//mostramos el marcador actual;
			actualizarMarcadorJugador();
			print (marcador);

			botonTurnoJugador.SetActive(false);

			//Cuando estamos en nuestro ultimo turno,
		} else if (num_turnoJugador == 5) {

			if (cPB_ejercicioCanasta.zonaAcierto) {
				aciertoJugador ();
			} else {
				falloJugador ();
			}
			actualizarMarcadorJugador();

			print ("FIN DEL JUEGO!!");

			//escondemos los botones de juego
			botonTurnoMascota.SetActive(false);
			botonTurnoJugador.SetActive(false);
			barraPower.SetActive(false);

			if(puntuacionMascota>puntuacionJugador){
		
				//*****************************************************************
				//HAS PERDIDO!!

				print ("<color=red><size=20>HAS PERDIDO!!</size></color>");

				Invoke ("activar_FinJuego_lose", 3);
			
				//*****************************************************************

			}else if(puntuacionMascota<puntuacionJugador){
				if(puntuacionJugador==5){
					//activar animacion de mate
					animatorAvatar.SetBool("avatar_PERFECT",true);
				}
				//*****************************************************************
				//HAS GANADO!!

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
	}

//***********************************************************************************



	//SI LA MASCOTA ENCESTA
	void aciertoMascota(){
		//activamos la animacion de acierto de la mascota*********************************************
		animatorFantasma.SetBool("mascota_tirarPelota(Acierto)",true);
		
		puntuacionMascota++;

		GameObject pngFalloActual= GameObject.Find("png_mascota_fallo_"+num_turnoJugador);
		Destroy(pngFalloActual);

	}

	//SI LA MASCOTA FALLA EL TIRO
	void falloMascota(){
		//activamos la animacion de fallo de la mascota*********************************************
		animatorFantasma.SetBool("mascota_tirarPelota(Fallo)",true);

		//borramos del marcador de juego el png con la pelota verde correspondiente
		GameObject pngAciertoActual= GameObject.Find("png_mascota_acierto_"+num_turnoJugador);
		Destroy(pngAciertoActual);
	}
	
	//SI EL JUGADOR ENCESTA
	void aciertoJugador(){
		//activamos la animacion de acierto del avatar*********************************************
		animatorAvatar.SetBool("avatar_tirarPelota(Acierto)",true);

		
		puntuacionJugador++;
		print ("HAS ENCESTADO!");

		//borramos del marcador de juego el png con la pelota gris correspondiente
		GameObject pngFalloActual= GameObject.Find("png_jugador_fallo_"+num_turnoJugador);
		Destroy(pngFalloActual);
	}

	//SI EL JUGADOR FALLA EL TIRO
	void falloJugador(){
		//activamos la animacion de fallo del avatar*********************************************
		animatorAvatar.SetBool("avatar_tirarPelota(Fallo)",true);
		
		print ("HAS FALLADO!");

		GameObject pngAciertoActual= GameObject.Find("png_jugador_acierto_"+num_turnoJugador);
		Destroy(pngAciertoActual);
	}

	//funcion que actualiza el marcador dependiendo de los aciertos y fallos del jugador
	void actualizarMarcadorJugador(){
		marcador = puntuacionJugador+" - "+puntuacionMascota;

		GameObject pngIntentoActual= GameObject.Find("png_jugador_intento_"+num_turnoJugador);
		Destroy(pngIntentoActual);
		actualizarMarcadorGlobal();
		//num_turnoJugador++;


	}

	void actualizarMarcadorMascota(){
		marcador = puntuacionJugador+" - "+puntuacionMascota;

		GameObject pngIntentoActual= GameObject.Find("png_mascota_intento_"+num_turnoMascota);
		Destroy(pngIntentoActual);

		actualizarMarcadorGlobal();
	}

	//ACTUALIZA EL MARCADOR GENERAL
	void actualizarMarcadorGlobal(){
		//buscamos el gameObject que contiene el texto
		Text txt_marcador = GameObject.Find("txt_marcadorGlobal").GetComponent<Text>();
		txt_marcador.text = marcador;
	}

	public void mostrarBotonJugador(){
		//mostramos los botones de juego para el jugador
		botonTurnoMascota.SetActive(false);
		botonTurnoJugador.SetActive(true);
		barraPower.SetActive(true);
	}

	public void mostrarBotonMascota(){
		//mostramos los botones de juego para la mascota
		botonTurnoMascota.SetActive(true);
		botonTurnoJugador.SetActive(false);
		barraPower.SetActive(false);

	}

	void ActivarEstrella1()
	{
		estrella1.SetActive (true);
	}
	void ActivarEstrella2()
	{
		estrella2.SetActive (true);
	}
	void ActivarEstrella3()
	{
		estrella3.SetActive (true);
	}
	void activar_FinJuego_win()
	{
		IfinJuego.SetActive (true);
		puntuacionfin = GameObject.Find ("puntuacionFin");
		TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
		monedasCanasta = GameObject.Find ("monedas");
		Tmonedascanasta = monedasCanasta.GetComponent<Text> ();
		cM.calcular_monedasCanasta ();
		cM.calcular_monedasGenerales ();
		
		if (puntuacionJugador >= 1) {
			Invoke ("ActivarEstrella1", 1.0f);
		}
		if (puntuacionJugador >= 3) {
			Invoke ("ActivarEstrella2", 2.0f);
		}
		if (puntuacionJugador >= 5) {
			Invoke ("ActivarEstrella3", 3.0f);
		}
		TpuntuacionFin.text = "\nACIERTOS: " + puntuacionJugador.ToString ();
		
		Tmonedascanasta.text = cM.MonedasGenerales_canasta.ToString();
		
		puntuacionJugador = 0;
		cM.MonedasGenerales_canasta = 0;
	}
	void activar_FinJuego_lose()
	{
		IfinJuego.SetActive (true);
		puntuacionfin = GameObject.Find ("puntuacionFin");
		TpuntuacionFin = puntuacionfin.GetComponent<Text> ();
		monedasCanasta = GameObject.Find ("monedas");
		Tmonedascanasta = monedasCanasta.GetComponent<Text> ();
		cM.calcular_monedasCanasta ();
		cM.calcular_monedasGenerales ();
		
		TpuntuacionFin.text = "\nACIERTOS: " + puntuacionJugador.ToString ();
		
		Tmonedascanasta.text = cM.MonedasGenerales_canasta.ToString();
		
		puntuacionJugador = 0;
		cM.MonedasGenerales_canasta = 0;
	}

}
