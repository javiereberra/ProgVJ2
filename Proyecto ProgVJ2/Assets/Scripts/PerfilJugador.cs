using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PerfilJugador", menuName = "Scriptable Objects/PerfilJugador")]
public class PerfilJugador : ScriptableObject
{
    //Agregamos de jugador "vida" y "Diamantes" con el m�todo para acceder y modificar sus valores
    [Header("Configuraci�n de Jugador")]
    [Header("Vida")]
    [SerializeField] private float vida = 5f;
    public float Vida { get => vida; set => vida = value; }

    [Header("Diamantes")]
    [SerializeField]    
    public int diamantes = 0;
    public int Diamantes { get => diamantes; set => diamantes = value; }

    [Header("Movimiento")]
    public float velocidad = 5f;
    public float Velocidad { get => velocidad; set => velocidad = value; }
    public float fuerzaSalto = 5f;
    public float FuerzaSalto { get => fuerzaSalto; set => fuerzaSalto = value; }


    //Todas las variables de la progresi�n tambi�n para ser editadas
    [Header("Configuraci�n de Experiencia")]
    [Tooltip("Cu�nta xp necesita para subir de nivel")]
    [SerializeField]   
    [Range(10, 50)]
    public int experienciaProximoNivel;

    public int ExperienciaProximoNivel { get => experienciaProximoNivel; set => experienciaProximoNivel = value; }

    [SerializeField]
    [Range(10, 2000)]
    public int escalarExperiencia;

    public int EscalarExperiencia { get => escalarExperiencia; set => escalarExperiencia = value; }

    [SerializeField]
    private int nivel;

    public int Nivel { get => nivel; set => nivel = value; }

    [SerializeField]
    public int experiencia;

    public int Experiencia { get => experiencia; set => experiencia = value; }
    
}
