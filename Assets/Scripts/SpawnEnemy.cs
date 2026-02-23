using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy; // Gegner-Prefab
    public float minX = -7f; // min. X
    public float maxX = 7f;  // max. X
    public float spawnY = 3f; // Spawn-Y

    void Update() {
        // wenn kein Gegner da
        if(GameObject.FindGameObjectWithTag("Enemy") == null) {
            float randomX = Random.Range(minX, maxX); // zufällige X-Koordinate
            Vector2 spawnPosition = new Vector2(randomX, spawnY); // Spawn-Position
            Instantiate(enemy, spawnPosition, Quaternion.identity); // Gegner spawnen
        }
    }
}
