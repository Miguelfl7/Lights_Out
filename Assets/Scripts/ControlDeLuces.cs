using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeLuces : MonoBehaviour
{
    Light luz;

    private void Start()
    {
        luz = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "IA")
        {
            //Debug.Log("Collision");
            luz.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "IA")
        {
            //Debug.Log("Collision OUT");
            luz.enabled = true;
        }
    }
}