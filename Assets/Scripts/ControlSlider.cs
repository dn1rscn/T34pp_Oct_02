using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlSlider : MonoBehaviour 
{
	public Slider BarraProgreso;

	public GameObject[] estrellas;
	public Sprite estrellaactiva;
	public Sprite NOstrella;

	ControlDatosGlobales_PICTOGRAMAS cdg;
	ControlSonidos CS;
	ControlSecuencias cs;
	ControlEmociones CE;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ProgresoDado()
	{
		cdg = GameObject.Find ("DatosGlobales").GetComponent<ControlDatosGlobales_PICTOGRAMAS> ();


		//while (BarraProgreso.value<cdg.aciertos) 
		//{
		BarraProgreso.value = cdg.aciertos; //(Valor += Time.deltaTime);
		if (BarraProgreso.value == 5) 
		{
			estrellas[0].GetComponent<Image>().sprite=estrellaactiva;
		}
		if (BarraProgreso.value == 10) 
		{
			estrellas[1].GetComponent<Image>().sprite=estrellaactiva;
			estrellas[2].GetComponent<Image>().sprite=estrellaactiva;
		}
		if (BarraProgreso.value == 15) 
		{
			estrellas[3].GetComponent<Image>().sprite=estrellaactiva;
			estrellas[4].GetComponent<Image>().sprite=estrellaactiva;
			estrellas[5].GetComponent<Image>().sprite=estrellaactiva;
		}

		//}
	}

	public void progresoSonidos()
	{
		CS = GameObject.Find ("ctrSonidos").GetComponent<ControlSonidos> ();

		BarraProgreso.value = CS.aciertos;

		if (BarraProgreso.value == 1) 
		{
			estrellas[0].GetComponent<Image>().sprite=estrellaactiva;
		}
		if (BarraProgreso.value == 2) 
		{
			estrellas[1].GetComponent<Image>().sprite=estrellaactiva;
			estrellas[2].GetComponent<Image>().sprite=estrellaactiva;
		}
		if (BarraProgreso.value == 4) 
		{
			estrellas[3].GetComponent<Image>().sprite=estrellaactiva;
			estrellas[4].GetComponent<Image>().sprite=estrellaactiva;
			estrellas[5].GetComponent<Image>().sprite=estrellaactiva;
		}
	}

	public void progresoSecuencias()
	{
		cs = GameObject.Find ("DatosGlobalesSecuencias").GetComponent<ControlSecuencias> ();
		BarraProgreso.value = 3-(cs.fallos);

		if (BarraProgreso.value == 2) //0 intentos
		{
			estrellas[3].GetComponent<Image>().sprite=NOstrella;
			estrellas[4].GetComponent<Image>().sprite=NOstrella;
			estrellas[5].GetComponent<Image>().sprite=NOstrella;
		}

		if (BarraProgreso.value == 1) // 1 jntentos
		{
			estrellas[1].GetComponent<Image>().sprite=NOstrella;
			estrellas[2].GetComponent<Image>().sprite=NOstrella;
		}
		if (BarraProgreso.value == 0) //2 intentos
		{
			estrellas[0].GetComponent<Image>().sprite=NOstrella;
		}
	}
	public void progresoEmocionesSNivel1()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();

		BarraProgreso.value = 4 -(CE.Intentos);

		if (BarraProgreso.value == 2) //2 intentos
		{
			estrellas[3].GetComponent<Image>().sprite=NOstrella;
			estrellas[4].GetComponent<Image>().sprite=NOstrella;
			estrellas[5].GetComponent<Image>().sprite=NOstrella;
		}

		if (BarraProgreso.value == 1) //3 intentos
		{
			estrellas[1].GetComponent<Image>().sprite=NOstrella;
			estrellas[2].GetComponent<Image>().sprite=NOstrella;
		}
		if (BarraProgreso.value == 0) //+ de 3 intentos
		{
			estrellas[0].GetComponent<Image>().sprite=NOstrella;
		}
	}

	public void progresoEmocionesNivel1()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		
		BarraProgreso.value = 4 -(CE.Intentos);
		
		if (BarraProgreso.value == 2) //2 intentos
		{
			estrellas[3].GetComponent<Image>().sprite=NOstrella;
			estrellas[4].GetComponent<Image>().sprite=NOstrella;
			estrellas[5].GetComponent<Image>().sprite=NOstrella;
		}
		
		if (BarraProgreso.value == 1) //3 intentos
		{
			estrellas[1].GetComponent<Image>().sprite=NOstrella;
			estrellas[2].GetComponent<Image>().sprite=NOstrella;
		}
		if (BarraProgreso.value == 0) //+ de 3 intentos
		{
			estrellas[0].GetComponent<Image>().sprite=NOstrella;
		}
	}
	public void progresoEmocionesNivel2()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		
		BarraProgreso.value = 5 -(CE.Intentos);
		
		if (BarraProgreso.value == 3) //2 intentos
		{
			estrellas[3].GetComponent<Image>().sprite=NOstrella;
			estrellas[4].GetComponent<Image>().sprite=NOstrella;
			estrellas[5].GetComponent<Image>().sprite=NOstrella;
		}
		
		if (BarraProgreso.value == 1) //4 intentos
		{
			estrellas[1].GetComponent<Image>().sprite=NOstrella;
			estrellas[2].GetComponent<Image>().sprite=NOstrella;
		}
		if (BarraProgreso.value == 0) //+ de 4 intentos
		{
			estrellas[0].GetComponent<Image>().sprite=NOstrella;
		}
	}
	public void progresoEmocionesNivel3()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		
		BarraProgreso.value = 7 -(CE.Intentos);
		
		if (BarraProgreso.value == 5) //2 intentos
		{
			estrellas[3].GetComponent<Image>().sprite=NOstrella;
			estrellas[4].GetComponent<Image>().sprite=NOstrella;
			estrellas[5].GetComponent<Image>().sprite=NOstrella;
		}
		
		if (BarraProgreso.value == 2) //4 intentos
		{
			estrellas[1].GetComponent<Image>().sprite=NOstrella;
			estrellas[2].GetComponent<Image>().sprite=NOstrella;
		}
		if (BarraProgreso.value == 0) //+ de 4 intentos
		{
			estrellas[0].GetComponent<Image>().sprite=NOstrella;
		}
	}
}
