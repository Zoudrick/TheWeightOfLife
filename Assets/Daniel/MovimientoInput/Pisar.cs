using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisar : MonoBehaviour
{
    public JugadorInput input;
    public Animator animator;

    public float tiempoAterrizaje = 0.3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Bloques"))
        {
            input.puedeSaltar = true;
            input.segundoSalto = true;
            if (animator != null)
            {
                animator.SetBool("Piso", true);
                animator.SetBool("Jumping", false);
                animator.SetBool("SegundoSalto", false);
            }
        }
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("pinchos"))
        {
            input.puedeSaltar = true;
            input.segundoSalto = true;
        }
    }
}
