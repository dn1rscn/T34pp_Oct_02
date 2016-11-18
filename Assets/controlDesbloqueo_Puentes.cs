using UnityEngine;
using System.Collections;

public class controlDesbloqueo_Puentes : MonoBehaviour {

	ControlDatosGlobales_Mundo3D CDG_Mundo3D;


	public GameObject grupoPuenteRoto;
	public GameObject grupoPuenteArreglado;



	// Use this for initialization
	void Start () {

		CDG_Mundo3D = GameObject.Find("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D>();

		grupoPuenteRoto.SetActive(true);
		grupoPuenteArreglado.SetActive(false);

		if(Application.loadedLevelName == "Isla_bosque"){
			if(CDG_Mundo3D.IslaFantasma_Desbloqueada){
				grupoPuenteRoto.SetActive(false);
				grupoPuenteArreglado.SetActive(true);
			}
		}
		if(Application.loadedLevelName == "Isla_fantasma"){
			if(CDG_Mundo3D.IslaMec_Desbloqueada){
				grupoPuenteRoto.SetActive(false);
				grupoPuenteArreglado.SetActive(true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
