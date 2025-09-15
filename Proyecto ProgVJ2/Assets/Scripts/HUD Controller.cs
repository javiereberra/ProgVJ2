using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto;
    [SerializeField] TextMeshProUGUI labelTiempo;

    public void ActualizarTextoHUD(string nuevoTexto)
    {
        Debug.Log("SE LLAMA " + nuevoTexto);
        miTexto.text = nuevoTexto;
    }

    public void ActualizarTiempo(float segundosRestantes)
    {
        int minutos = Mathf.FloorToInt(segundosRestantes / 60);
        int segundos = Mathf.FloorToInt(segundosRestantes % 60);
        labelTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
