using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PerfilJugador", menuName = "Scriptable Objects/PerfilJugador")]
public class PerfilJugador : ScriptableObject
{
    [SerializeField]
    [Range(10, 50)]
    public int experienciaProximoNivel;

    public int ExperienciaProximoNivel { get => experienciaProximoNivel; set => experienciaProximoNivel = value; }

    [SerializeField]
    [Range(10, 2000)]
    public int escalarExperiencia;

    public int EscalarExperiencia { get => escalarExperiencia; set => escalarExperiencia = value; }

    private int nivel;

    public int Nivel { get => nivel; set => nivel = value; }

    public int experiencia;

    public int Experiencia { get => experiencia; set => experiencia = value; }

    
}
