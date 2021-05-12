using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotonesInicio1 : MonoBehaviour
{
    public Canvas canvasInicio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void iniciar(string Levels)
    {
        SceneManager.LoadScene(Levels);
    }

    public void controles()
    {
        
    }
    public void salir()
    {
        Application.Quit();
    }
}
