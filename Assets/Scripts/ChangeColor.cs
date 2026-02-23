using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // компонент отображения спрайта
    private Color originalColor; // исначальный цвет объекта

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // получаем компонент спрайта
        originalColor = spriteRenderer.color; // сохраняем исзачальный цвет
    }

    public void ChangeColorForSomeTime(Color newColor)
    {
        spriteRenderer.color = newColor; // меняем цвет спрайта
        Invoke(nameof(ResetColor), 0.1f); // через 0.1 возвращаем объекту его цвет
    }

    void ResetColor()
    {
        spriteRenderer.color = originalColor; // возвращение изначального цвета
    }
}
