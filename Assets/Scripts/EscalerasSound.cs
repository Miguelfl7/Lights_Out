using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasSound : MonoBehaviour
{
    public AudioClip[] audioClips;
    [Range(0,1)]

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "IA")
        {
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "IA")
        {
            audioSource.Stop();
        }
    }
}
