using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private Material scannerMaterial;

    [SerializeField] private float minRadius = 3f;
    [SerializeField] private float maxRadius = 10f;
    [SerializeField] private float speed = 2f;

    private float currentRadius;
    private bool scanning = false;

    private void Start()
    {
        currentRadius = minRadius;
        scannerMaterial.SetFloat("_RadioEscaneo", currentRadius);
        
        //prueba
        StartScan();
    }

    private void Update()
    {
        if (!scanning)
            return;

        currentRadius += speed * Time.deltaTime;

        if (currentRadius >= maxRadius)
        {
            currentRadius = maxRadius;
            scanning = false;
        }

        scannerMaterial.SetFloat("_RadioEscaneo", currentRadius);
    }

    public void StartScan()
    {
        currentRadius = minRadius;
        scannerMaterial.SetFloat("_RadioEscaneo", currentRadius);
        scanning = true;
    }
}
