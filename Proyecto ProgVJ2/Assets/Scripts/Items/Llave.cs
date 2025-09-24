using UnityEngine;

public class Llave : MonoBehaviour
{
    [SerializeField] public int idLlave; // se asigna en el Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Recolectada llave con ID: " + idLlave);

        Jugador jugador = other.GetComponent<Jugador>();
        if (jugador != null)
        {
            jugador.AgregarLlave(idLlave);
        }

        Destroy(gameObject);
    }
}