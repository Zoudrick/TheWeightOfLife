using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasVerdes : MonoBehaviour
{
    public GameObject bala;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Suelo") || other.CompareTag("enemy") || other.CompareTag("Bloques"))
        {
            bala.transform.SetParent(null);
            Destroy(bala);
        }
    }
}
