using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;
using UnityEngine.Windows;

public class RadialMenu : MonoBehaviour
{
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

    public GameObject RadialMenuRoot;
    public float angleOffset = 30;
    float targetAngle = 0;

    private float Gravedad = 1;

    float x = 0;
    float y = 0;

    private int ultimaEleccion = 240;

    private bool isRadialMenuActive;
    void Start()
    {
        isRadialMenuActive = false;
    }

    public void ActivarHud(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isRadialMenuActive = !isRadialMenuActive;
            if (isRadialMenuActive)
            {
                RadialMenuRoot.SetActive(true);
            }
            else
            {
                RadialMenuRoot.SetActive(false);
                if (targetAngle == 0)
                {
                    //cambioBaquetas();
                }
                else if(targetAngle == 120 && targetAngle != ultimaEleccion)
                {
                    cambioGuitarra();
                    ultimaEleccion = 120;
                    Debug.Log(ultimaEleccion);
                }
                else if(targetAngle == 240 && targetAngle != ultimaEleccion)
                {
                    cambioBajo();
                    ultimaEleccion = 240;
                    Debug.Log(ultimaEleccion);
                }
            }
        }
    }

    public void SeleccionarArma(InputAction.CallbackContext context)
    {
        if (isRadialMenuActive)
        {
            Vector2 input = context.ReadValue<Vector2>();
            x = input.x;
            y = input.y;

            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

            if (angle < 0)
            {
                angle += 360;
            }

            angle = (angle + angleOffset) % 360;

            int sectionAngle = 120;
            int selectedSection = Mathf.FloorToInt(angle / sectionAngle);

            targetAngle = selectedSection * sectionAngle;
            selectObject.eulerAngles = new Vector3(0, 0, targetAngle);
            Debug.Log(targetAngle);
        }
    }
    /*private void cambioBaquetas()
    {
        PuntoCamara.transform.SetParent(null);
        if (VictoriaBajo != null)
        {
            Gravedad = bajo.rb.gravityScale;
            VicPosicion = VictoriaBajo.transform.position;
            VictoriaBajo.SetActive(false);
        }
        else if (VictoriaGuitarra != null)
        {
            Gravedad = guitarra.rb.gravityScale;
            VicPosicion = VictoriaGuitarra.transform.position;
            VictoriaGuitarra.SetActive(false);
        }
        if(Gravedad != baquetas.rb.gravityScale)
        {
            baquetas.orientationY *= -1;
            baquetas.rb.gravityScale *= -1;
            baquetas.feet.transform.position += Vector3.down * 1.8f * baquetas.orientationY;
            baquetas.SpritesVic.transform.localScale = new Vector3(1, 1 * baquetas.orientationY, 1);
            baquetas.spriteRenderer.flipY = !baquetas.spriteRenderer.flipY;
        }
        VictoriaBaquetas.SetActive(true);
        VictoriaBaquetas.transform.position = VicPosicion;
        VicPosicion.x = PuntoCamara.transform.position.x;
        PuntoCamara.transform.SetParent(VictoriaBaquetas.transform);
    }*/
    private void cambioGuitarra()
    {
        PuntoCamara.transform.SetParent(null);
        if (VictoriaBajo != null)
        {
            Gravedad = bajo.rb.gravityScale;
            VicPosicion = VictoriaBajo.transform.position;
            VictoriaBajo.SetActive(false);
        }
        /*else if (VictoriaBaquetas != null)
        {
            VicPosicion = VictoriaBaquetas.transform.position;
            VictoriaBaquetas.SetActive(false);
            Gravedad = baquetas.rb.gravityScale;
        }*/
        /*else if(VictoriaGuitarra != null)
        {
            VicPosicion = VictoriaGuitarra.transform.position;
            Gravedad = guitarra.rb.gravityScale;
        }*/

        if (Gravedad != guitarra.rb.gravityScale)
        {
            guitarra.orientationY *= -1;
            guitarra.rb.gravityScale *= -1;
            guitarra.feet.transform.position += Vector3.down * 1.8f * guitarra.orientationY;
            guitarra.guitarrista.transform.localScale = new Vector3(1, 1 * guitarra.orientationY, 1);
            //guitarra.guitarrista.flipY = !guitarra.guitarrista.flipY;
        }

        VictoriaGuitarra.SetActive(true);
        VictoriaGuitarra.transform.position = VicPosicion;
        VicPosicion.x = PuntoCamara.transform.position.x;
        PuntoCamara.transform.SetParent(VictoriaGuitarra.transform);
    }
    private void cambioBajo()
    {
        PuntoCamara.transform.SetParent(null);
        if (VictoriaGuitarra != null)
        {
            Gravedad = guitarra.rb.gravityScale;
            VicPosicion = VictoriaGuitarra.transform.position;
            VictoriaGuitarra.SetActive(false);
        }
        /*else if (VictoriaBaquetas != null)
        {
            Gravedad = baquetas.rb.gravityScale;
            VicPosicion = VictoriaBaquetas.transform.position;
            VictoriaBaquetas.SetActive(false);
        }*/
        /*else if(VictoriaBajo != null)
        {
            Gravedad = bajo.rb.gravityScale;
            VicPosicion = VictoriaBajo.transform.position;
            Gravedad = bajo.rb.gravityScale;
            Debug.Log("Es nulo");
        }*/

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
    }
}