using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public GameObject opciones;

    public List<Button> botones;

    //
    public void abreOpciones()
    {
        opciones.SetActive(true);

        foreach(Button boton in botones)
        {
            boton.enabled = false;
        }
    }

    public void cierraOpciones()
    {
        opciones.SetActive(false);

        foreach (Button boton in botones)
        {
            boton.enabled = true;
        }
    }
}
