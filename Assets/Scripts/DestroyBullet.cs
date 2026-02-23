using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private Vector2 bulletPosition; // Kugelposition

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy")) {
            bulletPosition = transform.position; // Kugelposition speichern
            SetBulletParticles.Instance.SetParticles(bulletPosition); // Particles auf Kugelposition setzen
            Destroy(gameObject); // Kugel entfernen
        }
    }
}
