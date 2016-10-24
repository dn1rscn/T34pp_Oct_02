using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class GameControler : MonoBehaviour 
{
	[SerializeField]
	private Sprite bgImage;	
	public Sprite[] puzzles;

	//LISTAS DE SPRITES RANDOM PARA EL PUZZLE//

	public List <Button> btns = new List <Button>();
	public List <Sprite> gamePuzzles = new List<Sprite> ();

	//VARIABLES DE BOTON DE PUZZLE 1 y 2//

	private bool primeraRespuesta;
	private bool segundaRespuesta;



	//VARIABLES DE RESPUESTA ADIVinar// -- //LOGICA DE JUEGO//

	private int contarRespuestas;
	private int contarRespuestasCorrectas;
	private int respuestasJuego;

	private int adivPrimeraRespuesta;
	private int adivSegundaRespuesta;

	private string primeraRespuestaPuzzle;
	private string segundaRespuestaPuzzle;

	void Awake ()
	{
		puzzles = Resources.LoadAll<Sprite> ("Sprites/IslaDINO");
	}

	void Start ()
	{
		GetButtons();
		AddListeners();
		SumarPuzzles();
		Shuffle (gamePuzzles);
		respuestasJuego = gamePuzzles.Count / 2;
	}

	void GetButtons()
	{
		GameObject [] objects = GameObject.FindGameObjectsWithTag ("PuzzleButton");

		for (int i=0; i<objects.Length; i++)
		{
			btns.Add(objects[i].GetComponent<Button>());
			btns[i].image.sprite = bgImage;
		}
	}

	void SumarPuzzles ()
	{
		int looper = btns.Count;
		int index = 0;
		for (int i=0; i<looper; i++)
		{
			if (index == looper / 2)
			{
				index = 0;
			}

			gamePuzzles.Add (puzzles[index]);
			index++;
		}
	}

	void AddListeners()
	{
		foreach (Button btn in btns)
		{
			btn.onClick.AddListener(() => PickAPuzzle());
		}
	}

	public void PickAPuzzle()
	{
		if (!primeraRespuesta)
		{
			//print ((UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name).ToString());

			primeraRespuesta = true;

			adivPrimeraRespuesta = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			primeraRespuestaPuzzle = gamePuzzles[adivPrimeraRespuesta].name;

			btns[adivPrimeraRespuesta].image.sprite = gamePuzzles[adivPrimeraRespuesta];

		}else if (!segundaRespuesta)
		{

			//print ((UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name).ToString());
			segundaRespuesta = true;
			
			adivSegundaRespuesta = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			segundaRespuestaPuzzle = gamePuzzles[adivSegundaRespuesta].name;
			
			btns[adivSegundaRespuesta].image.sprite = gamePuzzles[adivSegundaRespuesta];

			contarRespuestas++;

			StartCoroutine(CheckIfThePuzzlesMatch());

		}

	}

	IEnumerator CheckIfThePuzzlesMatch () 
	{
		yield return new WaitForSeconds (0.5f);
		
		if (adivPrimeraRespuesta == adivSegundaRespuesta)
		{
			btns[adivPrimeraRespuesta].image.sprite = bgImage;	
			btns[adivSegundaRespuesta].image.sprite = bgImage;
		}
		
		if(primeraRespuestaPuzzle == segundaRespuestaPuzzle)
		{
			if(adivPrimeraRespuesta != adivSegundaRespuesta) //PARA QUE NO DESAPAREZCA EL BOTON SI LE DAS DOS VECES// CHECK DE NOMBRES DE ITEM PULSADO //
			{


				yield return new WaitForSeconds (.5f);
				btns[adivPrimeraRespuesta].interactable = false;
				btns[adivSegundaRespuesta].interactable = false;
				
				btns[adivPrimeraRespuesta].image.color = new Color (0,0,0,0);
				btns[adivSegundaRespuesta].image.color = new Color (0,0,0,0);
				
				
				CheckIfTheGameIsFinished ();
			}
		}else
		{
			VoltearBotonesFallo();
		}
		
		
		
		yield return new WaitForSeconds (.2f);
		
		primeraRespuesta = segundaRespuesta = false;
		
		
	}


	void CheckIfTheGameIsFinished ()
	{
		//HAS ACERTADO
		GameObject.Find("SonidoAcierto").GetComponent<AudioSource>().Play();

		contarRespuestasCorrectas++;

		if (contarRespuestasCorrectas == respuestasJuego)
		{
			Debug.Log ("Juego Terminado");
			Debug.Log ("Has utilizado " + contarRespuestas + " movimientos para terminar el puzzle");

		
			Application.LoadLevel ("04_1-Mundo3D_IslaRobot");

		}

	}

	void Shuffle (List<Sprite> list)
	{

		for (int i=0; i < list.Count; i++)
		{

			Sprite temp = list[i];
			int randomIndex = Random.Range(i,list.Count);
			list[i] = list[randomIndex];
			list[randomIndex]=temp;

		}

	}

	void VoltearBotonesFallo ()
	{
		btns[adivPrimeraRespuesta].image.sprite = bgImage;	
		btns[adivSegundaRespuesta].image.sprite = bgImage;
	}
}
