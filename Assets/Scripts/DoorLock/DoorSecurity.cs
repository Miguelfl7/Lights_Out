using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSecurity : MonoBehaviour
{
    Animator doorAnimator;

    /// <summary>
    /// Seguridad de la puerta
    /// </summary>
    public SecurityManager.SecurityLock doorSecurity;

    public enum DoorState { open, close};
    public DoorState doorState;


    private void Start()
    {
        doorAnimator = GetComponent<Animator>();

        if (doorState == DoorState.open)
        {
            doorAnimator.SetTrigger("Open");
        }
        else
        {
            doorAnimator.SetTrigger("Close");
        }
    }
    public void Open(Collider other)
    {
        PlayerKeySecurity playerSecurity = other.GetComponent<PlayerKeySecurity>();
        if (playerSecurity != null)
        {
            if (playerSecurity.playerSecurityLevel == doorSecurity)
            {
                doorAnimator.SetTrigger("Go");
            }
        }
    }

    public void Close(Collider other)
    {
        PlayerKeySecurity playerSecurity = other.GetComponent<PlayerKeySecurity>();
        if (playerSecurity != null)
        {
            if (playerSecurity.playerSecurityLevel == doorSecurity)
            {
                doorAnimator.SetTrigger("Go");
            }
        }
    }
}
