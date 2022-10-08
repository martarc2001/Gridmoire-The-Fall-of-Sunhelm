using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameFlow : MonoBehaviour
{
    public GameObject opciones;
    public Button botonOpciones;
    public Button botonJuego;
    public Button botonCreditos;

    public Button volverOpciones;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void iniciaPartida()
    {
        SceneManager.LoadScene("Juego");
    }

    public void abreOpciones()
    {
        opciones.SetActive(true);

        botonOpciones.enabled = false;
        botonJuego.enabled = false;
        botonCreditos.enabled = false;
    }

    public void cierraOpciones()
    {
        

        opciones.SetActive(false);

        botonOpciones.enabled = true;
        botonJuego.enabled = true;
        botonCreditos.enabled = true;
    }

    public void abreTienda()
    {
        SceneManager.LoadScene("Compritas");
    }

    public void abreCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
