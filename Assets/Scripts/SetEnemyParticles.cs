using UnityEngine;

public class SetEnemyParticles : MonoBehaviour
{
    public static SetEnemyParticles Instance; // Singleton
    public ParticleSystem enemyParticle; // Partikeleffekt 1
    public ParticleSystem enemyParticle2; // Partikeleffekt 2
    
    void Awake() {
        // Singleton
        if(Instance == null) {
            Instance = this; // Referenz auf dieses Objekt
        }
        else {
            Destroy(gameObject); // bei doppeltem Objekt entfernen
        }
    }

    public void SetParticles(Vector2 position) {
        // zwei Partikeleffekte an einer Stelle
        ParticleSystem enemyObject = Instantiate(enemyParticle, position, Quaternion.identity);
        ParticleSystem enemyObject2 = Instantiate(enemyParticle2, position, Quaternion.identity);

        // Partikel starten
        enemyObject.Play();
        enemyObject2.Play();

        // Partikel entfernen
        Destroy(enemyObject.gameObject, 2f);
        Destroy(enemyObject2.gameObject, 2f);
    }
}
