using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSensor : MonoBehaviour
{
    public LockEvent enter;
    public LockEvent exit;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Key")
        {
            print("Entra");
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
