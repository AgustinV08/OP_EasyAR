using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mentor : MonoBehaviour 
{
	Animator anim;
	
	// Tiempo que la nave dispara
	public float FireRate;
	
	// La velocidad en la que se movera
	public Vector3 Velocidad;
	
	// Guardaremos su posicion inicial por cosas del movimiento
	Vector3 PosicionInicial;
	
	bool EnAnimacion; 
	
	// Pool de la bala
	List<GameObject> Bala = new List<GameObject>();
	
	GameObject Generar_Bala()
	{
		for (int i = 0; i < Bala.Count; i++)
		{
			if(Bala[i].activeSelf == false)
			{
				Bala[i].SetActive(true);
				Bala[i].transform.position = transform.position;
				Bala[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				return Bala[i];
			}
		}
		
		GameObject Prefab_Bala = Resources.Load<GameObject>("Sphere");
		GameObject go = Instantiate(Prefab_Bala, transform.position, Quaternion.identity);
		Bala.Add(go);
		return go;
	}

	// Use this for initialization
	void Start () 
	{
		// Guardamos la posicion al iniciar el juego
		PosicionInicial = transform.position;
		
		// Conseguimos el animator al iniciar el juego
		anim = gameObject.GetComponent<Animator>();
		
		anim.SetTrigger("AbrirAlas");
		
		StartCoroutine("Saludar");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(EnAnimacion == false)
		{
			// Funcion para el movimiento de la nave
			Moverse();
		}
		else
		{
			anim.SetBool("Movimiento", false);
		}
	}
	
	IEnumerator Saludar()
	{
		EnAnimacion = true;
		
		yield return new WaitForSeconds(2.0f);
		
		anim.SetTrigger("Saludar");
		
		yield return new WaitForSeconds(1.0f);
		
		EnAnimacion = false;
	}
	
	void Disparo()
	{
		// Generamos el objeto bala
		GameObject go = Generar_Bala();
		
		// Le damos una fuerza para que se mueva
		go.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
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
		
		if(transform.position.x >= PosicionInicial.x + 10)
		{
			Velocidad.x = Velocidad.x * -1;
		}
		else if(transform.position.x <= PosicionInicial.x - 10)
		{
			Velocidad.x = Velocidad.x * -1;
		}
		
		// Se mueve cierta velocidad cada segundo
		transform.Translate(Velocidad * Time.deltaTime);
		
		// Rota 
		transform.Rotate(Vector3.down); 
		
		// Iniciamos la animcacion
		anim.SetBool("Movimiento", true);
	}

	// Corotinqa que se repetira despues de un tiempo
	IEnumerator LoopDisparo()
	{
		// Espera un tiempo para ejecuutarse
		yield return new WaitForSeconds(FireRate);
		
		// Generamos el objeto bala
		GameObject go = Generar_Bala();
		
		// Le damos una fuerza para que se mueva
		go.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
		
		// Iniciamos otra vez la corotina
		StartCoroutine("LoopDisparo");
		
	}
}
