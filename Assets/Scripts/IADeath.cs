using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IADeath : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Seguimiento_IA ia = other.GetComponent<Seguimiento_IA>();
        if(ia != null)
        {
            if(ia.iaStates == Seguimiento_IA.IAStates.fijo)
            {
                //Si es el jugador mientras que le persigue
                if(other.gameObject.tag == "Player")
                {
                    //SceneManager.LoadScene(); //PANTALLA DE MUERTE
                }
            }
            else if (ia.iaStates == Seguimiento_IA.IAStates.otro)
            {
                //Nada
            }
        }
    }
}
