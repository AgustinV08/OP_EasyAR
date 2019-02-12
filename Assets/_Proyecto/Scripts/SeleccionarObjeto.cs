using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionarObjeto : MonoBehaviour
{
    public LayerMask mascara;

    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
                // Camara 2D
                
                // Guadamos la posicion del touch
                Vector3 touchPos = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                touchPos.z = 0;
                
                // Variable que guarda la informacion del objeto que seleccionaremos
                RaycastHit hit;
                
                // Rayo que se generara cuando toquemos la pantalla
                Ray rayo = cam.ScreenPointToRay(Input.GetTouch(0).position);

                // Si el rayo colisiona con uno de los objetos con la mascara indicada
                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    // Su posicion sera igual a la posicion de donde tocamos la pantalla
                    hit.transform.position = touchPos;
                }

                //Camara 3D
                /*RaycastHit hit;

                Vector3 touchPos = Input.GetTouch(0).position;
                touchPos.z = 0;
                
                Ray rayo = cam.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    hit.transform.position = touchPos;
                }*/
        }
    }
}
