using System.Collections;
using UnityEngine;

public class Porton : MonoBehaviour
{
    [Header("Configuración")]
    public Vector3 desplazamiento = new Vector3(0, 5f, 0); // cuánto se mueve al abrir
    public float velocidad = 2f; // velocidad del movimiento

    private Vector3 posicionInicial;
    private bool abierto = false;

    private void Awake()
    {
        posicionInicial = transform.position;
    }
    //metodo para abrir el portón con coroutine
    public void Abrir()
    {
        if (!abierto)
        {
            abierto = true;
            StartCoroutine(MoverPorton());
        }
    }
    //Coroutine para abrir el portón
    private IEnumerator MoverPorton()
    {
        Vector3 destino = posicionInicial + desplazamiento;

        while (Vector3.Distance(transform.position, destino) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }

        // Una vez abierto, deshabilitamos el collider
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
            collider.enabled = false;
    }
}