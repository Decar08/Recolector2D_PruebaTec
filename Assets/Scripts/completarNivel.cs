using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class completarNivel : MonoBehaviour
{
    public Text gemasActuales;
    public Text gemasTotales;

    private int gemasTotalesPorNivel;

    private void Start()
    {
        gemasTotalesPorNivel = transform.childCount;
    }

    private void Update()
    {
        TodasLasGemas();
        gemasTotales.text = gemasTotalesPorNivel.ToString();
        gemasActuales.text = transform.childCount.ToString();
    }

    public void TodasLasGemas()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Ganaste!");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            SceneManager.LoadScene(1);
        }
    }
}
