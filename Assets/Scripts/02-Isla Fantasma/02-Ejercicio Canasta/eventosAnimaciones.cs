using UnityEngine;
using System.Collections;

public class eventosAnimaciones : MonoBehaviour {

	controlEjercicioCanastas cEC_ejercicioCanasta;
	Animator animatorFantasma;
	Animator animatorAvatar;

	public GameObject barraPower;

	// Use this for initialization
	void Start () {
		animatorFantasma = GameObject.Find("fantasma").GetComponent<Animator>();
		animatorAvatar = GameObject.Find("avatar").GetComponent<Animator>();

		cEC_ejercicioCanasta = GameObject.Find("gameFlow").GetComponent<controlEjercicioCanastas>();

	}

	public void empezarTurnoJugador(){
		print ("INICIO DEL TURNO DEL JUGADOR");

		//restauramos las variables del animator de la mascota
		animatorFantasma.SetBool("mascota_tirarPelota(Fallo)",false);
		animatorFantasma.SetBool("mascota_tirarPelota(Acierto)",false);

		cEC_ejercicioCanasta.mostrarBotonJugador();

	}

	public void empezarTurnoMascota(){
		print ("INICIO DEL TURNO DE LA MASCOTA");

		//restauramos las variables del animator del jugador
		animatorAvatar.SetBool("avatar_tirarPelota(Fallo)",false);
		animatorAvatar.SetBool("avatar_tirarPelota(Acierto)",false);

		//CUANDO ESTEMOS EN EL ULTIMO TURNO, NO CARGAMOS DE NUEVO LA INTERFAZ DE TIRO DE LA MASCOTA
		if(cEC_ejercicioCanasta.num_turnoJugador <= 5){

			cEC_ejercicioCanasta.mostrarBotonMascota();
			
		}
	}
}
