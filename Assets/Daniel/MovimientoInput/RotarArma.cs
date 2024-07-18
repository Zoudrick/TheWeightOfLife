using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class RotarArma : MonoBehaviour
{
    public float HorizontalAxis;
    public float offset = -30;
    public float rango = 110;

    public JugadorInput input;
    public GameObject Victoria1;

    //Funcionamiento del arma
    [Header("Arma")]
    static public bool rotable = false;
    private bool quieto = false;
    public float returnTime = 180;
    public Vector3 currentRotation;
    static public Vector2 DireDisparo;

    [Header("Puntos de rotación")]
    //Distintos puntos de rotación
    public GameObject arma;
    public GameObject cuerpo;
    public GameObject anclaBrazo;

    [Header("Para espejear")]
    //Game Object que se va a espejear
    public GameObject gOTorzo;
    private Vector3 torzoDerecha;
    private Vector3 torzoIzquierda;
    public GameObject gOFalda;
    private Vector3 faldaDerecha;
    private Vector3 faldaIzquierda;
    public GameObject Guitarra;
    public Vector3 guitarraDerecha;
    private Vector3 guitarraIzquierda;
    public GameObject Brazo;
    //orientación
    public bool izquierda;

    [Header("Cambiar jerarquía")]
    public SpriteRenderer spriteGuitarra;

    [Header("Cambio de orientación")]
    //Brazos para el cambio de orientación
    public SpriteRenderer brazoDerecha;
    public SpriteRenderer brazoIzquierda;
    public SpriteRenderer brazoIzquierda2;

    [Header("Animaciones")]
    //Animaiones
    [SerializeField] Animator animTorzo;
    [SerializeField] Animator animFalda;
    [SerializeField] Animator animGuitarra;

    private void Start()
    {
        torzoDerecha = gOTorzo.transform.localScale;
        faldaDerecha = gOFalda.transform.localScale;
        guitarraDerecha = Guitarra.transform.localScale;

        faldaIzquierda = faldaDerecha;
        torzoIzquierda = torzoDerecha;
        guitarraIzquierda = guitarraDerecha;

        faldaIzquierda.x *= -1;
        torzoIzquierda.x *= -1;
        guitarraIzquierda.y *= -1;
    }
    private void Update()
    {
        if(rotable && quieto)
        {
            arma.transform.localScale = new Vector3(-1, 1, 1);
            cuerpo.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            arma.transform.localScale = new Vector3(1, 1, 1);
            cuerpo.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void Gun(InputAction.CallbackContext context)
    {
        HorizontalAxis = context.ReadValue<Vector2>().x;
        float VerticalAxis = context.ReadValue<Vector2>().y * input.orientationY;
        //Arma
        arma.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180 / Mathf.PI + 90f);

        if(HorizontalAxis < -0.1f)
        {
            //cuerpo.transform.localEulerAngles = new Vector3(0f, 0f, -1 * (offset + Mathf.Atan2(HorizontalAxis, VerticalAxis) * rango / Mathf.PI + 90f));
            cuerpo.transform.localEulerAngles = new Vector3(0f, 0f, -1 * (-30 + Mathf.Atan2(HorizontalAxis, VerticalAxis) * 110/ Mathf.PI + 90f));
            voltearIzquierda();
            izquierda = true;
            Guitarra.transform.localScale = guitarraIzquierda;
        }
        else if (HorizontalAxis > 0.1f)
        {
            izquierda = false;
            cuerpo.transform.localEulerAngles = new Vector3(0f, 0f, offset + Mathf.Atan2(HorizontalAxis, VerticalAxis) * -rango / Mathf.PI + 90f);
            voltearDerecha();
        }

        currentRotation = arma.transform.localEulerAngles;

        if (HorizontalAxis > -0.1 && HorizontalAxis < 0.1 && VerticalAxis > -0.1 && VerticalAxis < 0.1)
        {
            quieto = true;

            arma.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            cuerpo.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

            if (izquierda)
            {
                gOTorzo.transform.localScale = torzoIzquierda;
                Guitarra.transform.localScale = guitarraIzquierda;
            }

            if (currentRotation.z > 180)
            {
                arma.transform.localScale = new Vector3(-1, 1, 1);
                cuerpo.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            quieto = false;
            gOTorzo.transform.localScale = torzoDerecha;
            gOFalda.transform.localScale = faldaDerecha;
            Guitarra.transform.localScale = guitarraDerecha;
        }
    }

    public void voltearIzquierda()
    {
        animTorzo.SetBool("izquierda", true);
        animFalda.SetBool("izquierda", true);
        animGuitarra.SetBool("izquierda", true);
        brazoDerecha.enabled = false;
        brazoIzquierda.enabled = true;
        brazoIzquierda2.enabled = true;
        spriteGuitarra.sortingOrder = 18;
    }
    public void voltearDerecha()
    {
        animTorzo.SetBool("izquierda", false);
        animFalda.SetBool("izquierda", false);
        animGuitarra.SetBool("izquierda", false);
        brazoDerecha.enabled = true;
        brazoIzquierda.enabled = false;
        brazoIzquierda2.enabled = false;
        spriteGuitarra.sortingOrder = 25;
    }
}
