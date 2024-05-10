using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ApuntarGrappling : MonoBehaviour
{
    public JugadorInput input;

    public GameObject Victoria1;

    //Funcionamiento del arma
    [Header("Arma")]
    static public bool rotable = false;
    private bool quieto = false;
    public float returnTime = 180;
    Vector3 currentRotation;
    static public Vector2 DireDisparo;

    [Header("Puntos de rotación")]
    public GameObject arma;
    private void Update()
    {
        if (rotable && quieto)
        {
            arma.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            arma.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void Gun(InputAction.CallbackContext context)
    {
        float HorizontalAxis = context.ReadValue<Vector2>().x;
        float VerticalAxis = context.ReadValue<Vector2>().y * input.orientationY;
        //Arma
        arma.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180 / Mathf.PI + 90f);

        currentRotation = arma.transform.localEulerAngles;

        if (HorizontalAxis == 0 && VerticalAxis == 0)
        {
            quieto = true;

            arma.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

            if (currentRotation.z > 180)
            {
                arma.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            quieto = false;
        }
    }
}
