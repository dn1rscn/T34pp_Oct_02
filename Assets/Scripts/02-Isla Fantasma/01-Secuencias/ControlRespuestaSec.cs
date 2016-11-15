using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ControlRespuestaSec : MonoBehaviour 
{
	public GameObject[] vidas;

	public Sprite primera;
	public Sprite segunda;
	public Sprite tercera;
	public GameObject P1;
	public GameObject P2;
	public GameObject P3;
	GameObject ctrlsecuencias;
	ControlSecuencias cs;
	controlSituaciones CSit;
	ControlSlider CSlider;

	FinPartida_Secuencias Fin_Sec;
	
	GameObject puntuacion;
	Text Tpuntuacion;

	// Use this for initialization
	void Start () 
	{
		ctrlsecuencias = GameObject.Find ("DatosGlobalesSecuencias");
		cs = ctrlsecuencias.GetComponent<ControlSecuencias> ();
		CSlider = GameObject.Find ("Progreso").GetComponent<ControlSlider> ();

		actualizarPuntuacion ();
		CSlider.progresoSecuencias ();

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	

	public void click()
	{
		Fin_Sec = GameObject.Find ("crtlFinPartida").GetComponent<FinPartida_Secuencias> ();
		ctrlsecuencias = GameObject.Find ("DatosGlobalesSecuencias");
		cs = ctrlsecuencias.GetComponent<ControlSecuencias> ();
		CSit=GameObject.Find ("ctrlSituaciones").GetComponent<controlSituaciones>();

		if (gameObject.GetComponent<Image> ().sprite.name == "Primera") 
		{
			P1.SetActive(true);
			P1.GetComponent<Image> ().sprite = primera;
			Destroy(gameObject);
			cs.p1=true;
		}
		else if (gameObject.GetComponent<Image> ().sprite.name == "Segunda"&&cs.p1==true) 
		{
			P2.SetActive(true);
			P2.GetComponent<Image> ().sprite = segunda;
			Destroy(gameObject);
			cs.p2=true;
		}
		else if (gameObject.GetComponent<Image> ().sprite.name == "Tercera"&&cs.p1==true&&cs.p2==true) 
		{
			P3.SetActive(true);
			P3.GetComponent<Image> ().sprite = tercera;
			Destroy(gameObject);
			cs.p3=true;

			//Invoke("finjuego",2);

			//HAS ACERTADO
			GameObject.Find("SonidoAcierto").GetComponent<AudioSource>().Play();
			
			//ejecutar animacionAcierto
			GameObject.Find("Panel_Canvas").GetComponent<Animator>().Play("acierto");
			//GameObject.Find("Boton_Volver").SetActive(false);

			Debug.Log("finjuego1");
			Fin_Sec.finjuego();

		}
		else 
		{
			print("fallo");

			cs.fallos++;
			actualizarPuntuacion();
			CSlider.progresoSecuencias ();

			if(cs.fallos==3)
			{
				vidas [cs.fallos-1].SetActive (false);
				Fin_Sec.finjuego();
			}
			else
			{
				vidas [cs.fallos-1].SetActive (false);
			}


			//ejecutar animacionError
			GameObject.Find("Panel_Canvas").GetComponent<Animator>().Play("Fallo");
			
			//ejecutarSonidoFallo
			GameObject.Find("SonidoFallo").GetComponent<AudioSource>().Play();
		}
	}
	
	void actualizarPuntuacion()
	{
		puntuacion = GameObject.Find ("puntuacion");
		Tpuntuacion = puntuacion.GetComponent<Text> ();
		
		Tpuntuacion.text = cs.fallos.ToString();
	}

}
