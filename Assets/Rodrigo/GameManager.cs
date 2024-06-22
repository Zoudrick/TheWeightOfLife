using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] SistemaGuardado sistema_guardado;

    public HUD hud;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un GameManager en escena");
        }
    }

    public void perderVida()
    {
        sistema_guardado.partida.vidas -= 1;
      if(sistema_guardado.partida.vidas == 0)
        {
            SceneManager.LoadScene(0);
        }
      
       hud.desactivarVida(sistema_guardado.partida.vidas);
    }
    public bool recuperarVida()
    {
        if(sistema_guardado.partida.vidas == 3)
        {
            return false;
        }
        hud.activarVida(sistema_guardado.partida.vidas);
        sistema_guardado.partida.vidas += 1;
        return true;
    }
}
