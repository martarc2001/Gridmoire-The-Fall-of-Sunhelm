using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbreSesion : MonoBehaviour
{
    [SerializeField] GameObject canvasSesion;
    [SerializeField] List<Button> botones;
    public void abrirInicioSesion() 
    {
        canvasSesion.SetActive(true);

        foreach(var boton in botones) 
        {
            boton.enabled = false;
        }
    }

    public void cerrarInicioSesion() 
    {
        canvasSesion.SetActive(false);

        foreach (var boton in botones)
        {
            boton.enabled = true;
        }
    }

}
