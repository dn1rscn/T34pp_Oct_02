using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class control_ventanas_personalizar : MonoBehaviour 
{
	control_datosGlobalesPersonalizacion cdgp;

	GameObject gObj_pelo;
	GameObject gObj_piel;	
	GameObject gObj_camiseta;
	GameObject gObj_piernas;

	GameObject gObj_FlechasSeleccion;

	Color opaco = new Color(255,255,255,1.0f) ;
	Color trans = new Color(255,255,255,0.5f);

	// Use this for initialization
	void Start () 
	{
		gObj_pelo= GameObject.Find ("pelo");
		gObj_piel= GameObject.Find ("piel");
		gObj_camiseta= GameObject.Find ("camiseta");
		gObj_piernas= GameObject.Find ("pantalones");

		gObj_FlechasSeleccion=GameObject.Find("flechas");
		gObj_FlechasSeleccion.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	/*public void cambiar_complementos()
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();
		cdgp.complementos = true;
		cdgp.pelo = false;
		cdgp.piel = false;
		cdgp.camiseta = false;
		cdgp.piernas = false;

	}*/
	public void cambiar_pelo()
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();

		//Activamos las flechas de seleccion al elegir una categoria
		gObj_FlechasSeleccion.SetActive (true);

		//Desactivamos el resto de opciones
		gObj_piel.GetComponent<Image>().color = trans;
		gObj_camiseta.GetComponent<Image>().color = trans;
		gObj_piernas.GetComponent<Image>().color = trans;

		//Y activamos la opacidad del boton "cambiar pelo"
		gObj_pelo.GetComponent<Image>().color = opaco;

		//cdgp.complementos = false;
		cdgp.pelo = true;
		cdgp.piel = false;
		cdgp.camiseta = false;
		cdgp.piernas = false;
	}
	public void cambiar_piel()
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();

		//Activamos las flechas de seleccion al elegir una categoria
		gObj_FlechasSeleccion.SetActive (true);

		//Desactivamos el resto de opciones
		gObj_pelo.GetComponent<Image>().color = trans;
		gObj_camiseta.GetComponent<Image>().color = trans;
		gObj_piernas.GetComponent<Image>().color = trans;
		
		//Y activamos la opacidad del boton "cambiar piel"
		gObj_piel.GetComponent<Image>().color = opaco;

		//cdgp.complementos = false;
		cdgp.pelo = false;
		cdgp.piel = true;
		cdgp.camiseta = false;
		cdgp.piernas = false;
	}
	public void cambiar_camiseta()
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();

		//Activamos las flechas de seleccion al elegir una categoria
		gObj_FlechasSeleccion.SetActive (true);

		//Desactivamos el resto de opciones
		gObj_pelo.GetComponent<Image>().color = trans;
		gObj_piel.GetComponent<Image>().color = trans;
		gObj_piernas.GetComponent<Image>().color = trans;
		
		//Y activamos la opacidad del boton "cambiar camiseta"
		gObj_camiseta.GetComponent<Image>().color = opaco;

		//cdgp.complementos = false;
		cdgp.pelo = false;
		cdgp.piel = false;
		cdgp.camiseta = true;
		cdgp.piernas = false;
	}
	public void cambiar_piernas()
	{
		cdgp = GameObject.Find ("datosGlobalesPersonalizacion").GetComponent<control_datosGlobalesPersonalizacion> ();

		//Activamos las flechas de seleccion al elegir una categoria
		gObj_FlechasSeleccion.SetActive (true);

		//Desactivamos el resto de opciones
		gObj_pelo.GetComponent<Image>().color = trans;
		gObj_piel.GetComponent<Image>().color = trans;
		gObj_camiseta.GetComponent<Image>().color = trans;
		
		//Y activamos la opacidad del boton "cambiar piernas"
		gObj_piernas.GetComponent<Image>().color = opaco;

		//cdgp.complementos = false;
		cdgp.pelo = false;
		cdgp.piel = false;
		cdgp.camiseta = false;
		cdgp.piernas = true;
	}
}
