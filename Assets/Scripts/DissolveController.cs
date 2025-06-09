using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public Material dissolveMaterial;
    private float dissolveAmount = 0f;
    private float duration = 10f; 
    private bool isDissolving = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDissolving = true;
        }

        
        if (isDissolving && dissolveAmount < 1f)
        {
            dissolveAmount += Time.deltaTime / duration;
            dissolveAmount = Mathf.Clamp01(dissolveAmount);
            dissolveMaterial.SetFloat("_DisolveAmount", dissolveAmount);
        }
    }
}