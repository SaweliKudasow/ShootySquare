using UnityEngine;

public class DecreaseHealth : MonoBehaviour
{
    public AudioClip DamageSound; // звук удара
    private Vector2 enemyPosition; // позиция противника
    private int health = 3; // здоровье врага
    private ChangeColor changeColor; // изменение цвета
    private SquashStretch squashStretch; // анимация растяжения
    private ScreenShake mainCamera; // тряска камеры

    void Awake() {
        // получаем различные компоненты
        changeColor = GetComponent<ChangeColor>();
        squashStretch = GetComponent<SquashStretch>();
        mainCamera = Camera.main.GetComponent<ScreenShake>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        // столкновение с пулей
        if(other.gameObject.CompareTag("Bullet")) {
            health--; // уменьшаем здоровье
            changeColor.ChangeColorForSomeTime(Color.white); // меняем цвет на белый
            squashStretch.Stretch(); // запускаем анимацию растягивания
            GetComponent<AudioSource>().PlayOneShot(DamageSound); // запускаем звук удара

            if(health == 0) {
                enemyPosition = transform.position; // получаем позицию
                SetEnemyParticles.Instance.SetParticles(enemyPosition); // передаем позицию
                mainCamera.Shake(0.1f, 0.1f); // трясение камеры
                Destroy(gameObject, 0.1f); // уничтожаем объект через 0.1 секунду
            }
        }
    }
}
