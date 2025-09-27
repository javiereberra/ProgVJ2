using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;

    public PerfilJugador PerfilJugador { get => perfilJugador; }

    [Header("Configuracion")] 

    [SerializeField]
    private UnityEvent<float> OnLivesChanged;
    [SerializeField] 
    private UnityEvent<int> OnDiamantesChanged;
    [SerializeField]
    private UnityEvent<int> OnNivelChanged;


    [SerializeField]
    private UnityEvent<string> OnTextChanged;
    [SerializeField]
    private UnityEvent<string> OnDiamantesTextChanged;
    [SerializeField]
    private UnityEvent<string> OnNivelTextChanged;

    [SerializeField] private GameManager gameManager; //referencia a GameManager

    
    //inventario simple de llaves
    public List<int> llaves = new List<int>();

    private void Start()
    {
        OnLivesChanged.Invoke(perfilJugador.Vida);
        OnTextChanged.Invoke("Vidas: " + perfilJugador.Vida.ToString("0"));
        OnDiamantesChanged.Invoke(perfilJugador.Diamantes);
        OnDiamantesTextChanged.Invoke("Diamantes: " +perfilJugador.Diamantes.ToString("0"));
        OnNivelChanged.Invoke(perfilJugador.Nivel);
        OnNivelTextChanged.Invoke("Nivel: " + perfilJugador.Nivel.ToString("0"));


    }

    public void AgregarDiamante(int cantidad)
    {
        perfilJugador.Diamantes += cantidad;
        OnDiamantesChanged.Invoke(perfilJugador.Diamantes);         
        OnDiamantesTextChanged.Invoke("Diamantes: " + perfilJugador.Diamantes);

    }

    public void SubirNivel(int cantidad)
    {
        perfilJugador.Nivel += cantidad;
        OnNivelChanged.Invoke(perfilJugador.Nivel);
        OnNivelTextChanged.Invoke("Nivel: " + perfilJugador.Nivel);

    }

    public void ModificarVida(float puntos)
    {
        perfilJugador.Vida += puntos;
        Debug.Log("Modificando vida: " + puntos + " | Vida actual: " + perfilJugador.Vida);
        OnLivesChanged.Invoke(perfilJugador.Vida);
        OnTextChanged.Invoke("Vidas: " + perfilJugador.Vida.ToString("0"));

        if (puntos < 0 && gameManager != null)
        {
            gameManager.RestarTiempo(Mathf.Abs(puntos) * 10f);
        }

        Debug.Log(EstasVivo());
    }


    private bool EstasVivo()
    {
        return perfilJugador.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("GANASTE");

        //pasar siguiente escena
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceEscenaActual + 1);
    }

    //método para agregar llaves
    public void AgregarLlave(int idLlave)
    {
        if (!llaves.Contains(idLlave))
        {
            llaves.Add(idLlave);
            Debug.Log($"Jugador: agregó llave {idLlave}. Llaves: {string.Join(",", llaves)}");
        }
        else
        {
            Debug.Log($"Jugador: ya tiene la llave {idLlave}");
        }
    }

    // Consultar si tiene una llave
    public bool TieneLlave(int idLlave)
    {
        return llaves.Contains(idLlave);
    }

   

}