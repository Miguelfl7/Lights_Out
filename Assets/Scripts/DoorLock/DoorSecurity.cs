using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSecurity : MonoBehaviour
{
    Animator doorAnimator;

    /// <summary>
    /// Seguridad de la puerta
    /// </summary>
    public SecurityManager.SecurityLock doorSecurity;

    public Text uiTextInScreen;
    public GameObject canvas;
    Rigidbody rb;


    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        canvas.SetActive(false);
    }
    public void Open(Collider other)
    {
        StartCoroutine(CanvasActivator(other));
    }

    IEnumerator CanvasActivator(Collider other)
    {
        PlayerKeySecurity playerSecurity = other.GetComponent<PlayerKeySecurity>();
        GameObject key = other.GetComponent<PlayerKeySecurity>().gameObject;
        if (playerSecurity != null)
        {
            canvas.SetActive(true);
            if (playerSecurity.playerSecurityLevel == doorSecurity)
            {
                //doorAnimator.SetTrigger("Go");
                uiTextInScreen.text = ("Has abierto la puerta");
                rb.isKinematic = false;
                key.SetActive(false);
                

            }
            else if (playerSecurity.playerSecurityLevel != doorSecurity)
            {
                uiTextInScreen.text = ("La llave no es de esta puerta");
            }
        }
        yield return new WaitForSeconds(5);
        canvas.SetActive(false);
    }
}
