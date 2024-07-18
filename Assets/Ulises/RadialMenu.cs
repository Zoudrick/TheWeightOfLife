using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;
using UnityEngine.Windows;

public class RadialMenu : MonoBehaviour
{
    public RotarArma arma;
    public SistemaGuardado sistemaGuardado;

    public JugadorInput bajo;
    public JugadorInput guitarra;
    public JugadorInput baquetas;

    public SpriteRenderer guitarrista;

    public GameObject VictoriaBajo;
    public GameObject VictoriaGuitarra;
    public GameObject VictoriaBaquetas;
    public GameObject PuntoCamara;

    public Transform center;
    public Transform selectObject;
    private Vector3 VicPosicion;

    private float Gravedad = 1;

    private bool bajoActivo;

    private bool puedeCambiar = true;

    public GameObject guitarraUI;
    public GameObject bajoUI;
    void Start()
    {
        bajoActivo = true;
        bajoUI.SetActive(true);
        guitarraUI.SetActive(false);
    }

    public void RotarArma(InputAction.CallbackContext context)
    {
        if (bajoActivo && sistemaGuardado.partida.Guitarra && puedeCambiar)
        {
            cambioGuitarra();
        }
        else if(bajoActivo && sistemaGuardado.partida.Guitarra == false){
            Debug.Log("No se puede hacer nada, carnal");
        }
        else if(bajoActivo == false && puedeCambiar)
        {
            cambioBajo();
        }
    }
    private void cambioGuitarra()
    {
        bajoActivo = false;
        PuntoCamara.transform.SetParent(null);
        StartCoroutine(ActivarGuitarra());
        guitarraUI.SetActive(true);
        bajoUI.SetActive(false);
    }
    private void cambioBajo()
    {
        bajoActivo = true;
        PuntoCamara.transform.SetParent(null);
        StartCoroutine(ActivarBajo());
        guitarraUI.SetActive(false);
        bajoUI.SetActive(true);
    }

    public IEnumerator ActivarGuitarra()
    {
        puedeCambiar = false;
        yield return new WaitForSeconds(0.1f);
        if (VictoriaBajo != null)
        {
            Gravedad = bajo.rb.gravityScale;
            VicPosicion = VictoriaBajo.transform.position;
            VictoriaBajo.SetActive(false);
        }

        if (Gravedad != guitarra.rb.gravityScale)
        {
            guitarra.orientationY *= -1;
            guitarra.rb.gravityScale *= -1;
            guitarra.feet.transform.position += Vector3.down * 1.8f * guitarra.orientationY;
            guitarra.guitarrista.transform.localScale = new Vector3(1, 1 * guitarra.orientationY, 1);
        }

        yield return new WaitForSeconds(0.1f);
        VictoriaGuitarra.SetActive(true);
        VictoriaGuitarra.transform.position = VicPosicion;
        VicPosicion.x = PuntoCamara.transform.position.x;
        PuntoCamara.transform.SetParent(VictoriaGuitarra.transform);
        Debug.Log("Sí se hizo");
        yield return new WaitForSeconds(1.5f);
        puedeCambiar = true;
    }

    public IEnumerator ActivarBajo()
    {
        puedeCambiar = false;
        yield return new WaitForSeconds(0.1f);
        bajoActivo = true;
        PuntoCamara.transform.SetParent(null);
        if (VictoriaGuitarra != null)
        {
            Gravedad = guitarra.rb.gravityScale;
            VicPosicion = VictoriaGuitarra.transform.position;
            VictoriaGuitarra.SetActive(false);
        }
        if (Gravedad != bajo.rb.gravityScale)
        {
            bajo.orientationY *= -1;
            bajo.rb.gravityScale *= -1;
            bajo.feet.transform.position += Vector3.down * 1.8f * bajo.orientationY;
            bajo.SpritesVic.transform.localScale = new Vector3(1, 1 * bajo.orientationY, 1);
            bajo.spriteRenderer.flipY = !bajo.spriteRenderer.flipY;
        }

        VictoriaBajo.SetActive(true);
        VicPosicion.x = PuntoCamara.transform.position.x;
        VictoriaBajo.transform.position = VicPosicion;
        PuntoCamara.transform.SetParent(VictoriaBajo.transform);
        yield return new WaitForSeconds(0.1f);
        PuntoCamara.transform.position = VictoriaBajo.transform.position;
        Debug.Log("Sí se hizo");
        yield return new WaitForSeconds(0.1f);
        arma.voltearDerecha();
        yield return new WaitForSeconds(0.1f);
        arma.Guitarra.transform.localScale = arma.guitarraDerecha;
        yield return new WaitForSeconds(1.5f);
        puedeCambiar = true;
    }
}