using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.EventSystems.EventTrigger;

public class Bala : MonoBehaviour
{
    public Vector3 Farias;
    private void Update()
    {
        transform.position += Farias.normalized * 0.3f;
    }
}
