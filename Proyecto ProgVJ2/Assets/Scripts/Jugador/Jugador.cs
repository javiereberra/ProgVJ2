using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;

    [SerializeField]
    private UnityEvent<float> OnLivesChanged;

    [SerializeField]
    private UnityEvent<string> OnTextChanged;

    [SerializeField] private GameManager gameManager; //referencia a GameManager

    public int diamantes = 0;

    //inventario simple de llaves
    public List<int> llaves = new List<int>();

    private void Start()
    {
        OnLivesChanged.Invoke(vida);
        OnTextChanged.Invoke("Vidas: " + vida.ToString("0"));
    }


    public void ModificarVida(float puntos)
    {
        vida += puntos;
        Debug.Log("Modificando vida: " + puntos + " | Vida actual: " + vida);
        OnLivesChanged.Invoke(vida);
        OnTextChanged.Invoke("Vidas: " + vida.ToString("0"));

        if (puntos < 0 && gameManager != null)
        {
            gameManager.RestarTiempo(Mathf.Abs(puntos) * 10f);
        }

        Debug.Log(EstasVivo());
    }


    private bool EstasVivo()
    {
        return vida > 0;
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