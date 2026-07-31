using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveDuration = 1f;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Start()
    {
        startPosition = transform.localPosition;
        endPosition = startPosition + Vector3.up * moveDistance;

        //StartCoroutine(OpenDoor());
    }
    
    public void Open()
    {
        StartCoroutine(OpenDoor());
    }

    private IEnumerator OpenDoor()
    {
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.Clamp01(elapsed / moveDuration);
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }

        transform.localPosition = endPosition;
    }
}
