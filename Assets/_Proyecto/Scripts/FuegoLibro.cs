using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoLibro : MonoBehaviour
{
    // Camera de donde se lanzara el Raycast
    public Camera cam;
    
    // Mascata del objeto
    public LayerMask mascara;
    
    // Lista para las particulas
    public List<ParticleSystem> Fuego = new List<ParticleSystem>();

    // Contador para saber en que particula estamos
    private int Contador;
    
    // Start is called before the first frame update
    void Start()
    {   
        // Igualamos la variable a la camara en escena
        cam = Camera.main;

        // Igualamos el contador a la primera particula
        Contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
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
                    if (Contador <= Fuego.Count - 1)
                    {
                        // Reproducimos la particula
                        Fuego[Contador].Play();

                        // Nos vamos a la siguiente particula de la lista
                        Contador++;
                    }
                    else
                    {
                        // Cuando ya no hay particulas para reproducir
                        for (int i = 0; i < Fuego.Count; i++)
                        {
                            // Detenemos todas las particulas
                            Fuego[i].Stop();

                            // Reiniciamos el contador
                            Contador = 0;
                        }
                    }
                }
            }
        }
    }
}
