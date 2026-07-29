using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private Renderer shieldRenderer;

    private int life = 3;

    // Colores
    [SerializeField] private Color life3Color; // Violeta
    [SerializeField] private Color life2Color; // Naranja claro
    [SerializeField] private Color life1Color; // Rojo

    private void Start()
    {
        UpdateColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("normalBullet"))
        {
            Damage();
        }
    }

    private void Damage()
    {
        life--;

        UpdateColor();

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateColor()
    {
        switch (life)
        {
            case 3:
                shieldRenderer.material.SetColor("_Color_Escudo", life3Color);
                break;

            case 2:
                shieldRenderer.material.SetColor("_Color_Escudo", life2Color);
                break;

            case 1:
                shieldRenderer.material.SetColor("_Color_Escudo", life1Color);
                break;
        }
    }
}
