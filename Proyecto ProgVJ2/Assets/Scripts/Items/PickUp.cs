using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.CompareTag("Player"))
        {
            // Sumamos 1 diamante
            Jugador jugador = other.GetComponent<Jugador>();
            if (jugador != null)
            {
                jugador.diamantes += 1;
            }


            // Mostrar la cantidad de diamantes en la consola
            Debug.Log("Diamantes: " + jugador.diamantes);
            // destruir el diamante
            Destroy(gameObject);
        }
    }
}
