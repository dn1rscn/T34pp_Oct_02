using UnityEngine;
using System.Collections;

public class ControlEscenas : MonoBehaviour {


	Animator animator_PanelCanvas;
	ControlDatosGlobales_Mundo3D CDG_Mundo3D;

	ControlMisiones CMisiones;

	ControlSecuencias cs;
	ControlEmociones CE;
	ControlSonidos CS;



	// Use this for initialization
	void Start () {

		//SI EXISTE, ACCEDEMOS AL SCRIPT DE DATOS GLOBALES
		if(GameObject.Find("ControlDatosGlobales")){
			CDG_Mundo3D = GameObject.Find("ControlDatosGlobales").GetComponent<ControlDatosGlobales_Mundo3D>();
		}

		if(GameObject.Find("Panel_Canvas"))
		{
		animator_PanelCanvas = GameObject.Find("Panel_Canvas").GetComponent<Animator>();
		}
	}
	
	public void siguienteEscena() {
		
		if (Application.loadedLevelName == "03_Mundo3D" || Application.loadedLevelName == "04_Nivel1-PICTOGRAMAS") {
			//animator_PanelCanvas.Play ("pasarABlanco");
		}
		//Invoke ("cargarEscena", 100 * Time.deltaTime);

	}

	public void cargarEscena (){

		if (Application.loadedLevelName == "01_MenuInicial"){

			//Ejecutamos la animacion de la camara
			GameObject.Find("Main Camera").GetComponent<Animator>().SetBool("camaraPlay",true);
			//Y hacemos que los botones del inicio se vayan
			DesaparecerBotonesINTRO();
	
		}

		else if (Application.loadedLevelName == "02_VideoINTRO"){
			
			Application.LoadLevel ("03_Mundo3D");
		}

		if (Application.loadedLevelName == "03_Mundo3D"){
		//	animator_PanelCanvas.Play("pasarABlanco");
			Application.LoadLevel ("04_Nivel1-PICTOGRAMAS");
		}
		
		if (Application.loadedLevelName == "04_Nivel1-PICTOGRAMAS"){
		//	animator_PanelCanvas.Play("pasarABlanco");
			Application.LoadLevel ("03_Mundo3D");
		}

	}


	public void pasarABlanco(){
		GameObject.Find("Panel").GetComponent<Animator>().Play("PasarABlanco");
	}

	public void HacerAparecerBotonesINTRO(){
		GameObject.Find("BotonesINICIO").GetComponent<Animator>().Play("Aparecer");
	}
	public void DesaparecerBotonesINTRO(){
		GameObject.Find("BotonesINICIO").GetComponent<Animator>().SetBool("desaparecerBotones",true);
	}

	public void CargarInicio(){


		Application.LoadLevel ("01_MenuInicial");
	}

	public void CargarSeleccionDePersonajesDINO(){
		//guardarPosicionProta
		//guardarPosicionMascota
		Application.LoadLevel ("02_SeleccionPersonajes");
	}

	public void CargarSeleccionDePersonajesROBOT(){
		//guardarPosicionProta
		//guardarPosicionMascota
		Application.LoadLevel ("04_SeleccionPersonajes_IslaRobot");
	}

	public void CargarSeleccionDePersonajesFANTASMA(){
		//guardarPosicionProta
		//guardarPosicionMascota
		Application.LoadLevel ("05_SeleccionPersonajes_IslaFantasma");
	}


	//******************CARGAR ISLAS*****************************************************
	public void CargarIslaDinoDirecto()
	{
		Application.LoadLevel ("Isla_bosque");
		CDG_Mundo3D.islaBosque = true;
		CDG_Mundo3D.islaMec = false;
		CDG_Mundo3D.islaFant = false;
	}
	/*
	public void CargarIslaDino(){

		if(!CDG_Mundo3D.primeraVez_IslaDino)
		{
			Application.LoadLevel ("03_1-Mundo3D_IslaDino");
			CDG_Mundo3D.islaBosque = true;
			CDG_Mundo3D.islaMec = false;
			CDG_Mundo3D.islaFant = false;
		} 
		else{
			Application.LoadLevel ("01_MenuInicial");
		}
	}
	*/
	public void CargarIslaRobot(){
		Application.LoadLevel ("Isla_Mecanica_v3");
		CDG_Mundo3D.islaBosque = false;
		CDG_Mundo3D.islaMec = true;
		CDG_Mundo3D.islaFant = false;
	}
	public void CargarIslaFantasma(){
		Application.LoadLevel ("Isla_fantasma");
		CDG_Mundo3D.islaBosque = false;
		CDG_Mundo3D.islaMec = false;
		CDG_Mundo3D.islaFant = true;
	}

	//**********************************************************************************

	//******************CARGAR EJERCICIOS*****************************************************

	public void CargarSelecNivelDado()
	{
		Application.LoadLevel ("Dado_SeleccionNivel");
	}
	public void CargarPICTOGRAMAS_Nivel1()
	{
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();
		CMisiones.dado1 = true;
		CMisiones.dado2 = false;
		Application.LoadLevel ("Nivel1_dado2.0");
	}
	public void CargarPICTOGRAMAS_Nivel2()
	{
		CMisiones=GameObject.Find ("Misiones").GetComponent<ControlMisiones>();
		CMisiones.dado1 = false;
		CMisiones.dado2 = true;
		Application.LoadLevel ("Nivel2_dado2.0");
	}


	public void CargarBONUS_IslaDINO(){
		Application.LoadLevel ("04_2-BONUS-PuzzlesLvl1");
		
	}
	public void CargarBONUS_IslaROBOT(){
		Application.LoadLevel ("04_2-BONUS-PuzzlesLvl2");
		
	}
	public void CargarBONUS_IslaFANTASMA(){
		Application.LoadLevel ("04_2-BONUS-PuzzlesLvl3");
		
	}

	public void CargarSECUENCIAS(){
		Application.LoadLevel ("SECUENCIAS_menu_seleccion");
		
	}
	public void secuencia_Dientes()
	{
		cs = GameObject.Find ("DatosGlobalesSecuencias").GetComponent<ControlSecuencias> ();
		cs.Secuencia = 1;

		Application.LoadLevel ("SECUENCIAS_Dientes");
	}

	public void secuencia_telefono()
	{
		cs = GameObject.Find ("DatosGlobalesSecuencias").GetComponent<ControlSecuencias> ();
		cs.Secuencia = 2;

		Application.LoadLevel ("SECUENCIAS_LlamarTelefono");
	}
	public void secuencia_Pan()
	{
		cs = GameObject.Find ("DatosGlobalesSecuencias").GetComponent<ControlSecuencias> ();
		cs.Secuencia = 3;

		Application.LoadLevel ("SECUENCIAS_ComprarPan");
	}
	public void secuencia_calle()
	{
		cs = GameObject.Find ("DatosGlobalesSecuencias").GetComponent<ControlSecuencias> ();
		cs.Secuencia = 4;

		Application.LoadLevel ("SECUENCIAS_CruzarCalle");
	}
	public void canasta()
	{
		Application.LoadLevel ("10_iFantasma_P2_Canasta");
	}
	public void cargarSonidos()
	{
		Application.LoadLevel ("Sonidos_menu_Seleccion");
	}
	public void CargarSonidosNivel1()
	{
		CS = GameObject.Find ("ctrSonidos").GetComponent<ControlSonidos> ();
		CS.nivel = 1;
		Application.LoadLevel ("SonidosNivel1");
	}
	public void CargarSonidosNivel2()
	{
		CS = GameObject.Find ("ctrSonidos").GetComponent<ControlSonidos> ();
		CS.nivel = 2;

		Application.LoadLevel ("SonidosNivel2");
	}
	public void CargarSonidosNivel3()
	{
		CS = GameObject.Find ("ctrSonidos").GetComponent<ControlSonidos> ();
		CS.nivel = 3;
		Application.LoadLevel ("SonidosNivel3");
	}
	public void CargarSocial()
	{
		Application.LoadLevel ("1-Social_SelecNivel");
	}
	public void CargarSocialNivel1()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CE.NivelEmpatia = 1;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void CargarGlobo ()
	{
		
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CE.NivelEmpatia = 1;
		CE.EjercicioSocial = 1;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void CargarHelado()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CE.NivelEmpatia = 1;
		CE.EjercicioSocial = 2;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void CargarTormenta()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CE.NivelEmpatia = 1;
		CE.EjercicioSocial = 3;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void CargarSocialNivel2()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CE.NivelEmpatia = 2;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void CargarSocialNivel3()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CE.NivelEmpatia = 3;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void CargarGloboNivel3()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CE.NivelEmpatia = 3;
		CE.EjercicioSocial = 1;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void CargarHeladoNivel3()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CE.NivelEmpatia = 3;
		CE.EjercicioSocial = 2;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void CargarTormentaNivel3()
	{
		CE = GameObject.Find ("ctrEmociones").GetComponent<ControlEmociones> ();
		CE.NivelEmpatia = 3;
		CE.EjercicioSocial = 2;
		Application.LoadLevel ("Emociones_Empatia");
	}
	public void CargarEmociones()
	{
		Application.LoadLevel ("2-Emociones_SelecNivel");
	}
	public void CargarEmocionesNivel1()
	{
		Application.LoadLevel ("2.1-Emociones_Nivel1");
	}
	public void CargarEmocionesNivel2()
	{
		Application.LoadLevel ("2.2-Emociones_Nivel2");
	}
	public void CargarEmocionesNivel3()
	{
		Application.LoadLevel ("2.3-Emociones_Nivel3");
	}


	//**********************************************************************************

	public void CargarEscenaPERSONALIZAR()
	{
		Application.LoadLevel ("personalizacion1");
	}
}

