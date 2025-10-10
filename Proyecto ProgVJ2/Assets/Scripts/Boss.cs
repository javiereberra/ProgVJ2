using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal : MonoBehaviour
{
    [Header("Configuración de Ataques")]
    [SerializeField] float tiempoEntreDisparos;
    [SerializeField] float tiempoEntreEmbestidas;

    [SerializeField] private ObjectPooler poolProyectiles; 

    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoSpawnProyectil;

    [Header("Puntos de Patrulla")]
    public Transform puntoA;
    public Transform puntoB;

    [Header("Configuración de Vida")]
    public float vida = 3f;

    [Header("Configuración de Movimiento")]
    public float velocidad = 3f;

    private Transform objetivo;

    private bool dañoRecibidoEnEmbestida = false;

    //bool para no ejecutar más de una courutina de ataque a la vez
    private bool atacando = false;
    

    void Start()
    {
        //Posición inicial
        objetivo = puntoB;
        
        //Empieza con coroutine de movimiento y verifica si tiene que atacar
        StartCoroutine(Movimiento());

        StartCoroutine(VerificarAtaque());
    }

    //Comprobar la colisión de las embestidas con las trampas
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampas"))
        {
            if (!dañoRecibidoEnEmbestida)
            {
                vida -= 1f;
                dañoRecibidoEnEmbestida = true;
                Debug.Log("Boss tocó una trampa! Vida restante: " + vida);

                //El boss se destruye al quedar con vida 0.
                if (vida <= 0)
                {
                    Debug.Log("El Boss ha muerto");
                    Destroy(gameObject);
                }
            }
        }
    }

    //Coroutina de movimiento
    private IEnumerator Movimiento()
    {

        while (true)
        {
            // Mover hacia el objetivo
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

            // Si llega (con pequeña tolerancia)
            if (Vector2.Distance(transform.position, objetivo.position) < 0.05f)
            {
                // Cambia el destino
                objetivo = (objetivo == puntoA) ? puntoB : puntoA;
            }

            yield return null; 
        }
    }

    //Coroutina para verificar si está en posición de ataque cuando queda arriba del jugador
    private IEnumerator VerificarAtaque()
    {
        while (true)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
            {
                float distanciaX = Mathf.Abs(transform.position.x - jugador.transform.position.x);

                // Si está alineado con el jugador
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

            yield return null; 
        }
    }

    
    //Coroutina para disparar un objeto proyectil del pool de proyectiles
    private IEnumerator Disparar()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);

            GameObject proyectil = poolProyectiles.GetPooledObject();
            if (proyectil != null)
            {
                proyectil.transform.position = puntoSpawnProyectil.position;
                proyectil.transform.rotation = Quaternion.identity;
                proyectil.SetActive(true);
            }
        }
    }


    //Coroutina para ejecutar la embestida
    private IEnumerator Embestida()
    {
        //dañoRecibidoEnEmbestida = false; // posible booleano para ejecutar animaciòn de daño

        float tiempoEmbestida = 2f;
        float tiempoInicio = Time.time;
        float velocidadEmbestida = -12f; // Ajusta la velocidad de la embestida según tus necesidades

        Vector2 posicionInicial = transform.position;
        Vector2 posicionObjetivo = new Vector2(transform.position.x, transform.position.y + velocidadEmbestida);

        // realizar caída
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(posicionInicial, posicionObjetivo, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));
            yield return null;
        }
        // realizar la subida
        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(posicionObjetivo, posicionInicial, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));
            yield return null;
        }
    }

    

    
}