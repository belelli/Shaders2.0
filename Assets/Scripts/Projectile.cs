using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Busca el script DissolveAndDestroy en 'other' o sube por la jerarquía hasta encontrar al Padre
        DissolveAndDestroy targetDissolve = other.GetComponentInParent<DissolveAndDestroy>();

        if (targetDissolve != null)
        {
            // Detona el dissolve en el padre e hijos
            targetDissolve.ImpactAndDestroy();
            
            // Destruye la bala inmediatamente
            Destroy(gameObject);
        }
    }
}
