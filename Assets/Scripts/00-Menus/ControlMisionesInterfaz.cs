using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlMisionesInterfaz : MonoBehaviour 
{
	ControlDatosGlobales_Mundo3D cdg_3d;
	ControlMisiones CMisiones;

	public Sprite[] MisionesOK;

	public GameObject misionDino;
	public GameObject misionFantasma;
	public GameObject misionRobot;

	// Use this for initialization
	void Start () 
	{
		cdg_3d=GameObject.Find ("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D> ();
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();

		if (CMisiones.misionDinoCompletada == true) 
		{
			misionDino.GetComponent<Button>().enabled=true;
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
			misionFantasma.GetComponent<Button>().enabled=true;
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
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void MisionDinoOK()
	{
		//sumar mas monedas
		print ("Sumas monedas");
		misionDino.SetActive (false);

	}
	public void MisionFantasmaOK()
	{
		//sumar monedas
		misionFantasma.SetActive (false);
	}
	public void MisionRobotOK()
	{
	}
}
