using UnityEngine;
using System.Collections;

public class pasarDeEscena : MonoBehaviour {

	public string escenaSiguiente;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void reproducirAudio (){
		GameObject.Find ("audioIntroIkki_1").GetComponent<AudioSource>().Play();
	}


	public void siguienteEscena (){

		if(escenaSiguiente==""){
			print ("Debes especificar el nombre de la escena siguiente en el Inspector");
		} 

		else {

			Application.LoadLevel(escenaSiguiente);

		}
	}
}
