using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedalesHUD : MonoBehaviour
{
    public SistemaGuardado sistemaGuardado;

    [SerializeField] GameObject pedalReverb; // La imagen en el HUD que quieres cambiar
    [SerializeField] GameObject pedalOverdrive;
    [SerializeField] GameObject pedalChorus;
    [SerializeField] GameObject pedalDistortion;

    public CambiaPedal cambiaPedal;

    private void Start()
    {
        pedalReverb.SetActive(false);
        pedalOverdrive.SetActive(false);
        pedalChorus.SetActive(false);
        pedalDistortion.SetActive(false);
    }
    void Update()
    {
            if(sistemaGuardado.partida.iterador == 1)
            {
                pedalReverb.SetActive(true);
                pedalOverdrive.SetActive(false);
                pedalChorus.SetActive(false);
                pedalDistortion.SetActive(false);
            }
            else if(sistemaGuardado.partida.iterador == 2)
            {
                pedalReverb.SetActive(false);
                pedalOverdrive.SetActive(true);
                pedalChorus.SetActive(false);
                pedalDistortion.SetActive(false);
            }
            else if (sistemaGuardado.partida.iterador == 3)
            {
                pedalReverb.SetActive(false);
                pedalOverdrive.SetActive(false);
                pedalChorus.SetActive(true);
                pedalDistortion.SetActive(false);
            }
            else if (sistemaGuardado.partida.iterador == 4)
            {
                pedalReverb.SetActive(false);
                pedalOverdrive.SetActive(false);
                pedalChorus.SetActive(false);
                pedalDistortion.SetActive(true);
            }
            else if (sistemaGuardado.partida.iterador == 0)
            {
                pedalChorus.SetActive(false);
                pedalDistortion.SetActive(false);
                pedalOverdrive.SetActive(false);
                pedalReverb.SetActive(false);
            }
    }
}