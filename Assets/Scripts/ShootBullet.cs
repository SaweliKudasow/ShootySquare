using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Kugel-Prefab
    public Transform firePoint; // Schussposition
    public float bulletSpeed = 10f; // Kugelgeschwindigkeit
    public float knockbackForce = 5f; // Rückstoß
    public ScreenShake mainCamera; // Kamera
    public AudioClip shootSound; // Schusssound
    private Rigidbody2D playerRb; // Spieler-Physik

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); // Spieler-Rigidbody holen
    }

    void Update() {
        // bei Linksklick
        if(Input.GetMouseButtonDown(0)) {
            Shoot(); // schießen
            GetComponent<AudioSource>().PlayOneShot(shootSound); // Schusssound abspielen
            GetComponent<SquashStretch>().Squash(); // Animation
            mainCamera.GetComponent<ScreenShake>().Shake(0.1f, 0.02f); // Kamera wackeln
        }
    }

    void Shoot() {
        // Kugel an firePoint erzeugen
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Mausposition
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Richtung zur Maus
        Vector2 direction = (mousePosition - firePoint.position).normalized;

        // Kugel bewegen
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * bulletSpeed;

        // Kugel in Bewegungsrichtung drehen
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Spieler-Rückstoß
        playerRb.AddForce(-direction * knockbackForce, ForceMode2D.Impulse);
    }
}
