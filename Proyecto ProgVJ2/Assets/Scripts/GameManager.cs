using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI miTexto; // referencia al HUD
    [SerializeField] private float tiempoInicial = 300f; // 5 minutos

    private float tiempoActual;

    void Start()
    {
        tiempoActual = tiempoInicial;
        ActualizarHUD();
    }

    //actualiza el paso del tiempo
    void Update()
    {
        if (tiempoActual > 0)
        {
            tiempoActual -= Time.deltaTime;
            if (tiempoActual < 0) tiempoActual = 0;
            ActualizarHUD();
        }
    }
       

    void ActualizarHUD()
    {
        //conversion de segundos en minutos/segundos
        int minutos = Mathf.FloorToInt(tiempoActual / 60);
        int segundos = Mathf.FloorToInt(tiempoActual % 60);
        miTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    //método para restar tiempo por penalizaciòn
    public void RestarTiempo(float segundos)
    {
        tiempoActual -= segundos;
        if (tiempoActual < 0) tiempoActual = 0;
        ActualizarHUD();
    }
}