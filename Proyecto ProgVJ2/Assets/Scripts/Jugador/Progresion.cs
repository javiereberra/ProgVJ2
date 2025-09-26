using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{
    private int nivel;
    public int experiencia;

    [SerializeField]
    [Range(10,50)]
    public int experienciaProximoNivel;

    [SerializeField]
    [Range(10, 2000)]
    public int escalarExperiencia;

    public global::System.Int32 Nivel { get => nivel; }

    public void GanarExperiencia(int nuevaExpriencia)
    {
        experiencia += nuevaExpriencia;

        if (experiencia >= experienciaProximoNivel)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        nivel++;
        experiencia -= experienciaProximoNivel;
        experienciaProximoNivel += escalarExperiencia;
    }





}
