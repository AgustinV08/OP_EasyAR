using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour 
{
	// Variable para controlar las animaciones
	Animator anim;
	
	// Variable para saber si la funcion esta reproduciendose o no
	bool Stopped;

	// Use this for initialization
	void Start () 
	{
		// Conseguimos el animator del objeto para controlar las animaciones
		anim = gameObject.GetComponent<Animator>();
		
		// Iniciamos la funcion
		StartCoroutine("CambiarAnimacion");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			// Si no hay ninguna animacion reproduciendose
			if(Stopped == true)
			{
				// Le indicamos que ya hay una animacion reproduciendose
				Stopped = false;
				
				// Ejecutamos la funcion
				StartCoroutine("CambiarAnimacion");
			}
			// Si si hay una animacion reproduciendose
			else if(Stopped == false)
			{
				// Le indicamos que la detenga
				Stopped = true;
				
				// Detenemos la funcion de las animaciones
				StopCoroutine("CambiarAnimacion");
			}
		}
	}
	
	// Funcion para ir cambiando de animacion a animacion
	IEnumerator CambiarAnimacion()
	{
		// Le decimos que espere un tiempo para reproducirlo
		yield return new WaitForSeconds(2.0f);

		// Reproducimos la animacion
		anim.SetBool("MoverBrazos", !anim.GetBool("MoverBrazos"));
		
		// Volvemos a ejecutar la funcion
		StartCoroutine("CambiarAnimacion");
	}
}
