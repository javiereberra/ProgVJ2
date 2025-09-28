using System.Collections.Generic;
using UnityEngine;

public class PuzzleCola : MonoBehaviour
{
    [Header("Configuraci�n")]
    public List<Interruptor> interruptoresOrdenados; // Lista con los interruptores en orden 1?2?3
    public GameObject porton;                         // port�n que se abre al completar el puzzle

    private Queue<Interruptor> cola;                 // Cola para manejar la secuencia
    private bool completado = false;

    private void Start()
    {   
        cola = new Queue<Interruptor>(interruptoresOrdenados);
    }

    // M�todo llamado por cada interruptor cuando se activa
    public void NotificarActivacion(Interruptor interruptor)
    {
        if (completado) return; // Si ya completamos, no hacemos nada


        Interruptor esperado = cola.Peek();

        if (interruptor == esperado)
        {
            // Correcto, removemos de la cola
            cola.Dequeue();
            Debug.Log($"Interruptor {interruptor.idInterruptor} activado correctamente.");

            // Si ya no queda ninguno, completamos el puzzle
            if (cola.Count == 0)
            {
                completado = true;
                AbrirPorton();
                Debug.Log("Puzzle completado: port�n abierto.");
            }
        }
        else
        {
            // Incorrecto: reseteamos todos los interruptores
            Debug.Log($"Interruptor {interruptor.idInterruptor} activado fuera de orden. Reseteando puzzle.");
            ResetPuzzle();
        }
    }

    // M�todo para abrir el port�n
    private void AbrirPorton()
    {        
        
            Porton portonScript = porton.GetComponent<Porton>();
            if (portonScript != null)
            {
                portonScript.Abrir(); // Llamamos al m�todo de la coroutine para deslizarlo
            }        
    }

    // M�todo para resetear todos los interruptores y la cola
    private void ResetPuzzle()
    {
        foreach (Interruptor intr in interruptoresOrdenados)
        {
            intr.Desactivar();
        }

        // Reiniciamos la cola
        cola = new Queue<Interruptor>(interruptoresOrdenados);
    }
}