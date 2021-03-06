using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ColliderAttack : MonoBehaviour
{
    public Animator anim;
    public GameObject ia;
    Seguimiento_IA iaStates;

    public AudioClip[] audioClips;
    [Range(0,1)]

    AudioSource audioSource;

    private void Start()
    {
        anim = ia.GetComponent<Animator>();
        iaStates = GetComponent<Seguimiento_IA>();
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(iaStates.iaStates == Seguimiento_IA.IAStates.fijo)
            {
                anim.SetTrigger("Attack");
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
       }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(iaStates.iaStates == Seguimiento_IA.IAStates.otro)
            {
                anim.SetTrigger("Defend");
                audioSource.clip = audioClips[1];
                audioSource.Play();
            }

            else if(iaStates.iaStates == Seguimiento_IA.IAStates.fijo)
            {
                anim.SetTrigger("Defend");
                audioSource.clip = audioClips[1];
                audioSource.Play();
            }
        
        }

    }

}

