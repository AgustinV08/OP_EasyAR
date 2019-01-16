using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naves : MonoBehaviour 
{
	// Tiempo que la nave dispara
	public float FireRate;
	
	// La velocidad en la que se movera
	public Vector3 Velocidad;
	
	// Guardaremos su posicion inicial por cosas del movimiento
	Vector3 PosicionInicial;
	
	// Pool de la bala
	List<GameObject> Bala = new List<GameObject>();
	
	GameObject Generar_Bala()
	{
		for (int i = 0; i < Bala.Count; i++)
		{
			if(Bala[i].activeSelf == false)
			{
				Bala[i].SetActive(true);
				Bala[i].transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
				Bala[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				return Bala[i];
			}
		}
		
		GameObject Prefab_Bala = Resources.Load<GameObject>("Bala");
		GameObject go = Instantiate(Prefab_Bala, new Vector3(transform.position.x + 10, transform.position.y, transform.position.z), Quaternion.identity);
		Bala.Add(go);
		return go;
	}

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
		GameObject go = Generar_Bala();
		
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
