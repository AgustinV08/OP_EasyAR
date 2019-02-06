using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputForce : MonoBehaviour
{
    // Camara en escena
    public Camera cam;

    // Layer que recibira la colision del Raycast
    public LayerMask mascara;

    // Start is called before the first frame update
    void Start()
    {
        // Lo igualamos a la camara que ya tenemos en escena
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // El Input acaba de empezar
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Debug.Log("Input Start");

                // Generamos una variable para saber cuando el Raycast ya colisiono con un objeto
                RaycastHit hit;

                // Posicion del toque en la pantalla
                Vector3 touchPos = Input.GetTouch(0).position;

                // Generamos el raycast en la posicion donde tocamos la pantalla
                Ray rayo = cam.ScreenPointToRay(touchPos);

                // Si el Raycast colisiono con el layer indicado
                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    // Al objeto lo empujamos en la direccion donde lo tocamos
                    hit.rigidbody.AddForce(1000 * rayo.direction);
                }
            }

            // El input se esta moviendo por la pantalla
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //Debug.Log("Input Moving");
            }

            // El input se quedo tocando la pantalla sin moverse
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                //Debug.Log("Input Stationary");
            }

            // El input termino
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Debug.Log("Input Ended");
            }
        }
    }
}
