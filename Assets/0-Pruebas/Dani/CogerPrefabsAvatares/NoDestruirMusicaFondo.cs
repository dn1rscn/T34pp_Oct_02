using UnityEngine;
using System.Collections;

public class NoDestruirMusicaFondo : MonoBehaviour {

	public static NoDestruirMusicaFondo cont;

	void Awake ()
	{
		
		if (cont == null) {
			cont = this;
			DontDestroyOnLoad (gameObject);
		} else if (cont != this) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Application.loadedLevelName =="03_1-Mundo3D_IslaDino"||
		   Application.loadedLevelName =="01_MenuInicial"||
		   Application.loadedLevelName =="04_1-Mundo3D_IslaRobot"||
		   Application.loadedLevelName =="05_SeleccionPersonajes_IslaFantasma")
		{
			Destroy(gameObject);
		}
	
	}
}
