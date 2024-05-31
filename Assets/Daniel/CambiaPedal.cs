using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CambiaPedal : MonoBehaviour
{
    public int iterador = 0;
    public int maximo = 4;
    public int minimo = 0;
    public void CambiarMas(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (iterador < maximo)
            {
                iterador++;
            }
            else
            {
                iterador = minimo;
            }
        }
    }
    public void CambiarMenos(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (iterador > minimo)
            {
                iterador--;
            }
            else
            {
                iterador = maximo;
            }
        }
    }
}