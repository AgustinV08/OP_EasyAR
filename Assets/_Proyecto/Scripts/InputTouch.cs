using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouch : MonoBehaviour
{
    public GameObject Bala;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            // El Input acaba de empezar
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Debug.Log("Input Start");

                Vector3 Posicion = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Posicion.z = 0f;
                GameObject go = Instantiate(Bala, Posicion, Quaternion.identity);
            }

                // El input se esta moviendo por la pantalla
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //Debug.Log("Input Moving");
            }

            // El input se quedo tocando la pantalla sin moverse
            if(Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                //Debug.Log("Input Stationary");

                Vector3 Posicion = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Posicion.z = 0f;
                GameObject go = Instantiate(Bala, Posicion, Quaternion.identity);
                go.GetComponent<Rigidbody>().AddForce(1000 * transform.forward);
            }

            // El input termino
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Debug.Log("Input Ended");
            }
        }
    }
}
