using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControlVideo : MonoBehaviour
{

    public float crono = 85f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        crono -= Time.deltaTime;
        if (crono <= 0)
        {
            SceneManager.LoadScene("MenuInicio");
        }
    }

}
