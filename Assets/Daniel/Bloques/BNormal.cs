using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BNormal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Simple"))
        {
            gameObject.SetActive(false);
        }
    }
}
