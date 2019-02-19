using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesObjetos : MonoBehaviour
{
    // Encargado de las animaciones del objeto
    public Animator anim;
    
    // Camera de donde se lanzara el Raycast
    public Camera cam;
    
    // Mascata del objeto
    public LayerMask mascara;
    
    // Start is called before the first frame update
    void Start()
    {
        // Igualamos la variable a la camara principal en escena
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // Al pulsar la pantalla
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Objeto con el cual el Raycast colisionara
                RaycastHit hit;

                // Posicion del toque en la pantalla
                Vector3 touchPos = Input.GetTouch(0).position;

                // Linea invisible que se lanzara en la posicion donde tocamos la pantalla
                Ray rayo = cam.ScreenPointToRay(touchPos);

                // Si el rayo colisiona con el objeto con el layer indicado
                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    // Reproducimos la animacion del objeto
                    anim.SetTrigger("ReproducirAnimacion");
                }
            }
        }
    }
}
