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
    public AudioClip[] audioClips;
    [Range(0,1)]
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                
                audioSource.clip = audioClips[0];
                audioSource.Play();
                key.SetActive(false);

                yield return new WaitForSeconds(1);

                audioSource.clip = audioClips[2];
                audioSource.Play();
            }
            else if (playerSecurity.playerSecurityLevel != doorSecurity)
            {
                uiTextInScreen.text = ("La llave no es de esta puerta");
                audioSource.clip = audioClips[1];
                audioSource.Play();
            }
        }
        yield return new WaitForSeconds(5);
        canvas.SetActive(false);
    }
}
