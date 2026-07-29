using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
[SerializeField] private Renderer targetRenderer;

[SerializeField] private Material scannerMaterial;

[SerializeField] private float minRadius = 3f;
[SerializeField] private float maxRadius = 10f;
[SerializeField] private float speed = 2f;

private float currentRadius;

private void Start()
{
    currentRadius = minRadius;
    scannerMaterial.SetFloat("_RadioEscaneo", currentRadius);
}

private void Update()
{
    currentRadius += speed * Time.deltaTime;

    if (currentRadius >= maxRadius)
    {
        currentRadius = minRadius;
    }

    scannerMaterial.SetFloat("_RadioEscaneo", currentRadius);
}
}
