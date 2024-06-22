using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Variables
{
    public bool Grappling;
    public bool Dash;//
    public bool Guitarra;//
    public int Escena;
    public int iterador;//
    public int maximo;//
    public int minimo;//
    public int vidas;//
}
public class SistemaGuardado : MonoBehaviour
{
    Variables variables;
    public Variables partida;
    string Json;
    string ruta;

    private void Start()
    {
        variables = new Variables();
        variables.Grappling = false;
        variables.Dash = false;
        variables.Guitarra = false;
        variables.Escena = 1;
        variables.iterador = 0;
        variables.minimo = 0;
        variables.maximo = 0;
        variables.vidas = 3;

        ruta = Path.Combine(Application.persistentDataPath, "Partida.json");
        Json = JsonUtility.ToJson(variables);
        //File.WriteAllText(ruta, Json);
        //Json = File.ReadAllText(ruta);
        partida = JsonUtility.FromJson<Variables>(Json);
    }

    public void cargarPartida()
    {
        Json = File.ReadAllText(ruta);
        partida = JsonUtility.FromJson<Variables>(Json);
        SceneManager.LoadScene(partida.Escena);
    }
    public void Save(string saveFile)
    {
        //Busca el camino donde guardara el json, cambiaria dependiendo del save slot
        ruta = Path.Combine(Application.persistentDataPath, saveFile + ".json");
        //Guardar la clase como un string
        Json = JsonUtility.ToJson(partida);
        //Hace el json
        File.WriteAllText(ruta, Json);
    }
}
