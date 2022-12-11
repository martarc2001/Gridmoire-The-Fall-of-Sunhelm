using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenderManager : MonoBehaviour
{
    // ATRIBUTOS

    [Header("Continuación")]
    [SerializeField] private GameObject eleccion;
    [SerializeField] private GameObject continuar;

    private int genero;


    // GETTERS & SETTERS
    public int GetGenero() { return this.genero; }
    public void SetGenero(int genero) { this.genero = genero; }


    // METODOS
    public void cambiaGenero(int genero)
    {
        this.SetGenero(genero);

        var textoEleccion = eleccion.GetComponent<TextMeshPro>();

        switch (genero)
        {
            case 0:
                textoEleccion.text = "¡Genial! Eres Él.";
                break;
            case 1:
                textoEleccion.text = "¡Genial! Eres Ella.";
                break;
            case 2:
                textoEleccion.text = "¡Genial! Eres Elle.";
                break;
            default:
                break;
        }

        eleccion.SetActive(true);

        continuar.SetActive(true);
    }

    public void GuardaGenero()
    {
        PlayerPrefs.SetInt("Genero", this.genero);

        PlayerPrefs.Save();
    }
}
