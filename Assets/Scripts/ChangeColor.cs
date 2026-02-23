using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Sprite-Renderer
    private Color originalColor; // Ursprungsfarbe

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Sprite-Komponent holen
        originalColor = spriteRenderer.color; // Ursprungsfarbe speichern
    }

    public void ChangeColorForSomeTime(Color newColor)
    {
        spriteRenderer.color = newColor; // Sprite-Farbe ändern
        Invoke(nameof(ResetColor), 0.1f); // nach 0.1s Farbe zurücksetzen
    }

    void ResetColor()
    {
        spriteRenderer.color = originalColor; // Ursprungsfarbe wiederherstellen
    }
}
