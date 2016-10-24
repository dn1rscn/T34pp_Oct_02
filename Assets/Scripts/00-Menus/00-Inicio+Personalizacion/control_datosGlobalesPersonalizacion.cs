using UnityEngine;
using System.Collections;

public class control_datosGlobalesPersonalizacion : MonoBehaviour 
{
	public static control_datosGlobalesPersonalizacion cont;

	public int posicion_pelo=0;
	public int posicion_piel=0;
	public int posicion_camiseta=0;
	public int posicion_piernas=0;
	public int Sexo=0;
	//public int posicion_complementos=0;

	//public bool complementos=false;
	public bool pelo=false;
	public bool piel=false;
	public bool camiseta=false;
	public bool piernas=false;
	//public bool mascotas=false;

	public bool nuevoJuego=true;
	public bool inicio=true;
	
	//public Texture[] Atexture_Piel;
	//public Texture[] Atexture_camiseta;


	public int mascota;

	public bool Vper_activo;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this);
	
	}
	void Awake ()
	{
		
		if (cont == null) {
			cont = this;
			DontDestroyOnLoad (gameObject);
		} else if (cont != this) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
