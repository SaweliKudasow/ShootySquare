using UnityEngine;

public class BulletKnockback : MonoBehaviour
{
    public float knockbackForce = 5f; // сила отдачи

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")) {
            // получаем ссылку физического компонента врага
            Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();

            // вычисляем направление отталкивания
            Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;

            // применяем силу отталкивания
            enemyRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
