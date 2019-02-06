using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputForce : MonoBehaviour
{
    public Camera cam;

    public LayerMask mascara;

    // Start is called before the first frame update
    void Start()
    {

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

                RaycastHit hit;

                Vector3 touchPos = Input.GetTouch(0).position;

                Vector3 Posicion;

                Ray rayo = cam.ScreenPointToRay(touchPos);

                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    Posicion = hit.transform.position + rayo.direction * 5;
                    Posicion.z = 0;
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
