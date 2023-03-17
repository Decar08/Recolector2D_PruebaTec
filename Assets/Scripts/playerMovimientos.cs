using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovimientos : MonoBehaviour
{
    public GameObject balaPrefab;
    public float velocidadCorrer = 2;
    public float velocidadSalto = 3;
    private float Horiontal;
    private bool Grounded;
    private Animator animacion;
    private float ultimoDisparo;
    private int vida = 3;
    public AudioClip Musica;
    [Header("Rebote")]
    [SerializeField] private float velocidadReote;

    public GameObject[] vidas;


    Rigidbody2D CuerpoRigido2D;
   
    void Start()
    {
        vida = vidas.Length;
        CuerpoRigido2D = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Musica);
    }

    void Update()
    {
        Horiontal = Input.GetAxisRaw("Horizontal");

        if (Horiontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horiontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        animacion.SetBool("corriendo", Horiontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else 
        {
            Grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Salto();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > ultimoDisparo + 0.25f)
        {
            Disparo();
            ultimoDisparo = Time.time;
        }

        if ( vida < 1)
        {
            Destroy(vidas[0].gameObject);
        }
        else if (vida < 2)
        {
            Destroy(vidas[1].gameObject);
        }
        else if (vida < 3)
        {
            Destroy(vidas[2].gameObject);
        }
    }

    public void Rebote()
    {
        CuerpoRigido2D.velocity = new Vector2(CuerpoRigido2D.velocity.x, velocidadReote);
    }

    private void Salto()
    {
        CuerpoRigido2D.AddForce(Vector2.up * velocidadSalto);
    }

    private void Disparo()
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
        vida = vida - 1;

        if (vida == 0)
        {
            Destroy(gameObject);
            // Escenario();  
            SceneManager.LoadScene("gameOver");
   

            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    // public static bool Escenario()
    // {
    //     if (SceneManager.LoadScene("Nivel_1"))
    //     {
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    //     }
    //     else if (SceneManager.LoadScene("Nivel_2"))
    //     {
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    //     }
    // }

    // private void Jump()
    // {
        
    // }

    // private void FixedUpdate()
    // {
    //     if (Input.GetKey("d") || Input.GetKey("right"))
    //     {
    //         CuerpoRigido2D.velocity = new Vector2(velocidadCorrer, CuerpoRigido2D.velocity.y);
    //     }
    //     else if (Input.GetKey("a") || Input.GetKey("left"))
    //     {
    //         CuerpoRigido2D.velocity = new Vector2(-velocidadCorrer, CuerpoRigido2D.velocity.y);
    //     }
    //     else
    //     {
    //         CuerpoRigido2D.velocity = new Vector2(0, CuerpoRigido2D.velocity.y);
    //     }
    //     if((Input.GetKey("w") || Input.GetKey("space")) && aTierra.enTierra)
    //     {
    //         CuerpoRigido2D.velocity = new Vector2(CuerpoRigido2D.velocity.x, velocidadSalto);
    //     }
    // }

    //Versión 2
    private void FixedUpdate()
    {
        CuerpoRigido2D.velocity = new Vector2(Horiontal, CuerpoRigido2D.velocity.y);
    }

    
}
