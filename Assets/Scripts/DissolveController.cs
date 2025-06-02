using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public Material dissolveMaterial;
    private float dissolveAmount = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            dissolveAmount += Time.deltaTime * 0.5f;
            dissolveAmount = Mathf.Clamp01(dissolveAmount);
            dissolveMaterial.SetFloat("_DisolveAmount", dissolveAmount);
        }
    }
}
