using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy; // враг
    public float minX = -7f; // минимальная X координата
    public float maxX = 7f;  // максимальная X координата
    public float spawnY = 3f; // Y координата спавна

    void Update() {
        // если на сцене нет врагов
        if(GameObject.FindGameObjectWithTag("Enemy") == null) {
            float randomX = Random.Range(minX, maxX); // генерируем случайную X координату
            Vector2 spawnPosition = new Vector2(randomX, spawnY); // задаем координаты врагу
            Instantiate(enemy, spawnPosition, Quaternion.identity); // спавним врага
        }
    }
}
