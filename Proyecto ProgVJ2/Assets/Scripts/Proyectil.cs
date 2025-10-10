using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Proyectil : MonoBehaviour
{
    [Header("Configuración del Proyectil")]
    [SerializeField] float velocidad = 8f;       // velocidad hacia abajo
    [SerializeField] float tiempoVida = 5f;      // para destruirlo después de un tiempo

    private Rigidbody2D rb;
    private float tiempoRestante;

    
    
    private void OnEnable()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.down * velocidad;
        tiempoRestante = tiempoVida;
    }

    private void Update()
    {
        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0)
            gameObject.SetActive(false);
    }
    


    // si choca con algo, se destruye (Herir ya se encarga de hacer daño)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // evitar destruirse si toca otro proyectil o el propio jefe
        if (!collision.gameObject.CompareTag("Boss"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}