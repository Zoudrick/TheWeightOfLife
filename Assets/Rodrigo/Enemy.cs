using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D rbEnemigo = other.gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

            if (rb != null && rbEnemigo != null)
            {
                Vector3 putazo = gameObject.transform.position - other.transform.position;

                putazo.Normalize();
                rb.velocity = putazo * 13;
                GameManager.Instance.perderVida();
            }
        }
    }
}