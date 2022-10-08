using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    public TMP_Dropdown menuResoluciones;
    Resolution[] resoluciones;


    private void Start()
    {
        resoluciones = Screen.resolutions;                  // Captamos las resoluciones posibles

        menuResoluciones.ClearOptions();                    // Nos aseguramos de que no haya opciones previas

        List<string> opciones = new List<string>();         // Creamos una lista de opciones
        int resActual = 0;                                  // Variable para guardar el indice de la opcion

        int i = 0;                                          // Indice del bucle
        foreach (Resolution res in resoluciones)
        {
            opciones.Add(res.width + " x " + res.height);   // Por cada resolución posible añadimos un string a la lista

            if(Screen.currentResolution.width == res.width && 
                Screen.currentResolution.height == res.height)
            {
                resActual = i;                              // Si la anchura y la altura es la actual, se almacena el índice de la opcon
            }

            i++;                                            // Aumentamos el contador
        }

        menuResoluciones.AddOptions(opciones);              // Añadimos las opciones al dropdown
        menuResoluciones.value = resActual;                 // Actualizamos el valor seleccionado
        menuResoluciones.RefreshShownValue();               // Refrescamos la UI
    }

    public void CambioResolucion(int resIdx)
    {
        Resolution resSelec = resoluciones[resIdx];                                 // Guardamos la resolucion seleccionada

        Screen.SetResolution(resSelec.width, resSelec.height, Screen.fullScreen);   // Ajustamos la pantalla a esa resolucion
    }

    public void CambioFullscreen(bool activo)
    {
        Screen.fullScreen = activo;
    }
}
