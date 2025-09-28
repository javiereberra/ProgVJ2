using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{
    //referencia a jugador
    private Jugador jugador;

    private void Awake()
    {
        jugador = GetComponent<Jugador>();
    }
    
    //metodo para ganar experiencia y subir de nivel
    public void GanarExperiencia(int nuevaExpriencia)
    {
        PerfilJugador perfilJugador = jugador.PerfilJugador;

        perfilJugador.Experiencia += nuevaExpriencia;

        if (perfilJugador.Experiencia >= perfilJugador.ExperienciaProximoNivel)
        {
            SubirNivel();
        }
    }

    //subir de nivel
    private void SubirNivel()
    {
        PerfilJugador perfilJugador = jugador.PerfilJugador;

        perfilJugador.Nivel++;
        perfilJugador.Experiencia -= perfilJugador.ExperienciaProximoNivel;
        perfilJugador.ExperienciaProximoNivel += perfilJugador.EscalarExperiencia;
    }





}
