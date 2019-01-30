using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouch : MonoBehaviour
{
    public Camera cam;

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
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("Input Start");
            }

            // El input se esta moviendo por la pantalla
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Debug.Log("Input Moving");
            }

            // El input se quedo tocando la pantalla sin moverse
            if(Input.GetTouch(0).phase == TouchPhase.Stationary)
            {

            }

            // El input termino
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log("Input Ended");
            }
        }
    }
}
