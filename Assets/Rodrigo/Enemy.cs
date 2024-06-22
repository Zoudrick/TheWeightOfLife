using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool IsImmune { get; private set; } = false;
    public float fuerzaPutazo = 85;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy") && !IsImmune)
        {
            GameManager.Instance.perderVida();

            Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                Vector2 collisionDirection = (transform.position - other.transform.position).normalized;

                playerRigidbody.AddForce(collisionDirection * fuerzaPutazo * fuerzaPutazo);
            }

            StartImmunity();
        }
    }

    public void StartImmunity()
    {
        StartCoroutine(ImmunityCoroutine());
    }

    private IEnumerator ImmunityCoroutine()
    {
        IsImmune = true;
        yield return new WaitForSeconds(1.5f);
        IsImmune = false;
    }
}