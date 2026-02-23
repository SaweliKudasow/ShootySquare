using UnityEngine;

public class BulletKnockback : MonoBehaviour
{
    public float knockbackForce = 5f; // Rückstoßkraft

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")) {
            // Rigidbody des Gegners
            Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();

            // Abstoßrichtung
            Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;

            // Rückstoß anwenden
            enemyRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
