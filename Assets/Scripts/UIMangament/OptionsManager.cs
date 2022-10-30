using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public GameObject opciones;

    public List<Button> botones;
    //public Button botonOpciones;
    //public Button botonJuego;
    //public Button botonTienda;
    //public Button botonCreditos;

    public void abreOpciones()
    {
        opciones.SetActive(true);

        foreach(Button boton in botones)
        {
            boton.enabled = false;
;       }
        //botonOpciones.enabled = false;
        //botonJuego.enabled = false;
        //botonTienda.enabled = false;
        //botonCreditos.enabled = false;
    }

    public void cierraOpciones()
    {
        opciones.SetActive(false);

        foreach (Button boton in botones)
        {
            boton.enabled = true;
;
        }
        //botonOpciones.enabled = true;
        //botonJuego.enabled = true;
        //botonTienda.enabled = true;
        //botonCreditos.enabled = true;
    }
}
