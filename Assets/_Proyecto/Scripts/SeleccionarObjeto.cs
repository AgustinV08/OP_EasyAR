using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionarObjeto : MonoBehaviour
{
    // Layer del objeto
    public LayerMask mascara;

    //Variable para controlar la camara
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        // Igualamos la vabariable de la camara a la camara principal en escena
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
                // Camara 2D
                
                // Guadamos la posicion del touch
                /*Vector3 touchPos = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
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
                }*/

                //Camara 3D
                
                // Objeto con el cual el RayCast colisiono
                RaycastHit hit;

                // Posicion de donde hicimos el toque
                Vector3 touchPos = Input.GetTouch(0).position;
                touchPos.z = 0;
                
                // Rayo que se genera donde tocamos la pantalla
                Ray rayo = cam.ScreenPointToRay(touchPos);

                // Si se colisiona con un objeto con el layer dado
                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    // Cambiamos la posicion del objeto tocado a donde tocamos la pantalla
                    touchPos = hit.point;
                    touchPos.z = 0;
                    hit.transform.position = touchPos;
                }
        }
    }
}
