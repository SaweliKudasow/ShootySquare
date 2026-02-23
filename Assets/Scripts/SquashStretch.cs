using UnityEngine;
using System.Collections;

public class SquashStretch : MonoBehaviour
{
    public float squashFactor = 0.8f; // насколько объект сожмется
    public float stretchFactor = 1.2f; // насколько объект растянется
    public float duration = 0.2f; // длительность анимации

    private Vector3 originalScale; // оригинальный размер объекта

    void Awake()
    {
        originalScale = transform.localScale; // сохраняем оригинальный размер объекта
    }

    public void Squash()
    {
        StopAllCoroutines(); // останавливаем все текущие корутины (чтобы предыдущие анимации не налаживались друг на друга)
        StartCoroutine(AnimateSquashStretch(squashFactor, stretchFactor)); // сжимаем объект
    }

    public void Stretch()
    {
        StopAllCoroutines(); // останавливаем все текущие корутины (чтобы предыдущие анимации не налаживались друг на друга)
        StartCoroutine(AnimateSquashStretch(stretchFactor, squashFactor)); // растягиваем объект
    }

    // корутина для сжатия и растяжения объектов
    private IEnumerator AnimateSquashStretch(float xFactor, float yFactor)
    {
        // получаем размер для сжатия и растяжения
        Vector3 squashScale = new Vector3(originalScale.x * xFactor, originalScale.y * yFactor, originalScale.z);
        Vector3 stretchScale = new Vector3(originalScale.x * stretchFactor, originalScale.y * squashFactor, originalScale.z);

        float elapsed = 0f; // отслеживает время анимации

        // сжатие
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, squashScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = squashScale; // устанавливаем размер
        elapsed = 0f; // сбрасываем время

        // разтягивание
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(squashScale, stretchScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = stretchScale; // устанавливаем размер
        elapsed = 0f; // сбрасываем время

        // возвращение к исходному размеру
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(stretchScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale; // устанавливаем размер
    }
}
