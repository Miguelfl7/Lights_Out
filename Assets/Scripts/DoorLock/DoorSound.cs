using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioClip[] audioClips;
    [Range(0, 1)]
    AudioSource audioSource;

    public GameObject rigid;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = rigid.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mano")
        {
            Debug.Log("MANOOOOOO");
            if(rb.isKinematic == false)
            {
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
        }
    }
}
