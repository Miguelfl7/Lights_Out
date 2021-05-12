using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LlaveTypeSecurity : MonoBehaviour
{
    public SecurityManager.SecurityLock llaveSecurityLevel;

    public GameObject canvasInteraction;

    private void Start()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        print("dentro");
        if (Input.GetKey(KeyCode.E))
        {
            PlayerKeySecurity player = other.GetComponent<PlayerKeySecurity>();
            player.playerSecurityLevel = llaveSecurityLevel;
            Destroy(this.gameObject);
            canvasInteraction.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        canvasInteraction.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        canvasInteraction.SetActive(false);
    }
}
