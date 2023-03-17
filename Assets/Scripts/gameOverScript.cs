using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    public void Reiniciar()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+(-2));
        SceneManager.LoadScene(0);
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
