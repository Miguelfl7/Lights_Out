using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeLuces : MonoBehaviour
{
    public Light luzHijo;
    MeshRenderer meshRenderer;
    public Material emmisiveOff;
    public Material emmisiveOn;
    public AudioClip[] audioClips;
    [Range(0,1)]
    public float volume;
    AudioSource audioSource;

    //public GameObject luz;
    private void Start()
    {

        audioSource = GetComponent<AudioSource>();

        //luz = gameObject.transform.GetChild(1).gameObject;
        luzHijo = GetComponentInChildren<Light>();
        //luzHijo.enabled = true;

        //luzHijo = luz.GetComponent<Light>();

        meshRenderer = GetComponent<MeshRenderer>();
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "IA")
        {
            //Debug.Log("Collision");
            luzHijo.enabled = false;
            meshRenderer.material = emmisiveOff;

            //Audio
            audioSource.clip = audioClips[0];
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "IA")
        {
            //Debug.Log("Collision");
            luzHijo.enabled = false;
            meshRenderer.material = emmisiveOff;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "IA")
        {
            //Debug.Log("Collision OUT");
            luzHijo.enabled = true;
            meshRenderer.material = emmisiveOn;

            //Audio
            audioSource.clip = audioClips[0];
            audioSource.volume = volume;
            audioSource.Stop();
        }
    }
}