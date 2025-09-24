using UnityEngine;

public class Puerta : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private int idPuerta = 1;  // ID que debe coincidir con la llave
    [SerializeField] private Sprite spritePuertaAbierta;  // Sprite cuando se abre

    private SpriteRenderer miSpriteRenderer;
    private BoxCollider2D miCollider;

    private void Awake()
    {
        miSpriteRenderer = GetComponent<SpriteRenderer>();
        miCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Solo reaccionamos si es el jugador
        if (!collision.gameObject.CompareTag("Player")) return;

        // Obtenemos el script Jugador
        Jugador jugador = collision.gameObject.GetComponent<Jugador>();
        if (jugador == null) return;

        // Verificamos si tiene la llave correspondiente
        if (jugador.TieneLlave(idPuerta))
        {
            AbrirPuerta();
        }
        else
        {
            Debug.Log($"La puerta {idPuerta} está cerrada. Necesitas la llave {idPuerta}");
        }
    }

    private void AbrirPuerta()
    {
        // Cambiamos el sprite
        if (spritePuertaAbierta != null)
        {
            miSpriteRenderer.sprite = spritePuertaAbierta;
        }

        // Permitimos que el jugador atraviese
        if (miCollider != null)
        {
            miCollider.isTrigger = true; // ahora se puede atravesar
        }

        Debug.Log($"La puerta {idPuerta} se abrió.");
    }
}