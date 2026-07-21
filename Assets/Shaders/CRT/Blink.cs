using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    [Header("Blink")]
    [SerializeField] private Image blinkImage;
    [SerializeField] private float blinkInterval = 0.5f;

    private Coroutine blinkCoroutine;

    
    private void OnEnable()
    {
        blinkCoroutine = StartCoroutine(BlinkRoutine());
    }

    private void OnDisable()
    {
        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);

        // Se asegura de que quede visible al desactivarse el script
        if (blinkImage != null)
            blinkImage.enabled = true;
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            blinkImage.enabled = !blinkImage.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
