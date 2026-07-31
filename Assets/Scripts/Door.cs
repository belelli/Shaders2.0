using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform doorMesh;
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveDuration = 1f;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    private void Start()
    {
        closedPosition = doorMesh.localPosition;
        openPosition = closedPosition + Vector3.down * moveDistance;
    }

    public void Open()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(openPosition));
    }

    public void Close()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(closedPosition));
    }

    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        Vector3 startPosition = doorMesh.localPosition;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveDuration);

            doorMesh.localPosition = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        doorMesh.localPosition = targetPosition;
    }
}
