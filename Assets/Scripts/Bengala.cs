using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bengala : MonoBehaviour
{
    public GameObject bengalaGameObject;
    public Material bengalaMaterial;
    public Material bengalaMaterialEncendida;
    Material bengala;

    public GameObject Luz;

    public enum BengalaStates {encendiendose,apagada, apagandose, rota, trance }

    public BengalaStates bengalaStates;

    public enum BengalaHoverStates{hover, nothover}
    public BengalaHoverStates bengalaHoverStates;

    InputDevice targetDevice;


    public float contadorEncendiendose = 0.65f;
    public float contadorApagandose = 5f;
    public Light light;
    public float rangoDeBengalaDeseado;
    public float intensidadDeBengalaDeseado;
    Animator animator;

    
    private void Start()
    {

        light = Luz.GetComponent<Light>();
        light.range = 0;
        light.intensity = 0;
        animator = GetComponent<Animator>();

        bengalaGameObject = GetComponent<GameObject>();

        //Inicializacion para los controles de los mandos VR
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);


        foreach(var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }


        if(devices.Count > 0)
        {
                targetDevice = devices[0];
        }

        bengala = GetComponent<Renderer>().material;
        bengalaStates = BengalaStates.apagada;
        Luz.SetActive(false);

        bengalaHoverStates = BengalaHoverStates.nothover;
    }

    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton);

        if (primaryButton && bengalaHoverStates == BengalaHoverStates.hover && bengalaStates == BengalaStates.apagada)
        {
            bengalaStates = BengalaStates.trance;
        }

        if (bengalaStates == BengalaStates.trance)
        {
            Luz.SetActive(true);
            bengala.CopyPropertiesFromMaterial(bengalaMaterialEncendida);
            bengalaStates = BengalaStates.encendiendose;
        }


        if(bengalaStates == BengalaStates.encendiendose)
        {
            animator.SetTrigger("In");
        }

        if(bengalaStates == BengalaStates.apagandose)
        {
            animator.SetTrigger("Fin");
        }

        if(bengalaStates == BengalaStates.rota)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void OnHoverEnter()
    {
        bengalaHoverStates = BengalaHoverStates.hover;
    }

    public void OnHoverExit()
    {
        bengalaHoverStates = BengalaHoverStates.nothover; 
    }

    public void CambioToApagandose()
    {
        bengalaStates = BengalaStates.apagandose;
    }

    public void CambioToRota()
    {
        bengalaStates = BengalaStates.rota;
    }
    

}
