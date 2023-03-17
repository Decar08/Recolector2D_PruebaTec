using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidosScripts : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
