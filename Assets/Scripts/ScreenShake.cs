using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 originalPos; // исходная позиция камеры
    public float shakeAmount = 0.2f; // интенсивность тряски
    public float shakeDuration = 0.5f; // длительность тряски
    private float shakeTime = 0f; // оставшееся время тряски

    void Start() {
        originalPos = transform.localPosition; // сохраняем исходное положение камеры
    }

    void Update() {
        if(shakeTime > 0) {
            // устанавливаем случайные позиции камеры
            transform.localPosition = originalPos + (Vector3)Random.insideUnitCircle * shakeAmount;
            shakeTime -= Time.deltaTime; // уменьшаем таймер
        }
        else {
            transform.localPosition = originalPos; // возвращаем камеру в исходное положение
        }
    }

    public void Shake(float duration, float intensity) {
        shakeDuration = duration; // устанавливаем длительность тряски
        shakeAmount = intensity; // устанавливаем интенсивность тряски
        shakeTime = shakeDuration; // запускаем тряску
    }
}
