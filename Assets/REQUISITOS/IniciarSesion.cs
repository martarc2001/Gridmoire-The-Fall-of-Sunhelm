using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IniciarSesion : MonoBehaviour
{
    [SerializeField] SceneLoader loaderScript;

    [Header("Input inicio sesion")]
    [SerializeField] private TMP_InputField nombre;
    [SerializeField] private TMP_InputField pass;

    public void iniciarSesion()
    {
        var name = nombre.text;
        var password = pass.text;

        if(name.Equals("admin") && password.Equals("1234"))
        {
            loaderScript.LoadScene("Requisito");
        }
    }
}
