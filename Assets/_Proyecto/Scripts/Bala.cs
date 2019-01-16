using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour 
{
	
	public float TiempoEspera;
	
	float TiempoOriginal;

	// Use this for initialization
	void Start () 
	{
		TiempoOriginal = TiempoEspera;
	}
	
	// Update is called once per frame
	void Update () 
	{
		TiempoEspera -= Time.deltaTime;
		
		// Cuando se acaba el tiempo de espera apagamos el objeto por cuestiones de memoria y optimizacion
		if(TiempoEspera <= 0.0f)
		{
			gameObject.SetActive(false);
			TiempoEspera = TiempoOriginal;
		}
	}
}
