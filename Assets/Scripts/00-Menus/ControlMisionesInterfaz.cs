using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlMisionesInterfaz : MonoBehaviour 
{
	ControlDatosGlobales_Mundo3D cdg_3d;
	ControlMisiones CMisiones;
	Control_monedas cM;

	public Sprite[] MisionesOK;
	public GameObject[] objetivosOK_Dino;
	public GameObject[] objetivosOK_Fantasma;
	public GameObject[] objetivosOK_Robot;

	public GameObject misionDino;
	public GameObject misionFantasma;
	public GameObject misionRobot;

	public GameObject ObjetivosDino;
	public GameObject ObjetivosFantasma;
	public GameObject ObjetivosRobot;

	Text TMonedas;

	// Use this for initialization
	void Start () 
	{
		cdg_3d=GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();
		cM=GameObject.Find("controlMonedas").GetComponent<Control_monedas>();

		TMonedas = GameObject.Find ("monedas").GetComponent<Text> ();
		TMonedas.text = cM.monedas.ToString();

		objetivosMisionDino ();
		obejtivosMisionFantasma ();
		obejtivosMisionRobot ();

		ActualizarMisionDino ();
		ActualizarMisionFantasma();
		ActualizarMisionRobot();
	}
	public void ActualizarMisionDino()
	{
		if (CMisiones.misionDinoCompletada==false) 
		{
			if (cdg_3d.hemosHabladoConDino == true) 
			{//hablar con el dino
				misionDino.SetActive (true);
			} 
			else 
			{
				misionDino.SetActive (false);
			}
			//misionDino.GetComponent<Button>().enabled=true;
			
		} 
		else if(CMisiones.misionDinoCompletada==true&&cdg_3d.hemosHabladoConDino==true)
		{
			misionDino.GetComponent<Image> ().sprite = MisionesOK [0];
		}
	}
	public void ActualizarMisionFantasma()
	{
		if (CMisiones.misionFantasmaCompletada == false) 
		{
			if (cdg_3d.hemosHabladoConFantasma==true) 
			{
				misionFantasma.SetActive (true);
			} 
			else 
			{
				misionFantasma.SetActive (false);
			}
		} 
		else if(CMisiones.misionFantasmaCompletada==true&&cdg_3d.hemosHabladoConFantasma==true)
		{
			//cambiar imagen o remarcar mision
			//activar interactable
			//misionFantasma.GetComponent<Button>().enabled=true;
		}
	}
	public void ActualizarMisionRobot()
	{
		
		if (CMisiones.misionRobotCompletada == false) 
		{
			if (cdg_3d.hemosHabladoConRobot == true) 
			{
				misionRobot.SetActive (true);
			} 
			else 
			{
				misionRobot.SetActive (false);
			}
		} 
		else if(CMisiones.misionRobotCompletada==true&&cdg_3d.hemosHabladoConRobot==true)
		{
			//cambiar imagen o remarcar mision
			//activar interactable
		}
	}

	public void MisionDinoOK()
	{
		//sumar mas monedas
		print ("Sumas monedas");
		ObjetivosDino.SetActive (true);
		ObjetivosFantasma.SetActive (false);
		ObjetivosRobot.SetActive (false);
		GameObject.Find ("GrupoMisiones").GetComponent<Animator> ().Play ("abrirObjetivos");

	}
	public void MisionFantasmaOK()
	{
		//sumar monedas
		//misionFantasma.SetActive (false);
		ObjetivosDino.SetActive (false);
		ObjetivosFantasma.SetActive (true);
		ObjetivosRobot.SetActive (false);
		GameObject.Find ("GrupoMisiones").GetComponent<Animator> ().Play ("abrirObjetivos");
	}
	public void MisionRobotOK()
	{
		ObjetivosDino.SetActive (false);
		ObjetivosFantasma.SetActive (false);
		ObjetivosRobot.SetActive (true);
		GameObject.Find ("GrupoMisiones").GetComponent<Animator> ().Play ("abrirObjetivos");
	}

	public void cerrarObjetivos()
	{
		GameObject.Find ("GrupoMisiones").GetComponent<Animator> ().Play ("cerrarObjetivos");
	}

	void objetivosMisionDino()
	{
		for(int i=0; i<CMisiones.ejerB_3estrellas.Length; i++)
		{
			if(CMisiones.ejerB_3estrellas[i]==true)
			{
				objetivosOK_Dino[i].SetActive(true);
			}
			else
			{
				objetivosOK_Dino[i].SetActive(false);
			}
		}
	}
	void obejtivosMisionFantasma()
	{
		for(int i=0; i<CMisiones.ejerF_3estrellas.Length; i++)
		{
			if(CMisiones.ejerF_3estrellas[i]==true)
			{
				objetivosOK_Fantasma[i].SetActive(true);
			}
			else
			{
				objetivosOK_Fantasma[i].SetActive(false);
			}
		}
	}
	void obejtivosMisionRobot()
	{
		for(int i=0; i<CMisiones.ejerM_3estrellas.Length; i++)
		{
			if(CMisiones.ejerM_3estrellas[i]==true)
			{
				objetivosOK_Robot[i].SetActive(true);
			}
			else
			{
				objetivosOK_Robot[i].SetActive(false);
			}
		}
	}
}
