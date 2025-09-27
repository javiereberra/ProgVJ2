using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{

    private Jugador jugador;

    private void Awake()
    {
        jugador = GetComponent<Jugador>();
    }
    

    public void GanarExperiencia(int nuevaExpriencia)
    {
        PerfilJugador perfilJugador = jugador.PerfilJugador;

        perfilJugador.Experiencia += nuevaExpriencia;

        if (perfilJugador.Experiencia >= perfilJugador.ExperienciaProximoNivel)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        PerfilJugador perfilJugador = jugador.PerfilJugador;

        perfilJugador.Nivel++;
        perfilJugador.Experiencia -= perfilJugador.ExperienciaProximoNivel;
        perfilJugador.ExperienciaProximoNivel += perfilJugador.EscalarExperiencia;
    }





}
