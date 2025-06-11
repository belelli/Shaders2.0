using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTriggerEffect : MonoBehaviour
{
    public Renderer glassRenderer;
    public string normalMapParameter = "_NormalMap";
    public float maxNormalValue = 1.0f;
    public float returnSpeed = 1.0f;

    private Material _materialInstance;
    private float _currentValue = 0f;
    private bool _playerInside = false;

    void Start()
    {
        _materialInstance = glassRenderer.material; // crea instancia
    }

    void Update()
    {
        if (_playerInside)
        {
            _currentValue = maxNormalValue;
        }
        else if (_currentValue > 0f)
        {
            _currentValue = Mathf.MoveTowards(_currentValue, 0f, Time.deltaTime * returnSpeed);
        }

        _materialInstance.SetFloat(normalMapParameter, _currentValue);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInside = false;
        }
    }
}