using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    // Referencia al transform del jugador serializada
    [SerializeField] Transform jugador;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Vector2 direccion;

    private void Awake()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Calculamos solo la direcci�n en X
        float dirX = (jugador.position.x - transform.position.x) > 0 ? 1f : -1f;

        // Mantener la velocidad actual en Y (gravedad, saltos, ca�das)
        miRigidbody2D.velocity = new Vector2(dirX * velocidad, miRigidbody2D.velocity.y);
    }

}