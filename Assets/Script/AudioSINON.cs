using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSINON : MonoBehaviour
{
    public GameObject target;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _audioSource.pitch = 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _audioSource.pitch = 1;
    }
}

