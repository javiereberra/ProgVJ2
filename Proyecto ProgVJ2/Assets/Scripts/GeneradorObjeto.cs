using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjeto : MonoBehaviour
{
    [SerializeField] private GameObject[] objetosPrefabs;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    [Header("Dirección de los enemigos")]
    public bool moverADerechaPortal = true; // Esta variable se verá en el Inspector

    void Start()
    {
        InvokeRepeating(nameof(GenerarObjeto), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjeto()
    {
        int indexAleatorio = Random.Range(0, objetosPrefabs.Length);
        GameObject prefabAleatorio = objetosPrefabs[indexAleatorio];

        GameObject enemigo = Instantiate(prefabAleatorio, transform.position, Quaternion.identity);

        EnemigoVolador ev = enemigo.GetComponent<EnemigoVolador>();
        ev.moverADerecha = moverADerechaPortal;

    }
}
