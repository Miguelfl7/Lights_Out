using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeySecurity : MonoBehaviour
{
    [SerializeField]
    public SecurityManager.SecurityLock playerSecurityLevel;

    public AudioClip[] audioClips;
    [Range(0,1)]

    AudioSource audioSource;
private void Start()
{
    audioSource = GetComponent<AudioSource>();
}
    public void CogerLlave()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void DejarCaer()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }
}
