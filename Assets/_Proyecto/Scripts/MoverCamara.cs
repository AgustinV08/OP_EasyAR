using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    public float MovSpeed;
    public float RotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Aqui se empezara a mover la camara

                // Guardamos la posicion del toque en una variable
                Vector2 TouchPos = Input.GetTouch(0).deltaPosition;

                // Movemos la posicion de la camara en base a esa posicion
                transform.Translate(-TouchPos.x * MovSpeed, -TouchPos.y * MovSpeed, 0);

                // Evitamos que la camara se salga de un rango
                /*transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -35.0f, 25.0f),
                    Mathf.Clamp(transform.position.y, 1.0f, 20.0f),
                    Mathf.Clamp(transform.position.z, -9.0f, 15.0f));*/
            }
        }

        if (Input.touchCount > 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                if (Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    // Aqui se rotara la camara

                    // Guardamos la posicion de donde se toco la pantalla
                    Vector2 TouchRot = Input.GetTouch(1).deltaPosition;

                    // Movemos en base a donde se mueve el toque de la pantalla
                    transform.Rotate(TouchRot.y * RotationSpeed, -TouchRot.x * RotationSpeed, 0);
                }
            }
        }
    }
}
