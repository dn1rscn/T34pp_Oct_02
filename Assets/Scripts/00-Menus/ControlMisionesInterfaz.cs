using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlMisionesInterfaz : MonoBehaviour 
{
	ControlDatosGlobales_Mundo3D cdg_3d;
	ControlMisiones CMisiones;
	Control_monedas cM;

	public Sprite[] MisionesOK;
	public GameObject[] objetivosOK;

	public GameObject misionDino;
	public GameObject misionFantasma;
	public GameObject misionRobot;

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

		if (CMisiones.misionDinoCompletada == true) 
		{
			//misionDino.GetComponent<Button>().enabled=true;
			misionDino.GetComponent<Image>().sprite = MisionesOK[0];
		}

		if (CMisiones.misionFantasmaCompletada == false) 
		{
			if (cdg_3d.IslaFantasma_Desbloqueada == true) 
			{
				misionFantasma.SetActive (true);
			} 
			else 
			{
				misionFantasma.SetActive (false);
			}
		} 
		else 
		{
			//cambiar imagen o remarcar mision
			//activar interactable
			//misionFantasma.GetComponent<Button>().enabled=true;
		}

		if (CMisiones.misionRobotCompletada == false) 
		{
			if (cdg_3d.IslaMec_Desbloqueada == true) 
			{
				misionRobot.SetActive (true);
			} 
			else 
			{
				misionRobot.SetActive (false);
			}
		} 
		else 
		{
			//cambiar imagen o remarcar mision
			//activar interactable
		}

	}

	public void MisionDinoOK()
	{
		//sumar mas monedas
		print ("Sumas monedas");
		GameObject.Find ("GrupoMisiones").GetComponent<Animator> ().Play ("abrirObjetivos");

	}
	public void MisionFantasmaOK()
	{
		//sumar monedas
		//misionFantasma.SetActive (false);
	}
	public void MisionRobotOK()
	{
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
				objetivosOK[i].SetActive(true);
			}
			else
			{
				objetivosOK[i].SetActive(false);
			}
		}
	}
}
