using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IADeath : MonoBehaviour
{
    public string scene;
    public Seguimiento_IA ia;
    private void OnTriggerEnter(Collider other)
    {
        ia = other.GetComponent<Seguimiento_IA>();
        if(ia != null)
        {
            if(ia.iaStates == Seguimiento_IA.IAStates.fijo)
            {
                SceneManager.LoadScene(scene);
            }
        }
        else
        {
            //Nada
        }
        
    }
}
