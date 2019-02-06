using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouch : MonoBehaviour
{
    public GameObject Bala;

    public Camera cam;

    public LayerMask mascara;

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

                // Camara 2D

                /*Vector3 Posicion = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                Posicion.z = 0f;
                GameObject go = Instantiate(Bala, Posicion, Quaternion.identity);*/

                // Camara 3D

                RaycastHit hit;

                Vector3 touchPos = Input.GetTouch(0).position;

                Vector3 Posicion;
                //Vector3 Posicion = touchPos;

                Ray rayo = cam.ScreenPointToRay(touchPos);

                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    Posicion = hit.transform.position + rayo.direction * 5;
                    Posicion.z = 0;

                    //Debug.Log("Posicion: " + Posicion);
                    //Debug.Log("rayo: " + rayo);
                    //Debug.Log("hit: " + hit.transform.position);

                    Instantiate(Bala, Posicion, Quaternion.identity);
                }
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

                /*Vector3 Posicion = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Posicion.z = 0f;
                GameObject go = Instantiate(Bala, Posicion, Quaternion.identity);
                go.GetComponent<Rigidbody>().AddForce(1000 * transform.forward);*/
            }

            // El input termino
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Debug.Log("Input Ended");
            }
        }
    }
}
