using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class barraCarga : MonoBehaviour {

	public GameObject imagen;
	public Slider barra;

	private AsyncOperation asyn;

	public void AbrirPantallaDeCarga(int nivel)
	{
		imagen.SetActive (true);
		StartCoroutine (cargarNivel (nivel));
	}

	IEnumerator cargarNivel(int nivel)
	{
		asyn = Application.LoadLevelAsync (nivel);
		while (!asyn.isDone) 
		{
			barra.value = asyn.progress;
			yield return null;
		}
	}

}
