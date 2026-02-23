using UnityEngine;

public class DecreaseHealth : MonoBehaviour
{
    public AudioClip DamageSound; // Treffersound
    private Vector2 enemyPosition; // Gegnerposition
    private int health = 3; // Gegner-Leben
    private ChangeColor changeColor; // Farbwechsel
    private SquashStretch squashStretch; // Streck-Animation
    private ScreenShake mainCamera; // Kamera-Wackeln

    void Awake() {
        // Komponenten holen
        changeColor = GetComponent<ChangeColor>();
        squashStretch = GetComponent<SquashStretch>();
        mainCamera = Camera.main.GetComponent<ScreenShake>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Kollision mit Kugel
        if(other.gameObject.CompareTag("Bullet")) {
            health--; // Leben verringern
            changeColor.ChangeColorForSomeTime(Color.white); // Farbe auf Weiß
            squashStretch.Stretch(); // Streck-Animation starten
            GetComponent<AudioSource>().PlayOneShot(DamageSound); // Treffersound abspielen

            if(health == 0) {
                enemyPosition = transform.position; // Position holen
                SetEnemyParticles.Instance.SetParticles(enemyPosition); // Particles auf enemyPosition setzen
                mainCamera.Shake(0.1f, 0.1f); // Kamera wackeln
                Destroy(gameObject, 0.1f); // Objekt nach 0.1s entfernen
            }
        }
    }
}
