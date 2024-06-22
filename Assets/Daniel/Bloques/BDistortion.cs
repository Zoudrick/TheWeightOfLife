using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDistortion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Distortion") || collision.CompareTag("GDistortion"))
        {
            gameObject.SetActive(false);
        }
    }
}
