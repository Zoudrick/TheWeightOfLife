using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarDialogos : MonoBehaviour
{
    public Dialogo Activador;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Activador != null)
        {
            Activador.desactivarDialogo();
        }
       
    }
}
