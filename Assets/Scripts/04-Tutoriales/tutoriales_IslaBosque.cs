using UnityEngine;
using System.Collections;

public class tutoriales_IslaBosque : MonoBehaviour {

	Animator animator_grpTutoriales;
	ControlProtaMouse_2 scriptCtrlProta;

	public void Start(){
		scriptCtrlProta = GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2>();
		scriptCtrlProta.enabled = false;

		Time.timeScale = 1;	
		animator_grpTutoriales = GetComponent<Animator>();
	}

	public void pasarTutorial_01(){
		Time.timeScale = 1;	
		animator_grpTutoriales.Play("Tutoriales_IslaBosque_01");
	}

	public void pasarTutorial_02(){
		animator_grpTutoriales.Play("Tutoriales_IslaBosque_02");

		//activar el control para el prota
		scriptCtrlProta.enabled = true;
		Time.timeScale = 1;	
	}

	public void pausarTiempo(){
		Time.timeScale = 0;	
	}
}
