using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ControlBotonesInicio : MonoBehaviour
{
    public Canvas canvasInicio;
    public float crono = 20f;
    CanvasGroup canvasFade;

    float startFade = 0.1f;
    float endFade = 1f;
    float FadeTime = 1f;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        canvasInicio.enabled = false;
        canvasFade = canvasInicio.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        crono -= Time.deltaTime;
        if (crono <= 0)
        {
            //print("funciona");
            canvasInicio.enabled = true;
            canvasFade.alpha += startFade * Time.deltaTime;
        }
             

       
    }

    public void iniciar(string Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void controles()
    {
        
    }
    public void salir()
    {
        Application.Quit();
    }

    //Para cargar el juego en PC
    public void PC(string Juego_PC)
    {
        SceneManager.LoadScene(Juego_PC);
    }

    //Para cargar el juego en Realidad Virtual
    public void VR(string Juego_VR)
    {
        SceneManager.LoadScene(Juego_VR);
    }

    public void VolumenAudio(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Master",volume);
    }
}
