using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seguimiento_IA: MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;
    public Transform[] puntoOrigen;
    public Bengala.BengalaStates bengalaStates;
    public float speed;

    public enum IAStates {fijo, otro}
    public IAStates iaStates;

    public Animator anim;

    [SerializeField]
    Transform otroPosition;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        iaStates = IAStates.fijo;
        otroPosition = target;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(iaStates == IAStates.fijo)
        {
            DestinoFijo();
            

            nav.speed = speed;
        }

        if(iaStates == IAStates.otro)
        {
            DestinoRandom();
            
            nav.speed = 100;
        }
        
    }
    void DestinoFijo()
    {
        nav.SetDestination(target.position);
    }

    void DestinoRandom()
    {
        nav.SetDestination(otroPosition.position);
    }


    private void OnTriggerStay(Collider other)
    {
        Bengala bengala = other.GetComponent<Bengala>();
        if(bengala != null)
        {
            if(bengala.bengalaStates == Bengala.BengalaStates.encendiendose || bengala.bengalaStates == Bengala.BengalaStates.apagandose && other.gameObject.tag == "Bengala" && iaStates == IAStates.fijo)
            {
                StartCoroutine(EscapeBengala());
            }
        }
    }


    IEnumerator EscapeBengala()
    {
        int origenGenerator = Random.Range(0, puntoOrigen.Length);
        otroPosition = puntoOrigen[origenGenerator];
        
        anim.SetTrigger("Defend");
        iaStates = IAStates.otro;


        yield return new WaitForSeconds(30);

        iaStates = IAStates.fijo;
        anim.SetTrigger("Pursuit");
    }
}
