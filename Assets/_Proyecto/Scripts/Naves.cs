using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naves : MonoBehaviour 
{
	// Objeto que la nave disparara
	public GameObject Bala;
	
	// La velocidad en la que se movera
	public Vector3 Velocidad;
	
	// Guardaremos su posicion inicial por cosas del movimiento
	Vector3 PosicionInicial;

	// Use this for initialization
	void Start () 
	{
		// Guardamos la posicion al iniciar el juego
		PosicionInicial = transform.position;
		
		// Corotina que hara que la nave dispare despues de un tiempo automaticamente
		StartCoroutine("LoopDisparo");
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Funcion para el movimiento de la nave
		Moverse();
		
		// Cuando apriete la tecla dispara
		/*if(Input.GetKeyDown(KeyCode.Space))
		{
			Disparo();
		}*/
	}
	
	void Disparo()
	{
		// Generamos el objeto bala
		GameObject go = Instantiate(Bala, new Vector3(transform.position.x + 8, transform.position.y, transform.position.z), Quaternion.identity);
		
		// Le damos una fuerza para que se mueva
		go.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
	}
	
	void Moverse()
	{
		// Nos aseguramos que no se salga de la pantalla y vamos cambiando su velocidad
		if(transform.position.y >= PosicionInicial.y + 15)
		{
			Velocidad = Velocidad * -1;
		}
		else if(transform.position.y <= PosicionInicial.y - 15)
		{
			Velocidad = Velocidad * -1;
		}
		
		// Se mueve cierta velocidad cada 
		transform.Translate(Velocidad * Time.deltaTime);
	}
	
	IEnumerator LoopDisparo()
	{
		yield return new WaitForSeconds(2.0f);
		
		// Generamos el objeto bala
		GameObject go = Instantiate(Bala, new Vector3(transform.position.x + 8, transform.position.y, transform.position.z), Quaternion.identity);
		
		// Le damos una fuerza para que se mueva
		go.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
		
		StartCoroutine("LoopDisparo");
	}
}
