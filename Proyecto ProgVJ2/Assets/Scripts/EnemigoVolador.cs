using System.Collections;
using UnityEngine;

public class EnemigoVolador : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 3f;
    public bool moverADerecha = true; // para configurar desde el prefab o el portal

    [Header("Tiempo de vida")]
    public float tiempoVida = 10f; // se destruye si sale de pantalla o pasa mucho tiempo

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Velocidad horizontal según dirección
        float direccion = moverADerecha ? 1f : -1f;
        rb.velocity = new Vector2(velocidad * direccion, 0);

        GetComponent<SpriteRenderer>().flipX = moverADerecha;

        Destroy(gameObject, tiempoVida);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            

            Destroy(gameObject); // se destruye al colisionar con el jugador
        }
    }
}
