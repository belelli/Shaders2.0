using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveAndDestroy : MonoBehaviour
{
    [Header("Settings")]
    public float dissolveDuration = 1.5f;
    public string progressProperty = "_Progreso";

    [Header("Dissolve Material Template")]
    public Material dissolveMaterialTemplate;

    [Header("Shader Logic")]
    [Tooltip("Marcar si 0 es Visible y 1 es Invisible. Desmarcar si es al revés.")]
    public bool zeroIsFullyVisible = false; 

    private Renderer objectRenderer;
    private Material instantiatedDissolveMaterial;
    private bool isDisappearing = false;

    void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    public void ImpactAndDestroy()
    {
        if (isDisappearing || objectRenderer == null || dissolveMaterialTemplate == null) return;

        // 1. Guardamos la textura y color original
        Texture originalTexture = objectRenderer.material.mainTexture;
        Color originalColor = objectRenderer.material.HasProperty("_Color") 
            ? objectRenderer.material.color 
            : Color.white;

        // 2. Creamos la instancia del material
        instantiatedDissolveMaterial = new Material(dissolveMaterialTemplate);

        // 3. Le pasamos textura y color
        if (originalTexture != null)
        {
            instantiatedDissolveMaterial.mainTexture = originalTexture;
        }

        if (instantiatedDissolveMaterial.HasProperty("_BaseColor"))
        {
            instantiatedDissolveMaterial.SetColor("_BaseColor", originalColor);
        }

        // 4. Calculamos el valor inicial de visibilidad TOTAL antes de mostrarlo
        float startValue = zeroIsFullyVisible ? 0f : 1f;
        instantiatedDissolveMaterial.SetFloat(progressProperty, startValue);

        // 5. RECIÉN AHORA le asignamos el material al Renderer (evita el parpadeo)
        objectRenderer.material = instantiatedDissolveMaterial;

        // 6. Arrancamos la corrutina
        StartCoroutine(DissolveRoutine());
    }

    private IEnumerator DissolveRoutine()
    {
        isDisappearing = true;

        // Desactivamos el Collider para no recibir más impactos
        Collider objectCollider = GetComponent<Collider>();
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }

        float elapsedTime = 0f;

        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / dissolveDuration);

            // Invertimos la dirección de la animación según la lógica de tu Shader
            float progress = zeroIsFullyVisible 
                ? normalizedTime 
                : (1f - normalizedTime);

            if (instantiatedDissolveMaterial != null)
            {
                instantiatedDissolveMaterial.SetFloat(progressProperty, progress);
            }

            yield return null;
        }

        // Valor final de invisibilidad total
        float endValue = zeroIsFullyVisible ? 1f : 0f;
        if (instantiatedDissolveMaterial != null)
        {
            instantiatedDissolveMaterial.SetFloat(progressProperty, endValue);
        }

        Destroy(gameObject);
    }

}
