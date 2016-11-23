using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlAleatorioSocialNivel2 : MonoBehaviour 
{
	public Sprite[] AImREspuesta;
	public GameObject[] ARespuestas;
	public GameObject[] APreguntas;

	public int PreguntaAleat;
	public int respuestaAleat;
	// Use this for initialization
	void Start () 
	{
		AleatorioResp ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void AleatorioResp()
	{
		APreguntas[0].SetActive(false);
		APreguntas[1].SetActive(false);
		APreguntas[2].SetActive(false);
		PreguntaAleat = Random.Range (1, 4);
		switch (PreguntaAleat) 
		{
		case 1:
			APreguntas[0].SetActive(true);
			respuestaAleat=Random.Range(1,3);
			switch (respuestaAleat) 
			{
			case 1:
				ARespuestas [0].GetComponent<Image> ().sprite = AImREspuesta [0];
				ARespuestas [1].GetComponent<Image> ().sprite = AImREspuesta [1];
				break;
			case 2:
				ARespuestas [0].GetComponent<Image> ().sprite = AImREspuesta [1];
				ARespuestas [1].GetComponent<Image> ().sprite = AImREspuesta [0];
				break;
			}
			break;
		case 2:
			APreguntas[1].SetActive(true);
			respuestaAleat=Random.Range(1,3);
			switch (respuestaAleat) 
			{
			case 1:
				ARespuestas [0].GetComponent<Image> ().sprite = AImREspuesta [2];
				ARespuestas [1].GetComponent<Image> ().sprite = AImREspuesta [3];
				break;
			case 2:
				ARespuestas [0].GetComponent<Image> ().sprite = AImREspuesta [3];
				ARespuestas [1].GetComponent<Image> ().sprite = AImREspuesta [2];
				break;
			}
			break;
		case 3:
			APreguntas[2].SetActive(true);
			respuestaAleat=Random.Range(1,3);
			switch (respuestaAleat) 
			{
			case 1:
				ARespuestas [0].GetComponent<Image> ().sprite = AImREspuesta [4];
				ARespuestas [1].GetComponent<Image> ().sprite = AImREspuesta [5];
				break;
			case 2:
				ARespuestas [0].GetComponent<Image> ().sprite = AImREspuesta [5];
				ARespuestas [1].GetComponent<Image> ().sprite = AImREspuesta [4];
				break;
			}
			break;
		}
	}
}
