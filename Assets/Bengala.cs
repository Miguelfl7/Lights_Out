using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bengala : MonoBehaviour
{
    public Material bengalaMaterial;
    public Material bengalaMaterialEncendida;
    Material bengala;

    public GameObject Luz;

    public enum BengalaStates {encendida,apagada }
    public BengalaStates bengalaStates;

    private void Start()
    {
        bengala = GetComponent<Renderer>().material;
        bengalaStates = BengalaStates.apagada;
        Luz.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (bengalaStates == BengalaStates.apagada)
            {
                bengala.CopyPropertiesFromMaterial(bengalaMaterialEncendida);
                bengalaStates = BengalaStates.encendida;
                Luz.SetActive(true);
            }
            else if (bengalaStates == BengalaStates.encendida)
            {
                bengala.CopyPropertiesFromMaterial(bengalaMaterial);
                bengalaStates = BengalaStates.apagada;
                Luz.SetActive(false);
            }
        }
    }
}
