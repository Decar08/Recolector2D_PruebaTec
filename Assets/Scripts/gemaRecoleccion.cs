using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemaRecoleccion : MonoBehaviour
{

    [SerializeField] private float cantPuntos;
    [SerializeField] private puntajeScript puntaje;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;

            puntaje.SumarPuntos(cantPuntos);

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.3f);
        }
    }
}
