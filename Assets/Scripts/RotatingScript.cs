using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingScript : MonoBehaviour
{
    [SerializeField] float _rotatingSpeed;
    
    void Update()
    {
        transform.Rotate(Vector3.up * _rotatingSpeed * Time.deltaTime);
    }
}
