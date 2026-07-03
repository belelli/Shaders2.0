using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNanobots : MonoBehaviour
{
    public Material materialInteligente;
    public float velocidad = 1f;

    void Update()
    {
        if (materialInteligente != null)
        {
            
            float valor = Mathf.PingPong(Time.time * velocidad, 1f);
            
            materialInteligente.SetFloat("_Progreso", valor);
        }
    }
}