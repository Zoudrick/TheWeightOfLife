using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparar : MonoBehaviour
{
    [SerializeField] AudioClip artimonki;
    [SerializeField] CambiaPedal pedal;

    public Bala bala1;
    public Bala bala2;
    public Bala bala3;
    public Bala bala4;
    public Bala bala5;
    public GameObject Victoria1;
    public GameObject miraTemporal;
    public GameObject mirilla;
    public GameObject[] balas = new GameObject[5]; // Arreglo de balas
    public GameObject Auxbala; // Arreglo de auxiliares de balas
    public Transform spawner;
    public GameObject centro;
    public GameObject centroTemporal;

    private bool posibleDisparo = true;
    public float fuerza = 20f;
    public Vector3 direccionDisparo;
    public bool disparando = false;
    public Vector3 Rodrigo;

    public Metronomo metronomo;

    private bool ordenDisparo = false;

    private void Update()
    {
        if (ordenDisparo)
        {
            accionDisparo();
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (Victoria1 != null)
        {
            if (context.canceled)
            {
                ordenDisparo = false;
                Debug.Log(ordenDisparo);
            }
            if (context.performed)
            {
                if (metronomo.autorizo)
                {
                    accionDisparo();
                    if (context.duration > 1.5f)
                    {
                        ordenDisparo = true;
                        Debug.Log(ordenDisparo);
                    }
                    else
                    {
                        ordenDisparo = false;
                    }
                }
                else
                {
                    ordenDisparo = false;
                    Debug.Log("Destiempo");
                }
            }
        }
    }

    private void accionDisparo()
    {
        if (posibleDisparo && (Victoria1 != null))
        {
            miraTemporal = Instantiate(mirilla, mirilla.transform.position, Quaternion.identity);
            centroTemporal = Instantiate(centro, centro.transform.position, Quaternion.identity);
            direccionDisparo = centroTemporal.transform.position;
            StartCoroutine(Disparando());
            Rodrigo = (direccionDisparo - miraTemporal.transform.position).normalized * Time.deltaTime * fuerza;
            bala1.Farias = Rodrigo;
            bala2.Farias = Rodrigo;
            bala3.Farias = Rodrigo;
            bala4.Farias = Rodrigo;
            bala5.Farias = Rodrigo;
            Auxbala = Instantiate(balas[pedal.iterador], miraTemporal.transform.position, Quaternion.identity);
            Auxbala.transform.SetParent(miraTemporal.transform);
            Auxbala.transform.rotation = centro.transform.rotation;
            disparando = true;
            ControladorSonido.Instance.ejecutarSonido(artimonki);
            Destroy(miraTemporal, 2f);
            Destroy(centroTemporal, 2f);
            if (Auxbala != null)
            {
                Destroy(Auxbala, 2f);
            }
        }
    }
    IEnumerator Disparando()
    {
        posibleDisparo = false;
        yield return new WaitForSeconds(0.2f);
        posibleDisparo = true;
    }
}
