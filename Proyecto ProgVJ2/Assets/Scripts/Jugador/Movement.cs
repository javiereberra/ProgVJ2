using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{ 

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;
     

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private CapsuleCollider2D miCollider2D;

    private int saltarMask;
    
    //referencia a jugador
    private Jugador jugador;
    private PerfilJugador perfilJugador;

    private void Awake()
    {
        jugador = GetComponent<Jugador>();
        perfilJugador = jugador.PerfilJugador;
    }

    // Codigo ejecutado cuando el objeto se activa en el level

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        miCollider2D = GetComponent<CapsuleCollider2D>();
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas");
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        
        if (moverHorizontal != 0)
        {
            miSprite.flipX = moverHorizontal < 0;
        }
        int velocidadX = Mathf.Abs((int)miRigidbody2D.velocity.x);
        miAnimator.SetInteger("Velocidad", velocidadX);

        miAnimator.SetBool("EnAire", !EnContactoConPlataforma());

    }

    private void FixedUpdate()
    {        

        miRigidbody2D.velocity = new Vector2(direccion.x * jugador.PerfilJugador.Velocidad, miRigidbody2D.velocity.y);
    }

    private bool EnContactoConPlataforma()
    {
        return miCollider2D.IsTouchingLayers(saltarMask);
    }
}
