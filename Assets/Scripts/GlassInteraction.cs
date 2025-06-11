using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassInteraction : MonoBehaviour
{
    private Transform player;
    public Material glassMaterial; // Asigna el material del shader Graph
    public float triggerDistance = 2f;
    public float maxNormalMap = 0.3f;
    public float returnSpeed = 1f;

    private float currentNormal = 0f;
    private bool playerNear = false;
    private float timer = 0f;
    public float cooldownTime = 1.5f; // Tiempo antes de volver a 0

    void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        playerNear = distance <= triggerDistance;

        if (playerNear)
        {
            currentNormal = maxNormalMap;
            timer = 0f;
        }
        else
        {
            if (currentNormal > 0f)
            {
                timer += Time.deltaTime;
                if (timer >= cooldownTime)
                {
                    currentNormal = Mathf.MoveTowards(currentNormal, 0f, Time.deltaTime * returnSpeed);
                }
            }
        }

        glassMaterial.SetFloat("_NormalMap", currentNormal); // Verificá que este nombre coincida con el del shader
    }
}