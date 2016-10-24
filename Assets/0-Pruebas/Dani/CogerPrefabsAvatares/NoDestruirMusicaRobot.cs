using UnityEngine;
using System.Collections;

public class NoDestruirMusicaRobot : MonoBehaviour {

	public static NoDestruirMusicaRobot cont;
	
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
		   Application.loadedLevelName =="05_1-Mundo3D_IslaFantasma"||
		   Application.loadedLevelName =="04_SeleccionPersonajes_IslaRobot"||
		   Application.loadedLevelName =="04_2-BONUS-PuzzlesLvl1"||
		   Application.loadedLevelName =="04_2-BONUS-PuzzlesLvl2"||
		   Application.loadedLevelName =="04_2-BONUS-PuzzlesLvl3")
		{
			Destroy(gameObject);
		}
		
	}
}
