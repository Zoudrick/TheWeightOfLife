using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Guitarrazo : MonoBehaviour
{
    [SerializeField] AudioClip artimonki;
    public GameObject[] putazos = new GameObject[5];
    public CambiaPedal pedal;
    private GameObject putazo;
    public GameObject Victoria;
    public bool puedeGolpear = true;
    public Animator animator;
    public Metronomo metronomo;
    private bool orden = false;

    private void Update()
    {
        if(orden && metronomo.autorizo2)
        {
            Debug.Log("Simón");
            animator.SetBool("Golpeando", true);
            StartCoroutine(duracionPutazo());
            orden = false;
        }
    }
    public void golpear(InputAction.CallbackContext context)
    {
        if (context.performed && puedeGolpear)
        {
            orden = true;
            Debug.Log("Ordenado");
            /*if (metronomo.autorizo)
            {
                Debug.Log("Simón");
                animator.SetBool("Golpeando", true);
                StartCoroutine(duracionPutazo());
            }
            else
            {
                Debug.Log("Destiempo");
            }*/
        }
    }
    private IEnumerator duracionPutazo()
    {
        puedeGolpear = false;
        ControladorSonido.Instance.ejecutarSonido(artimonki);
        yield return new WaitForSeconds(0.05f);
        putazo = Instantiate(putazos[pedal.iterador]);
        putazo.transform.SetParent(putazo.transform, Victoria);
        if (RotarArma.rotable)
        {

            putazo.transform.position = Victoria.transform.position;
            putazo.transform.position += Vector3.left * 1f;
        }
        else
        {
            putazo.transform.position = Victoria.transform.position;
            putazo.transform.position += Vector3.right * 1f;
        }
        yield return new WaitForSeconds(0.05f);
        Destroy(putazo);
        Debug.Log("Simón");
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Golpeando", false);
        puedeGolpear = true;
    }

}