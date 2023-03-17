using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoScript : MonoBehaviour
{
    public GameObject john;
    private float ultimoDisparoEnemigo;
    public GameObject balaPrefab;
    public int vidaEnemigo = 2;

    private void Update()
    {

        if (john == null)
        {
            return;
        }

        Vector3 direccion = john.transform.position - transform.position;

        if (direccion.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        float distancia = Mathf.Abs(john.transform.position.x - transform.position.x);

        if (distancia < 1.0f && Time.time > ultimoDisparoEnemigo + 1.1f)
        {
            DisparoEnemigo();
            ultimoDisparoEnemigo = Time.time;
        }


    }

    private void DisparoEnemigo()
    {
        Vector3 direccion;
        if (transform.localScale.x == 1.0f)
        {
            direccion = Vector2.right;
        }
        else
        {
            direccion = Vector2.left;
        }


        GameObject bala = Instantiate(balaPrefab, transform.position + direccion * 0.1f, Quaternion.identity);
        bala.GetComponent<balaScript>().SeleccionarDireccion(direccion);
    }

    public void Golpe()
    {
        vidaEnemigo = vidaEnemigo - 1;

        if (vidaEnemigo == 0)
        {
            Destroy(gameObject);
        }
    }
}
