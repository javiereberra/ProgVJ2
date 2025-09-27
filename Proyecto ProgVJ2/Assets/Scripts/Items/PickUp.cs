using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private int experienciaPorDiamante = 10;
    




    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.CompareTag("Player"))
        {
            // Sumamos 1 diamante
            Jugador jugador = other.GetComponent<Jugador>();
            Progresion progresion = other.GetComponent<Progresion>();
            if (jugador != null)
            {
                jugador.diamantes += 1;

              
            }

            if (progresion != null)
            {
                // Sumamos experiencia
                progresion.GanarExperiencia(experienciaPorDiamante);
                Debug.Log("Experiencia actual: " + progresion.PerfilJugador.Experiencia);
            }


            // Mostrar la cantidad de diamantes en la consola
            Debug.Log("Diamantes: " + jugador.diamantes);
            // destruir el diamante
            Destroy(gameObject);
        }
    }
}
