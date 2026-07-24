using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Intentamos obtener el componente DissolveAndDestroy del objeto impactado
        DissolveAndDestroy targetDissolve = other.GetComponent<DissolveAndDestroy>();

        if (targetDissolve != null)
        {
            // Activamos el efecto de disolución y posterior destrucción
            targetDissolve.ImpactAndDestroy();
            
            // Destruimos la bala al impactar
            Destroy(gameObject);
        }
    }
}
