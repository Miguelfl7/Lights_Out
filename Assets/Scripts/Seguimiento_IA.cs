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

    [SerializeField]
    Transform otroPosition;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        iaStates = IAStates.fijo;
        otroPosition = target;

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
            Debug.Log("Hace colision con la bengala");
            if(bengala.bengalaStates == Bengala.BengalaStates.encendiendose || bengala.bengalaStates == Bengala.BengalaStates.apagandose && other.gameObject.tag == "Bengala" && iaStates == IAStates.fijo)
            {
                StartCoroutine(EscapeBengala());
            }
        }
    }


    IEnumerator EscapeBengala()
    {

        Debug.Log("esta en la corrutina");

        int origenGenerator = Random.Range(0, puntoOrigen.Length);
        otroPosition = puntoOrigen[origenGenerator];


        iaStates = IAStates.otro;


        yield return new WaitForSeconds(30);

        iaStates = IAStates.fijo;
    }
}
