using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour 
{
	float TiempoEspera;

	// Use this for initialization
	void Start () 
	{
		TiempoEspera = 5.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		TiempoEspera -= Time.deltaTime;
		
		if(TiempoEspera <= 0.0f)
		{
			gameObject.SetActive(false);
		}
	}
}
