using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{

    [SerializeField]
    private PerfilJugador perfilJugador;

    public PerfilJugador PerfilJugador { get => perfilJugador;  }
    

    public void GanarExperiencia(int nuevaExpriencia)
    {
        perfilJugador.Experiencia += nuevaExpriencia;

        if (perfilJugador.Experiencia >= perfilJugador.ExperienciaProximoNivel)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        perfilJugador.Nivel++;
        perfilJugador.Experiencia -= perfilJugador.ExperienciaProximoNivel;
        perfilJugador.ExperienciaProximoNivel += perfilJugador.EscalarExperiencia;
    }





}
