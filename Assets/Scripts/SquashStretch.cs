using UnityEngine;
using System.Collections;

public class SquashStretch : MonoBehaviour
{
    public float squashFactor = 0.8f; // Stauch-Faktor
    public float stretchFactor = 1.2f; // Streck-Faktor
    public float duration = 0.2f; // Animationsdauer

    private Vector3 originalScale; // Ursprungsgröße

    void Awake()
    {
        originalScale = transform.localScale; // Ursprungsgröße speichern
    }

    public void Squash()
    {
        StopAllCoroutines(); // laufende Koroutinen stoppen
        StartCoroutine(AnimateSquashStretch(squashFactor, stretchFactor)); // Objekt stauchen
    }

    public void Stretch()
    {
        StopAllCoroutines(); // laufende Koroutinen stoppen
        StartCoroutine(AnimateSquashStretch(stretchFactor, squashFactor)); // Objekt strecken
    }

    // Koroutine für Stauch/Streck
    private IEnumerator AnimateSquashStretch(float xFactor, float yFactor)
    {
        // Skalen für Stauch/Streck
        Vector3 squashScale = new Vector3(originalScale.x * xFactor, originalScale.y * yFactor, originalScale.z);
        Vector3 stretchScale = new Vector3(originalScale.x * stretchFactor, originalScale.y * squashFactor, originalScale.z);

        float elapsed = 0f; // Animationszeit

        // Stauchen
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, squashScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = squashScale; // Größe setzen
        elapsed = 0f; // Zeit zurücksetzen

        // Strecken
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(squashScale, stretchScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = stretchScale; // Größe setzen
        elapsed = 0f; // Zeit zurücksetzen

        // zurück zur Ursprungsgröße
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(stretchScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale; // Größe setzen
    }
}
