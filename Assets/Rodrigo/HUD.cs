using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{
    public GameObject[] vidas;
    public SistemaGuardado sistemaGuardado;

    private void Start()
    {
        if(sistemaGuardado.partida.vidas < 3)
        {
            vidas[2].SetActive(false);
        }
        if(sistemaGuardado.partida.vidas < 2)
        {
            vidas[1].SetActive(false);
        }
    }

    public void desactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void activarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
