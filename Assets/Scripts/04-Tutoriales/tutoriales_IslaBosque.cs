using UnityEngine;
using System.Collections;

public class tutoriales_IslaBosque : MonoBehaviour {

	Animator animator_grpTutoriales;
	ControlProtaMouse_2 scriptCtrlProta;

	ControlDatosGlobales_Mundo3D CDG_Mundo3D;

	public void Start(){
		scriptCtrlProta = GameObject.Find ("Chico_TEAPlay").GetComponent<ControlProtaMouse_2>();
		animator_grpTutoriales = GetComponent<Animator>();

		CDG_Mundo3D = GameObject.Find("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D>();

		scriptCtrlProta.enabled = false;
		print("scriptProta_desactivado");


		//Si es la primera vez que accedemos a la isla:
		if(!CDG_Mundo3D.hemosVisto_TutorialIslaBosque){
			print ("ACTIVAR TUTORIAL");
			animator_grpTutoriales.Play("Tutoriales_IslaBosque_00");
			activarTutorialInicial();

		}	
		//Si ya hemos completado al menos una vez el tutorial:
		else {
			print ("DESACTIVAR TUTORIAL");
			//desactivarTutorialInicial();
			scriptCtrlProta.enabled = true;
			animator_grpTutoriales.Play("Tutoriales_EsconderTutoIslaBosque");
		}
	}

	public void desactivarTutorialInicial(){
		scriptCtrlProta.enabled = false;
		animator_grpTutoriales.Play("Tutoriales_EsconderTutoIslaBosque");
	}

	public void activarTutorialInicial(){
		scriptCtrlProta.enabled = false;
		animator_grpTutoriales.Play("Tutoriales_IslaBosque_00");
		print ("ACTIVAR EL TUTORIAL ... OTRA VEZ...   -__- ");
	} 

	public void pasarTutorial_01(){
		scriptCtrlProta.enabled = false;
		animator_grpTutoriales.Play("Tutoriales_IslaBosque_01");
	}

	public void pasarTutorial_02(){
		animator_grpTutoriales.Play("Tutoriales_IslaBosque_02");
	
		CDG_Mundo3D.hemosVisto_TutorialIslaBosque = true;
	
		//activar el control para el prota
		scriptCtrlProta.enabled = true;
		print("scriptProta_activado");

	}

	public void pausarTiempo(){
		//Time.timeScale = 0;	
		scriptCtrlProta.enabled = false;

	}
}
