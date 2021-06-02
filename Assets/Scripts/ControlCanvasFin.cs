using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ControlCanvasFin : MonoBehaviour
{
    public string scene;
    public float crono = 3f;
    float startFade = 0.1f;
    float endFade = 1f;
    float FadeTime = 1f;
    
    void Update()
    {
        crono -= Time.deltaTime;
        if (crono <= 0)
        {
            SceneManager.LoadScene(scene);
        }

    }
}
