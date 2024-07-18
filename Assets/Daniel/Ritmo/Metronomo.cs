using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Metronomo : MonoBehaviour
{

    [SerializeField] private AudioClip chord;
    [SerializeField] private AudioSource metronomo;

    [SerializeField] private AudioClip cancion;

    public GameObject Camara;

    public GameObject bolitaDerecha1;
    public GameObject bolitaDerecha2;
    public GameObject bolitaIzquierda1;
    public GameObject bolitaIzquierda2;
    public GameObject spawner;
    public GameObject spawner2;

    GameObject bolita1;
    GameObject bolita2;
    GameObject bolita3;
    GameObject bolita4;
    GameObject bolita1b;
    GameObject bolita2b;
    GameObject bolita3b;
    GameObject bolita4b;

    public float bPM;
    private float segundos = 60;
    public float delay;
    public float offset;
    private float ritmo;

    public bool early;
    public bool autorizo;
    public bool autorizo2;

    private bool Golpeo;

    public int Acorde;
    private void Awake()
    {
        ritmo = segundos / bPM;
        ritmo = ritmo - offset;
        StartCoroutine(DelayMusica());
        autorizo = false;
        Acorde = 0;
    }

    private void FixedUpdate()
    {
        if (Golpeo)
        {
            StartCoroutine(Resaltar());
        }
    }
    private IEnumerator Resaltar()
    {
        Golpeo = false;
        metronomo.PlayOneShot(chord);
        bolita1 = Instantiate(bolitaDerecha2);
        bolita1.transform.position = spawner.transform.position;
        bolita1.transform.SetParent(Camara.transform);
        bolita1b = Instantiate(bolitaIzquierda2);
        bolita1b.transform.position = spawner2.transform.position;
        bolita1b.transform.SetParent(Camara.transform);

        //Primer Toma
        transform.localScale = new Vector3(1.3f, 1.3f, 1);
        //Es posible disparar
        autorizo = true;
        if(bolita2 != null)
        {
            Destroy(bolita2);
            Destroy(bolita2b);
        }
        yield return new WaitForSeconds(0.2f);
        autorizo = false;
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(ritmo - 0.2f);


        //Segunda Toma
        bolita2 = Instantiate(bolitaDerecha1);
        bolita2.transform.position = spawner.transform.position;
        bolita2.transform.SetParent(Camara.transform);
        bolita2b = Instantiate(bolitaIzquierda1);
        bolita2b.transform.position = spawner2.transform.position;
        bolita2b.transform.SetParent(Camara.transform);

        transform.localScale = new Vector3(1.5f, 1.5f, 1);
        //Es posible disparar
        autorizo = true;
        autorizo2 = true;
        if(bolita3 != null)
        {
            Destroy(bolita3);
            Destroy(bolita3b);
        }
        yield return new WaitForSeconds(0.2f);
        autorizo = false;
        autorizo2 = false;
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(ritmo - 0.2f);


        //Tercer toma
        bolita3 = Instantiate(bolitaDerecha2);
        bolita3.transform.position = spawner.transform.position;
        bolita3.transform.SetParent(Camara.transform);
        bolita3b = Instantiate(bolitaIzquierda2);
        bolita3b.transform.position = spawner2.transform.position;
        bolita3b.transform.SetParent(Camara.transform);

        transform.localScale = new Vector3(1.3f, 1.3f, 1);
        //Es posible disparar
        autorizo = true;
        if(bolita4 != null)
        {
            Destroy(bolita4);
            Destroy(bolita4b);
        }
        yield return new WaitForSeconds(0.2f);
        autorizo = false;
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(ritmo - 0.2f);

        //Cuarta toma
        bolita4 = Instantiate(bolitaDerecha1);
        bolita4.transform.position = spawner.transform.position;
        bolita4.transform.SetParent(Camara.transform);
        bolita4b = Instantiate(bolitaIzquierda1);
        bolita4b.transform.position = spawner2.transform.position;
        bolita4b.transform.SetParent(Camara.transform);

        transform.localScale = new Vector3(1.5f, 1.5f, 1);
        //Es posible disparar
        autorizo = true;
        autorizo2 = true;
        Destroy(bolita1);
        Destroy(bolita1b);
        yield return new WaitForSeconds(0.2f);
        autorizo = false;
        autorizo2 = false;
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(ritmo - 0.2f);
        Golpeo = true;

        if (Acorde < 3)
        {
            Acorde = Acorde + 1;
            Debug.Log(Acorde);
        }
        else
        {
            Acorde = 0;
        }
    }
    private IEnumerator DelayMusica()
    {
        yield return new WaitForSeconds(1);
        metronomo.PlayOneShot(cancion);
        yield return new WaitForSeconds(delay);
        Golpeo = true;
    }
}
