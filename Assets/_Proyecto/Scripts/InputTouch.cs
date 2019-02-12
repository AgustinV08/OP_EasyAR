using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputTouch : MonoBehaviour
{
    // Objeto que se creara al tocar la pantalla
    public GameObject Bala;

    // La camara en escena
    public Camera cam;

    // Plano que ocupa toda la pantalla, para detectar los toques en 3D
    public LayerMask mascara;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
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
                
                // Igualamos la posicion del objeto a la posicion de donde tocamos la pantalla
                /*Vector3 Posicion = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                Posicion.z = 0f;
                
                // Creamos el objeto
                GameObject go = Instantiate(Bala, Posicion, Quaternion.identity);*/

                // Camara 3D

                // Objeto con el cual el Raycast colisionara
                RaycastHit hit;

                // Posicion del toque en la pantalla
                Vector3 touchPos = Input.GetTouch(0).position;

                // Posicion donde se creara el objeto
                Vector3 Posicion;

                // Linea invisible que se lanzara en la posicion donde tocamos la pantalla
                Ray rayo = cam.ScreenPointToRay(touchPos);

                // Si el rayo colisiona con el objeto con el layer indicado
                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    // La posicion del objeto sera la posicion del objeto con el layer
                    Posicion = hit.point;
                    Posicion.z = 0;

                    // Creamos el objeto
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

                // Igualamos la posicion del objeto a la posicion de donde tocamos la pantalla
                /*Vector3 Posicion = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Posicion.z = 0f;

                // Generamos el objeto
                GameObject go = Instantiate(Bala, Posicion, Quaternion.identity);

                // Le damos una fuerza al objeto
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
