using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seguimiento_IA: MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        DestinoRandom();
    }
    void DestinoRandom()
    {
        nav.SetDestination(target.position);
    }
}
