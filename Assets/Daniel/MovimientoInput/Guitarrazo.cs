using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Guitarrazo : MonoBehaviour
{
    public AudioClip[,] SonidosGuitarra = new AudioClip[4, 4];
    public AudioClip[] Reverb = new AudioClip[4];
    public AudioClip[] OverDrive = new AudioClip[4];
    public AudioClip[] Chorus = new AudioClip[4];
    public AudioClip[] Distortion = new AudioClip[4];

    public SistemaGuardado sistemaGuardado;
    [SerializeField] AudioClip artimonki;
    public GameObject[] putazos = new GameObject[5];
    public CambiaPedal pedal;
    private GameObject putazo;
    public GameObject Victoria;
    public bool puedeGolpear = true;
    public Animator animator;
    public Metronomo metronomo;
    private bool orden = false;

    private void Start()
    {
        SonidosGuitarra[0, 0] = Reverb[0];
        SonidosGuitarra[0, 1] = Reverb[1];
        SonidosGuitarra[0, 2] = Reverb[2];
        SonidosGuitarra[0, 3] = Reverb[3];

        SonidosGuitarra[1, 0] = OverDrive[0];
        SonidosGuitarra[1, 1] = OverDrive[1];
        SonidosGuitarra[1, 2] = OverDrive[2];
        SonidosGuitarra[1, 3] = OverDrive[3];

        SonidosGuitarra[2, 0] = Chorus[0];
        SonidosGuitarra[2, 1] = Chorus[1];
        SonidosGuitarra[2, 2] = Chorus[2];
        SonidosGuitarra[2, 3] = Chorus[3];

        SonidosGuitarra[3, 0] = Distortion[0];
        SonidosGuitarra[3, 1] = Distortion[1];
        SonidosGuitarra[3, 2] = Distortion[2];
        SonidosGuitarra[3, 3] = Distortion[3];
    }
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
        SonidoGuitarra.Instance.ejecutarSonido(SonidosGuitarra[sistemaGuardado.partida.iterador - 1, metronomo.Acorde]);
        yield return new WaitForSeconds(0.05f);
        putazo = Instantiate(putazos[sistemaGuardado.partida.iterador]);
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
        yield return new WaitForSeconds(0.3f);
        Destroy(putazo);
        Debug.Log("Simón");
        animator.SetBool("Golpeando", false);
        yield return new WaitForSeconds(0.1f);
        puedeGolpear = true;
    }
}