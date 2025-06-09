using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public Material dissolveMaterial;
    private float dissolveAmount = 0f;
    private float duration = 10f;
    private bool isDissolving = false;
    private bool hasFullyDissolved = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDissolving = true;
        }

        if (isDissolving && !hasFullyDissolved)
        {
            dissolveAmount += Time.deltaTime / duration;
            dissolveAmount = Mathf.Clamp01(dissolveAmount);
            dissolveMaterial.SetFloat("_DisolveAmount", dissolveAmount);

            if (dissolveAmount >= 1f)
            {
                hasFullyDissolved = true;

          
                Collider col = GetComponent<Collider>();
                if (col != null) col.enabled = false;

           
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null) rb.isKinematic = true;

              
                MeshRenderer rend = GetComponent<MeshRenderer>();
                if (rend != null) rend.enabled = false;

                // (Opcional) Destruir el objeto tras 1 segundo
                // Destroy(gameObject, 1f);
            }
        }
    }
}