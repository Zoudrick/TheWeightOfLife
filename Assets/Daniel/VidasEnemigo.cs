using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasEnemigo : MonoBehaviour
{
    [SerializeField] private int vidas;
    [SerializeField] private GameObject corazon;
    [SerializeField] private GameObject Calaco;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chorus"))
        {
            vidas = vidas - 20;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if(collision.CompareTag("Chorus2"))
        {
            vidas = vidas - 10;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Chorus3"))
        {
            vidas = vidas - 5;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Reverb"))
        {
            vidas = vidas - 40;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Reverb2"))
        {
            vidas = vidas - 20;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Reverb3"))
        {
            vidas = vidas - 10;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Reverb3"))
        {
            vidas = vidas - 10;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Simple"))
        {
            vidas = vidas - 30;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Overdrive"))
        {
            vidas = vidas - 60;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Distortion"))
        {
            vidas = vidas - 100;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GSimple"))
        {
            vidas = vidas - 30;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GOverdrive"))
        {
            vidas = vidas - 90;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GDistortion"))
        {
            vidas = vidas - 80;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GChorus"))
        {
            vidas = vidas - 50;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GReverb"))
        {
            vidas = vidas - 20;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
    }

    private void Update()
    {
        if (vidas < 1)
        {
            Instantiate(corazon);
            corazon.transform.position = Calaco.transform.position;
            Destroy(gameObject);
        }
    }

    IEnumerator retroalimentar()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.09f);
            spriteRenderer.color = Color.white;
        }
    }
}
