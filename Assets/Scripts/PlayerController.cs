using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem jumpParticle; // частицы прыжка
    public float moveSpeed = 5f; // скорость
    public float jumpForce = 10f; // сила прыжка
    public AudioClip jumpSound; // звук прыжка
    private bool isGrounded; // проверка на приземление
    private Rigidbody2D rb; // компонент физики

    void Awake() {
        rb = GetComponent<Rigidbody2D>(); // получаем компонент физики
    }

    void Update() {
        // горизонтальное движение
        float moveInput = Input.GetAxis("Horizontal");

        // сохраняем существующую скорость
        float currentXVelocity = rb.linearVelocity.x;

        // рассчитываем целевую скорость учитывая движение игрока
        float targetXVelocity = moveInput * moveSpeed;

        // если игрок двигается заменяем скорость но если нет оставляем текущую
        if (Mathf.Abs(moveInput) > 0.1f) {
            rb.linearVelocity = new Vector2(targetXVelocity, rb.linearVelocity.y);
        }
        else {
            rb.linearVelocity = new Vector2(currentXVelocity, rb.linearVelocity.y);
        }

        // прыжок
        if(Input.GetButtonDown("Jump") && isGrounded) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // прыгаем
            Invoke(nameof(LaunchParticles), 0.1f); // запуск частиц
            GetComponent<AudioSource>().PlayOneShot(jumpSound); // запуск звука
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy")) {
            isGrounded = true; // игрок приземлился
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy")) {
            isGrounded = false; // игрок в полете
        }
    }

    void LaunchParticles() {
        jumpParticle.Play(); // запускаем частицы
    }
}
