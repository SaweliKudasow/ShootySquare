using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab; // пуля
    public Transform firePoint; // точка спавна пули
    public float bulletSpeed = 10f; // скорость пули
    public float knockbackForce = 5f; // сила отдачи
    public ScreenShake mainCamera; // камера
    public AudioClip shootSound; // звук выстрела
    private Rigidbody2D playerRb; // компонент физики игрока

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); // получаем физику игрока
    }

    void Update() {
        // при нажатии на пкм
        if(Input.GetMouseButtonDown(0)) {
            Shoot(); // выстрел
            GetComponent<AudioSource>().PlayOneShot(shootSound); // включаем звук выстрела
            GetComponent<SquashStretch>().Squash(); // анимация
            mainCamera.GetComponent<ScreenShake>().Shake(0.1f, 0.02f); // трясение камеры
        }
    }

    void Shoot() {
        // создаем пулю в точке firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // получаем позицию курсора
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // вычисляем направление к курсору
        Vector2 direction = (mousePosition - firePoint.position).normalized;

        // двигаем пулю
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * bulletSpeed;

        // поворачиваем пулю в сторону движения
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        // отдача игрока
        playerRb.AddForce(-direction * knockbackForce, ForceMode2D.Impulse);
    }
}
