using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 originalPos; // Kamera-Startposition
    public float shakeAmount = 0.2f; // Wackel-Stärke
    public float shakeDuration = 0.5f; // Wackel-Dauer
    private float shakeTime = 0f; // verbleibende Zeit

    void Start() {
        originalPos = transform.localPosition; // Kamera-Startposition speichern
    }

    void Update() {
        if(shakeTime > 0) {
            // Kamera zufällig verschieben
            transform.localPosition = originalPos + (Vector3)Random.insideUnitCircle * shakeAmount;
            shakeTime -= Time.deltaTime; // Timer verringern
        }
        else {
            transform.localPosition = originalPos; // Kamera zurücksetzen
        }
    }

    public void Shake(float duration, float intensity) {
        shakeDuration = duration; // Dauer setzen
        shakeAmount = intensity; // Stärke setzen
        shakeTime = shakeDuration; // Wackeln starten
    }
}
