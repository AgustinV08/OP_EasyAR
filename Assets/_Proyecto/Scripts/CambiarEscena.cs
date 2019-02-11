using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Experiencia de usuario
        // Al apretar el buton de atras la aplicacion se cierra
        // Si esta parte del codigo, la aplicacion se queda ahi aunque se apriete el boton para salir
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ChangeScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
