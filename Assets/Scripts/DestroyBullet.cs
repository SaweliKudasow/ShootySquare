using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private Vector2 bulletPosition; // позиция пули

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy")) {
            bulletPosition = transform.position; // сохраняем позицию пули
            SetBulletParticles.Instance.SetParticles(bulletPosition); // передаем позицию пули
            Destroy(gameObject); // уничножаем пулю
        }
    }
}
