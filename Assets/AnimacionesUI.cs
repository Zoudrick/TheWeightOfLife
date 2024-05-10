using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimacionesUI : MonoBehaviour
{
    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject elmp3;
    [SerializeField] private GameObject menuExtra;
    [SerializeField] private GameObject EconderExtra;
    

    //gamepad
    public GameObject opcionesFirst;
    public GameObject principalFirst;
   

    private void Start()
    {
        LeanTween.moveX(titulo.GetComponent<RectTransform>(), -218, 1.5f).setEase(LeanTweenType.easeInOutElastic); ;

        LeanTween.moveY(elmp3.GetComponent<RectTransform>(), -79, 3f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void ActivarOpciones()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(opcionesFirst);
        LeanTween.moveX(menuExtra.GetComponent<RectTransform>(), 272, 0.5f);


    }

    public void DesactivarOpciones()
    {

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(principalFirst);
        LeanTween.moveX(EconderExtra.GetComponent<RectTransform>(), 608, 0.5f);

    }

    
}
