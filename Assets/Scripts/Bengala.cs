using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bengala : MonoBehaviour
{
    GameObject bengalaGameObject;
    public Material bengalaMaterial;
    public Material bengalaMaterialEncendida;
    Material bengala;

    public GameObject Luz;

    public enum BengalaStates {encendiendose,apagada, apagandose, rota }

    public BengalaStates bengalaStates;

    public enum BengalaHoverStates{hover, nothover}
    public BengalaHoverStates bengalaHoverStates;

    InputDevice targetDevice;


    public float contadorEncendiendose = 0.65f;
    public float contadorApagandose = 5f;
    Light light;
    public float rangoDeBengalaDeseado;
    public float intensidadDeBengalaDeseado;
    private void Start()
    {

        light = Luz.GetComponent<Light>();
        light.range = 0;

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
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButton);

        if (secondaryButton && bengalaHoverStates == BengalaHoverStates.hover && bengalaStates == BengalaStates.apagada)
        {
            //StartCoroutine(EncenderBengala());
            bengalaStates = BengalaStates.encendiendose;
        }
        if(bengalaStates == BengalaStates.encendiendose)
        {
            CounterEncendida();
        }

        if(bengalaStates == BengalaStates.apagandose)
        {
            CounterApagada();
        }

        if(bengalaStates == BengalaStates.rota)
        {
            //Luz.SetActive(false);
            bengalaGameObject.SetActive(false);
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

    /*IEnumerator EncenderBengala()
    {
        StartCoroutine(Contador());
        if (contadorEncendiendose <= 0)
        {
            bengala.CopyPropertiesFromMaterial(bengalaMaterialEncendida);
            bengalaStates = BengalaStates.encendiendose;
            Luz.SetActive(true);
        }
        else if (bengalaStates == BengalaStates.encendiendose)
        {
            bengala.CopyPropertiesFromMaterial(bengalaMaterial);
            bengalaStates = BengalaStates.apagada;
            Luz.SetActive(false);
        }
    }
    IEnumerator Contador()
    {
        contadorEncendiendose -= Time.deltaTime;
        yield return null;
    }*/
    void CounterEncendida()
    {

        bengala.CopyPropertiesFromMaterial(bengalaMaterialEncendida);
        Luz.SetActive(true);
        light.range += rangoDeBengalaDeseado / (contadorEncendiendose * Time.deltaTime);
        light.intensity += intensidadDeBengalaDeseado / (contadorEncendiendose * Time.deltaTime);

        if(light.range >= rangoDeBengalaDeseado)
        {
            light.range = rangoDeBengalaDeseado;
        }

        if (light.intensity >= intensidadDeBengalaDeseado)
        {
            light.intensity = intensidadDeBengalaDeseado;
        }

        if (light.range >= rangoDeBengalaDeseado && light.intensity >= intensidadDeBengalaDeseado)
        {
            bengalaStates = BengalaStates.apagandose;
        }
    }


    void CounterApagada()
    {

        bengala.CopyPropertiesFromMaterial(bengalaMaterialEncendida);
        Luz.SetActive(true);
        light.range -= rangoDeBengalaDeseado / (contadorApagandose * Time.deltaTime);
        light.intensity -= intensidadDeBengalaDeseado / (contadorApagandose * Time.deltaTime);

        if(light.range <= 0)
        {
            light.range = 0;
        }

        if (light.intensity <= 0)
        {
            light.intensity = 0;
        }

        if (light.range <= 0 && light.intensity <= 0)
        {
            bengalaStates = BengalaStates.rota;
        }
    }
}
