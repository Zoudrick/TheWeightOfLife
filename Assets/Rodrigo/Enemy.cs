using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool IsImmune { get; private set; } = false;
    public float fuerzaPutazo = 85;
    public float fuerzaPinchos = 85;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy") && !IsImmune)
        {
            GameManager.Instance.perderVida();

            Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                if(transform.position.x < other.transform.position.x)
                {
                    playerRigidbody.AddForce(new Vector2(-(fuerzaPutazo * fuerzaPutazo),0));
                }
                else
                {
                    playerRigidbody.AddForce(new Vector2(fuerzaPutazo * fuerzaPutazo, 0));
                }
            }

            StartCoroutine(ImmunityCoroutine());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("pinchos"))
        {
            GameManager.Instance.perderVida();

            Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                ContactPoint2D contact = other.contacts[0];

                if (transform.position.y < contact.point.y)
                {
                    playerRigidbody.AddForce(new Vector2(0, -(fuerzaPutazo * fuerzaPutazo * 0.5f)));
                }
                else
                {
                    playerRigidbody.AddForce(new Vector2(0, fuerzaPutazo * fuerzaPutazo * fuerzaPinchos));
                }
            }

            StartCoroutine(ImmunityCoroutine());
        }
    }

    private IEnumerator ImmunityCoroutine()
    {
        IsImmune = true;
        yield return new WaitForSeconds(1f);
        IsImmune = false;
    }
}