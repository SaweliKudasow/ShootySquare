using UnityEngine;

public class SetEnemyParticles : MonoBehaviour
{
    public static SetEnemyParticles Instance; // переменная для Singleton
    public ParticleSystem enemyParticle; // первый эффект частиц
    public ParticleSystem enemyParticle2; // второй эффект частиц
    
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
        // создаем два разных эффекта частиц в одной позиции
        ParticleSystem enemyObject = Instantiate(enemyParticle, position, Quaternion.identity);
        ParticleSystem enemyObject2 = Instantiate(enemyParticle2, position, Quaternion.identity);

        // запускаем частицы
        enemyObject.Play();
        enemyObject2.Play();

        // удаляем частицы
        Destroy(enemyObject.gameObject, 2f);
        Destroy(enemyObject2.gameObject, 2f);
    }
}
