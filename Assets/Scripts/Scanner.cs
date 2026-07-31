using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [Header("Scanner")]
    [SerializeField] private Material scannerMaterial;
    [SerializeField] private float minRadius = 3f;
    [SerializeField] private float maxRadius = 10f;
    [SerializeField] private float speed = 2f;

    [Header("Door")]
    [SerializeField] private Door door;

    private float currentRadius;
    private bool scanning = false;
    private bool used = false;

    private void Start()
    {
        currentRadius = minRadius;
        scannerMaterial.SetFloat("_RadioEscaneo", currentRadius);
        //StartScan();
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

            scannerMaterial.SetFloat("_RadioEscaneo", currentRadius);

            // Abrir la puerta al terminar el escaneo
            door.Open();

            return;
        }

        scannerMaterial.SetFloat("_RadioEscaneo", currentRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (used)
            return;

        if (other.CompareTag("Player"))
        {
            used = true;
            StartScan();
        }
    }

    public void StartScan()
    {
        currentRadius = minRadius;
        scannerMaterial.SetFloat("_RadioEscaneo", currentRadius);
        scanning = true;
    }
}
