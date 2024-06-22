using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CambiaPedal : MonoBehaviour
{
    public SistemaGuardado sistemaGuardado;
    public void CambiarMas(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (sistemaGuardado.partida.iterador < sistemaGuardado.partida.maximo)
            {
                sistemaGuardado.partida.iterador++;
            }
            else
            {
                sistemaGuardado.partida.iterador = sistemaGuardado.partida.minimo;
            }
        }
    }
    public void CambiarMenos(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (sistemaGuardado.partida.iterador > sistemaGuardado.partida.minimo)
            {
                sistemaGuardado.partida.iterador--;
            }
            else
            {
                sistemaGuardado.partida.iterador = sistemaGuardado.partida.maximo;
            }
        }
    }
}