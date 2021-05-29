using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Linterna : MonoBehaviour
{
    public Material bengalaMaterial;
    public Material bengalaMaterialEncendida;
    Material bengala;

    public GameObject Luz;

    public enum BengalaStates {encendida,apagada }

    public BengalaStates bengalaStates;

    public enum BengalaHoverStates{hover, nothover}
    public BengalaHoverStates bengalaHoverStates;

    InputDevice targetDevice;

    public AudioClip[] audioClips;
    [Range(0,1)]

    AudioSource audioSource;


    private void Start()
    {
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
        bengalaStates = BengalaStates.encendida;
        Luz.SetActive(true);

        bengalaHoverStates = BengalaHoverStates.nothover;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[0];
    }

    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryBottonValue);

        if (primaryBottonValue && bengalaHoverStates == BengalaHoverStates.hover)
        {
            if (bengalaStates == BengalaStates.apagada)
            {
                bengala.CopyPropertiesFromMaterial(bengalaMaterialEncendida);
                bengalaStates = BengalaStates.encendida;
                Luz.SetActive(true);
                
                audioSource.Play();
            }
            else if (bengalaStates == BengalaStates.encendida)
            {
                bengala.CopyPropertiesFromMaterial(bengalaMaterial);
                bengalaStates = BengalaStates.apagada;
                Luz.SetActive(false);
                audioSource.Play();
            }
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
}
