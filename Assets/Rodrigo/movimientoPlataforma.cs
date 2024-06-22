using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPlataforma : MonoBehaviour
{
    [SerializeField] private float VelocidadMovimiento;

    [SerializeField] private Transform[] puntosdemovimiento;

    [SerializeField] private float distanciaminima;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private int numeroAleatorio = 0;
    private bool alternar = false;
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosdemovimiento[numeroAleatorio].position, VelocidadMovimiento * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosdemovimiento[numeroAleatorio].position) < distanciaminima)
        {

            alternar = !alternar;
            numeroAleatorio = alternar ? 1 : 0;

            Girar();
        }
    }


    private void Girar()
    {
        // Si la plataforma se mueve hacia la derecha
        if (transform.position.x < puntosdemovimiento[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = false;
        }
        // Si la plataforma se mueve hacia la izquierda
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}