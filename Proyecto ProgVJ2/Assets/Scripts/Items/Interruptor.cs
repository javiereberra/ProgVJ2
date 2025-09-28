using System.Collections;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    [Header("Configuración")]
    public int idInterruptor = 1;           // ID del interruptor (1, 2, 3)
    public float tiempoActivado = 20f;      // Duración del cooldown
    public Sprite spriteActivado;           // Sprite activado
    public Sprite spriteDesactivado;        // Sprite desactivado

    private bool activado = false;
    private SpriteRenderer miSpriteRenderer;

    private void Awake()
    {
        miSpriteRenderer = GetComponent<SpriteRenderer>();
        DesactivarVisual(); // Inicialmente desactivado visualmente
    }

    // Método para activar el interruptor
    public void Activar()
    {
        if (activado) return;

        activado = true;
        ActivarVisual();
        StartCoroutine(Cooldown());

        // Avisar a PuzzleCola (si existe)
        PuzzleCola puzzle = FindObjectOfType<PuzzleCola>();
        if (puzzle != null)
        {
            puzzle.NotificarActivacion(this);
        }
    }

    // Método para desactivar el interruptor
    public void Desactivar()
    {
        if (!activado) return;

        activado = false;
        DesactivarVisual();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Activar();
        }
    }

    // Retorna si el interruptor está activado
    public bool EstaActivo()
    {
        return activado;
    }

    // Coroutine para manejar el cooldown
    private IEnumerator Cooldown()
    {
        float timer = tiempoActivado;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        // Si la secuencia aún no se completó, se desactiva
        if (activado)
        {
            Desactivar();
        }
    }

    // Métodos para cambiar el sprite según el estado
    private void ActivarVisual()
    {
        if (miSpriteRenderer != null && spriteActivado != null)
        {
            miSpriteRenderer.sprite = spriteActivado;
        }
    }

    private void DesactivarVisual()
    {
        if (miSpriteRenderer != null && spriteDesactivado != null)
        {
            miSpriteRenderer.sprite = spriteDesactivado;
        }
    }
}