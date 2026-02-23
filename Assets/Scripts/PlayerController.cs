using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem jumpParticle; // Sprung-Partikel
    public float moveSpeed = 5f; // Geschwindigkeit
    public float jumpForce = 10f; // Sprungkraft
    public AudioClip jumpSound; // Sprungsound
    private bool isGrounded; // am Boden?
    private Rigidbody2D rb; // Physik (Rigidbody)

    void Awake() {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody holen
    }

    void Update() {
        // Bewegung horizontal
        float moveInput = Input.GetAxis("Horizontal");

        // aktuelle Geschwindigkeit
        float currentXVelocity = rb.linearVelocity.x;

        // Zielgeschwindigkeit
        float targetXVelocity = moveInput * moveSpeed;

        // bei Eingabe setzen, sonst behalten
        if (Mathf.Abs(moveInput) > 0.1f) {
            rb.linearVelocity = new Vector2(targetXVelocity, rb.linearVelocity.y);
        }
        else {
            rb.linearVelocity = new Vector2(currentXVelocity, rb.linearVelocity.y);
        }

        // Sprung
        if(Input.GetButtonDown("Jump") && isGrounded) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // springen
            Invoke(nameof(LaunchParticles), 0.1f); // Partikel starten
            GetComponent<AudioSource>().PlayOneShot(jumpSound); // Sound abspielen
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy")) {
            isGrounded = true; // Spieler am Boden
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy")) {
            isGrounded = false; // Spieler in der Luft
        }
    }

    void LaunchParticles() {
        jumpParticle.Play(); // Partikel starten
    }
}
