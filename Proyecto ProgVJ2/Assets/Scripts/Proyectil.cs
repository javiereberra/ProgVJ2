using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Proyectil : MonoBehaviour
{
    [Header("Configuraci�n del Proyectil")]
    [SerializeField] float velocidad = 8f;       // velocidad hacia abajo
    [SerializeField] float tiempoVida = 5f;      // para destruirlo despu�s de un tiempo

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // le damos impulso inicial hacia abajo (puede ser hacia otra direcci�n si quer�s)
        rb.velocity = Vector2.down * velocidad;

        // destruir autom�ticamente despu�s de un tiempo
        Destroy(gameObject, tiempoVida);
    }

    // si choca con algo, se destruye (Herir ya se encarga de hacer da�o)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // evitar destruirse si toca otro proyectil o el propio jefe
        if (!collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}