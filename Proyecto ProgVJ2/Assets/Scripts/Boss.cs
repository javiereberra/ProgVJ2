using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal : MonoBehaviour
{
    [SerializeField] float tiempoEntreDisparos;
    [SerializeField] float tiempoEntreEmbestidas;
    

    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoSpawnProyectil;

    [Header("Puntos de Patrulla")]
    public Transform puntoA;
    public Transform puntoB;

    [Header("Configuraci�n de Vida")]
    public float vida = 3f;

    [Header("Configuraci�n de Movimiento")]
    public float velocidad = 3f;

    private Transform objetivo;

    private bool da�oRecibidoEnEmbestida = false;

    private bool atacando = false;

    //private float tiempoActualEspera;
    //private int estadoActual;

    // Estados del jefe
    //private const int DispararProyectil = 0;
    //private const int Embestir = 1;
    //private const int Mover = 2;

    void Start()
    {
        objetivo = puntoB;       
        StartCoroutine(Movimiento());

        StartCoroutine(VerificarAtaque());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampas"))
        {
            if (!da�oRecibidoEnEmbestida)
            {
                vida -= 1f;
                da�oRecibidoEnEmbestida = true;
                Debug.Log("Boss toc� una trampa! Vida restante: " + vida);

                // Animaci�n o efecto visual de da�o (sin interrumpir embestida)
                //miAnimator.SetTrigger("Da�o");

                if (vida <= 0)
                {
                    Debug.Log("El Boss ha muerto");
                    Destroy(gameObject);
                }
            }
        }
    }

    private IEnumerator Movimiento()
    {

        while (true)
        {
            // Mover hacia el objetivo
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

            // Si llega (con peque�a tolerancia)
            if (Vector2.Distance(transform.position, objetivo.position) < 0.05f)
            {
                // Cambia el destino
                objetivo = (objetivo == puntoA) ? puntoB : puntoA;
            }

            yield return null; // Espera al siguiente frame
        }
    }

    private IEnumerator VerificarAtaque()
    {
        while (true)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
            {
                float distanciaX = Mathf.Abs(transform.position.x - jugador.transform.position.x);

                // Si est� alineado con el jugador
                if (distanciaX < 0.1f)
                {
                    atacando = true;

                    // Elegir aleatoriamente disparo o embestida
                    int ataque = Random.Range(0, 2); // 0 = disparar, 1 = embestir
                    if (ataque == 0) yield return StartCoroutine(Disparar());
                    else yield return StartCoroutine(Embestida());

                    atacando = false;
                }
            }

            yield return null; // Revisa cada frame
        }
    }

    private IEnumerator Disparar()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(prefabProyectil, puntoSpawnProyectil.position, Quaternion.identity);
        }
    }

    private IEnumerator Embestida()
    {
        da�oRecibidoEnEmbestida = false;

        float tiempoEmbestida = 2f;
        float tiempoInicio = Time.time;
        float velocidadEmbestida = -12f; // Ajusta la velocidad de la embestida seg�n tus necesidades

        Vector2 posicionInicial = transform.position;
        Vector2 posicionObjetivo = new Vector2(transform.position.x, transform.position.y + velocidadEmbestida);

        // Mover hacia adelante
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(posicionInicial, posicionObjetivo, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));
            yield return null;
        }
        // Mover hacia atr�s (retroceso)
        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(posicionObjetivo, posicionInicial, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));
            yield return null;
        }
    }

    

    
}