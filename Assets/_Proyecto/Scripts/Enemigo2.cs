using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour 
{
	// Variable que controlara las animaciones del objeto
	Animator anim;
	
	// Velocidad del objeto
	public Vector3 Velocidad;
	
	// Variable que guardara la posicion inicial del objeto y se usara como parametro para evitar que se salga de rango
	// al moverse
	Vector3 PosicionInicial;
	
	// Use this for initialization
	void Start () 
	{
		// Encontramos el animator para poder controlar las animaciones
		anim = gameObject.GetComponent<Animator>();
		
		// Guardamos la posicion cuando empieza el juego para utilizarla como parametro en la funcion de Movimiento
		PosicionInicial = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Funcion para el movimiento del enemigo
		Moverse();
		
		// Si va hacia la derecha
		if(Velocidad.x > 0)
		{
			// Detenemos esta animacion
			anim.SetBool("GoLeft", false);
			
			// Ejecutamos la funcion correcta
			anim.SetBool("GoRight", true);
		}
		// Si va hacia la izquierda
		else if(Velocidad.x < 0)
		{
			// Detenemos esta animacion
			anim.SetBool("GoRight", false);
			
			// Ejecutamos la animacion correcta
			anim.SetBool("GoLeft", true);
		}
	}
	
	void Moverse()
	{
		// Nos aseguramos que no se salga de la pantalla y vamos cambiando su velocidad
		if(transform.position.y >= PosicionInicial.y + 5)
		{
			Velocidad.y = Velocidad.y * -1;
		}
		else if(transform.position.y <= PosicionInicial.y - 5)
		{
			Velocidad.y = Velocidad.y * -1;
		}
		
		if(transform.position.x >= PosicionInicial.x + 5)
		{
			Velocidad.x = Velocidad.x * -1;
		}
		else if(transform.position.x <= PosicionInicial.x - 5)
		{
			Velocidad.x = Velocidad.x * -1;
		}
		
		// Se mueve cierta velocidad cada 
		transform.Translate(Velocidad * Time.deltaTime);
	}
}
