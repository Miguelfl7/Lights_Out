using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ColliderAttack : MonoBehaviour
{
    public Animator anim;
    public GameObject ia;
    Seguimiento_IA iaStates;

    private void Start()
    {
        anim = ia.GetComponent<Animator>();
        iaStates = GetComponent<Seguimiento_IA>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(iaStates.iaStates == Seguimiento_IA.IAStates.fijo)
            {
                anim.SetTrigger("Attack");
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
            }

            else if(iaStates.iaStates == Seguimiento_IA.IAStates.fijo)
            {
                anim.SetTrigger("Defend");
            }
        
        }

    }

}

