using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BReverb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Reverb") || collision.CompareTag("GReverb") || collision.CompareTag("Reverb2") || collision.CompareTag("Reverb3"))
        {
            gameObject.SetActive(false);
        }
    }
}
