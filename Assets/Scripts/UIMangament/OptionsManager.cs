using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public GameObject opciones;
    public Button botonOpciones;
    public Button botonJuego;
    public Button botonTienda;
    public Button botonCreditos;

    //
    public void abreOpciones()
    {
        opciones.SetActive(true);

        botonOpciones.enabled = false;
        botonJuego.enabled = false;
        botonTienda.enabled = false;
        botonCreditos.enabled = false;
    }

    public void cierraOpciones()
    {
        opciones.SetActive(false);

        botonOpciones.enabled = true;
        botonJuego.enabled = true;
        botonTienda.enabled = true;
        botonCreditos.enabled = true;
    }
}
