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

    [Header("Immediate Cleanup")]
    [Tooltip("Arrastrá acá objetos hijos (como 'Effects') que quieras apagar INMEDIATAMENTE al recibir el impacto")]
    public List<GameObject> immediateDisableObjects = new List<GameObject>();

    private List<Material> instantiatedMaterials = new List<Material>();
    private bool isDisappearing = false;

    public void ImpactAndDestroy()
    {
        if (isDisappearing || dissolveMaterialTemplate == null) return;

        // 1. Apagamos inmediatamente los GameObjects que no llevan dissolve (ej: Effects)
        foreach (GameObject obj in immediateDisableObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        // 2. Buscamos TODOS los Renderers en este GameObject y en sus hijos
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        if (renderers.Length == 0) return;

        float startValue = zeroIsFullyVisible ? 0f : 1f;

        // 3. A cada Renderer activo le asignamos el material de dissolve
        foreach (Renderer rend in renderers)
        {
            // Ignoramos renderers que se hayan desactivado en el paso 1
            if (rend == null || !rend.gameObject.activeInHierarchy || rend.material == null) continue;

            Texture originalTexture = rend.material.mainTexture;
            Color originalColor = rend.material.HasProperty("_Color") 
                ? rend.material.color 
                : Color.white;

            Material newDissolveMat = new Material(dissolveMaterialTemplate);

            if (originalTexture != null)
            {
                newDissolveMat.mainTexture = originalTexture;
            }

            if (newDissolveMat.HasProperty("_BaseColor"))
            {
                newDissolveMat.SetColor("_BaseColor", originalColor);
            }

            newDissolveMat.SetFloat(progressProperty, startValue);
            rend.material = newDissolveMat;

            instantiatedMaterials.Add(newDissolveMat);
        }

        StartCoroutine(DissolveRoutine());
    }

    private IEnumerator DissolveRoutine()
    {
        isDisappearing = true;

        // Desactivamos los Colliders para evitar dobles impactos
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }

        float elapsedTime = 0f;

        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / dissolveDuration);

            float progress = zeroIsFullyVisible 
                ? normalizedTime 
                : (1f - normalizedTime);

            foreach (Material mat in instantiatedMaterials)
            {
                if (mat != null)
                {
                    mat.SetFloat(progressProperty, progress);
                }
            }

            yield return null;
        }

        float endValue = zeroIsFullyVisible ? 1f : 0f;
        foreach (Material mat in instantiatedMaterials)
        {
            if (mat != null)
            {
                mat.SetFloat(progressProperty, endValue);
            }
        }

        Destroy(gameObject);
    }

}
