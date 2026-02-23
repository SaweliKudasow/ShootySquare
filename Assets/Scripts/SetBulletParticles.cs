using UnityEngine;

public class SetBulletParticles : MonoBehaviour
{
    public static SetBulletParticles Instance; // переменная для Singleton
    public ParticleSystem bulletParticle; // префаб с системой частиц
    
    void Awake() {
        // реализация Singleton
        if(Instance == null) {
            Instance = this; // сохраняем ссылку на текущий объект
        }
        else {
            Destroy(gameObject); // если экземпляр уже существует то уничтожаем объект
        }
    }

    public void SetParticles(Vector2 position) {
        // создаем новый объект с системой частиц в заданной позиции
        ParticleSystem bulletObject = Instantiate(bulletParticle, position, Quaternion.identity);
        bulletObject.Play(); // запускаем анимацию частиц
        Destroy(bulletObject.gameObject, 0.8f); // уничтожаем объект с частицами
    }
}
