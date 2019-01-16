using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
	
	// Variable para controlar las animaciones
	Animator anim;
	
	Vector3 Velocidad;
	
	public float FireRate;
	
	float Tiempo;
	
	bool Caminando;
	
	public Vector3 Direccion;
	
	public float EsperaCombate;
	
	// Pool de la bala
	List<GameObject> Bala = new List<GameObject>();
	
	// Funcion para generar la bala que el enemigo disparara
	GameObject Generar_Bala()
	{
		// Por cada bala que hay en la lista
		for (int i = 0; i < Bala.Count; i++)
		{
			// Checamos si la bala i NO esta activa en escena
			if(Bala[i].activeSelf == false)
			{
				// La activamos
				Bala[i].SetActive(true);
				
				// Reiniciamos su posicion a la del enemigo
				Bala[i].transform.position = transform.position;
				
				// Reiniciamos su velocidad para que no se mueva por accidente al volverla a activar
				Bala[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				
				return Bala[i];
			}
		}
		
		// Si no hay ninguna Bala no activa en escena, cargamos el prefab
		GameObject Prefab_Bala = Resources.Load<GameObject>("Sphere");
		
		// Creamos el prefab en escena
		GameObject go = Instantiate(Prefab_Bala, transform.position, Quaternion.identity);
		
		// Lo añadimos a la lista poder manipularlo despues
		Bala.Add(go);
		
		return go;
	}

	// Use this for initialization
	void Start () 
	{
		Caminando = false;
		
		// Conseguimos el animator del enemigo para controlarlo 
		anim = gameObject.GetComponent<Animator>();
		
		Tiempo = FireRate;
		
		StartCoroutine(EnCombate(EsperaCombate));
		
		StartCoroutine(Rotacion(EsperaCombate*2));
		
		Direccion = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(anim.GetBool("Combat") == false)
		{
			// Cuando este en ese porcentaje de la animacion
			if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.35 && 
				anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.30)
			{
				
				// Le cambio la animacion para que camine
				anim.SetBool("IsWalking", true);
			}
		}
		
		/*if(Input.GetKeyDown(KeyCode.Space))
		{
			// Le decimos que ya no camine al GameObject
			// Detenemos la animacion de caminar
			anim.SetBool("IsWalking", false);
			
			
			// Reproducimos la animacion
			anim.SetBool("Combat", !anim.GetBool("Combat"));
			
			FireRate = Tiempo;
		}*/
		
		// Si su animacion es de caminar...
		if(anim.GetBool("IsWalking") == true)
		{
			// El GameObject se mueve
			transform.Translate(Direccion * Time.deltaTime);
		}
		
		// Si el enemigo esta en combate...
		if(anim.GetBool("Combat") == true)
		{	
			FireRate -= Time.deltaTime;
			
			if(FireRate<= 0.0f)
			{
				Disparar();
				
				FireRate = Tiempo;
			}
		}
	}
	
	void Disparar()
	{
		// Generamos la bala con la funcion del pool
		GameObject go = Generar_Bala();
		
		// Le damos una fuerza a la bala al crearse, sino se queda estatica
		go.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
		
	}
	
	IEnumerator EnCombate(float time)
	{
		yield return new WaitForSeconds(time);
		
		// Le decimos que ya no camine al GameObject
		// Detenemos la animacion de caminar
		anim.SetBool("IsWalking", false);
		
		// Reproducimos la animacion
		anim.SetBool("Combat", !anim.GetBool("Combat"));
			
		FireRate = Tiempo;
		
		StartCoroutine(EnCombate(EsperaCombate));
	}
	
	IEnumerator Rotacion(float time)
	{
		yield return new WaitForSeconds(time);
		
		transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z), Space.Self);
		
		StartCoroutine("Rotacion");
	}
}
