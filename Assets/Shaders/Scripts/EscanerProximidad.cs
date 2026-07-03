using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscanerProximidad : MonoBehaviour
{
    public Material materialDelEntorno; // Arrastrá acá el material del suelo/paredes

    void Update()
    {
        if (materialDelEntorno != null)
        {
            // Le manda la posición X, Y, Z exacta del jugador al Shader Graph
            materialDelEntorno.SetVector("_PlayerPosition", transform.position);
        }
    }
}