using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraScript : MonoBehaviour
{

    public GameObject john;

    void Update()
    {

        if (john != null)
        {
            Vector3 position = transform.position;
            position.x = john.transform.position.x;
            transform.position = position;
        }

    }
}
