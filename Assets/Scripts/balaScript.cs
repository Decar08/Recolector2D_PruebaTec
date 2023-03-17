using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaScript : MonoBehaviour
{
    private Rigidbody2D CuerpoRigido2D;
    public float velocidad;
    private Vector2 Direccion;
    public AudioClip Musica;

    void Start()
    {
        CuerpoRigido2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Musica);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CuerpoRigido2D.velocity = Direccion * velocidad;
    }

    public void SeleccionarDireccion(Vector2 direccion)
    {
        Direccion = direccion;
    }

    public void DestruirBala()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovimientos jugador = collision.GetComponent<playerMovimientos>();
        enemigoScript enemigo = collision.GetComponent<enemigoScript>();

        if (jugador != null)
        {
            jugador.Golpe();
        }

        if (enemigo != null)
        {
            enemigo.Golpe();
        }

        DestruirBala();
    }


    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     playerMovimientos jugador = collision.collider.GetComponent<playerMovimientos>();
    //     enemigoScript enemigo = collision.collider.GetComponent<enemigoScript>();

    //     if (jugador != null)
    //     {
    //         jugador.Golpe();
    //     }

    //     if (enemigo != null)
    //     {
    //         enemigo.Golpe();
    //     }

    //     DestruirBala();
    // }
}
