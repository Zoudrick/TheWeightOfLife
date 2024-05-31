using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedalesHUD : MonoBehaviour
{
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
            if(cambiaPedal.iterador == 1)
            {
                pedalReverb.SetActive(true);
                pedalOverdrive.SetActive(false);
            }
            else if(cambiaPedal.iterador == 2)
            {
                pedalReverb.SetActive(false);
                pedalOverdrive.SetActive(true);
                pedalChorus.SetActive(false);
            }
            else if (cambiaPedal.iterador == 3)
            {
                pedalDistortion.SetActive(false);
                pedalOverdrive.SetActive(false);
                pedalChorus.SetActive(true);
            }
            else if (cambiaPedal.iterador == 4)
            {
                pedalDistortion.SetActive(true);
                pedalChorus.SetActive(false);
            }
            else if (cambiaPedal.iterador == 0)
            {
                pedalChorus.SetActive(false);
                pedalDistortion.SetActive(false);
                pedalOverdrive.SetActive(false);
                pedalReverb.SetActive(false);
            }
    }
}