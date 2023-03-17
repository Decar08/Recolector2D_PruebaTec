using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aTierra : MonoBehaviour
{
    public static bool enTierra;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enTierra = true;
    }

    private void OnTriggerExit2d(Collider2D collision)
    {
        enTierra = false;
    }
}
