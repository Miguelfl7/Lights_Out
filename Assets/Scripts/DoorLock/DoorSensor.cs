using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSensor : MonoBehaviour
{
    public LockEvent enter;
    public LockEvent exit;

    
    public AudioClip[] audioClips;
    [Range(0,1)]
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Key")
        {
            print("Entra");
            //audioSource.clip = audioClips[0];
            //audioSource.Play();
            enter.Invoke(other);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Key")
        {
            print("Sale");
            exit.Invoke(other);
        }

    }

    [System.Serializable]
    public class LockEvent : UnityEvent<Collider>
    {

    }
}
