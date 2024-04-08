using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            bool vidaRecuperada = GameManager.Instance.recuperarVida();
            Destroy(this.gameObject);
        }
    }
}
