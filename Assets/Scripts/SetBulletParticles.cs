using UnityEngine;

public class SetBulletParticles : MonoBehaviour
{
    public static SetBulletParticles Instance; // Singleton
    public ParticleSystem bulletParticle; // Partikel-Prefab
    
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
        // Partikel an Position erzeugen
        ParticleSystem bulletObject = Instantiate(bulletParticle, position, Quaternion.identity);
        bulletObject.Play(); // Partikel abspielen
        Destroy(bulletObject.gameObject, 0.8f); // Partikel-Objekt entfernen
    }
}
