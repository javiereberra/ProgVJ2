using System.Collections;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    [Header("Configuraci�n")]
    public int idInterruptor = 1;           // ID del interruptor (1, 2, 3)
    public float tiempoActivado = 20f;      // Duraci�n del cooldown
    public Sprite spriteActivado;           // Sprite activado
    public Sprite spriteDesactivado;        // Sprite desactivado

    private bool activado = false;
    private SpriteRenderer miSpriteRenderer;

    private void Awake()
    {
        miSpriteRenderer = GetComponent<SpriteRenderer>();
        DesactivarVisual(); // Inicialmente desactivado visualmente
    }

    // M�todo para activar el interruptor
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

    // M�todo para desactivar el interruptor
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

    // Retorna si el interruptor est� activado
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

        // Si la secuencia a�n no se complet�, se desactiva
        if (activado)
        {
            Desactivar();
        }
    }

    // M�todos para cambiar el sprite seg�n el estado
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