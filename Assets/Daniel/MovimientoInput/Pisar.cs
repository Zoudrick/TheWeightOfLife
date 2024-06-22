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
        if (collision.gameObject.CompareTag("Suelo"))
        {
            input.puedeSaltar = true;
            input.segundoSalto = true;
            if (animator != null)
            {
                animator.SetBool("Piso", true);
                animator.SetBool("Jumping", false);
                animator.SetBool("SegundoSalto", false);
                input.piernasQuietas.enabled = true;
            }
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            input.puedeSaltar = true;
            input.segundoSalto = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            input.piernasQuietas.enabled = false;
        }
    }
}
