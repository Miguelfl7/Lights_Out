using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSensor : MonoBehaviour
{
    public LockEvent enter;
    //public LockEvent exit;
    private void OnTriggerEnter(Collider other)
    {
        print("Entra");
        enter.Invoke(other);
    }
    /*private void OnTriggerExit(Collider other)
    {
        print("Sale");
        exit.Invoke(other);
    }*/

    [System.Serializable]
    public class LockEvent : UnityEvent<Collider>
    {

    }
}
