using UnityEngine;
using System.Collections;

public class CtrBotones : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Pan()
	{
		Application.LoadLevel ("SECUENCIAS_ComprarPan");
	}
	public void Telefono()
	{
		Application.LoadLevel ("SECUENCIAS_LlamarTelefono");
	}
	public void Dientes()
	{
		Application.LoadLevel ("SECUENCIAS_Dientes");
	}
	public void volver()
	{
		Application.LoadLevel ("SECUENCIAS_menu_seleccion");
	}
	public void calle()
	{
		Application.LoadLevel ("SECUENCIAS_CruzarCalle");
	}
}
