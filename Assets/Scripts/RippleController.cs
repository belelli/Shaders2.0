using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleController : MonoBehaviour
{
    public Material rippleMaterial;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rippleMaterial.SetFloat("_WaveStrength", 1.0f);
        }
        rippleMaterial.SetFloat("_WaveStrength", Mathf.Lerp(rippleMaterial.GetFloat("_WaveStrength"), 0f, Time.deltaTime * 2));
    }
}
