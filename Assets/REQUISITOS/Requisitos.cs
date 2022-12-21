using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Requisitos : MonoBehaviour
{
    private string AdminJson = "{\"list\":[]}";
    private string ReporteJson = "{\"list\":[{\"id\": 1,\"motivo\":\"Imcumplimiento de la regla 420\",\"comentario\":\"Quitame el ban\"},{\"id\":2,\"motivo\":\"Spam en el chat\",\"comentario\":\"me lo merezco\"},{\"id\":3,\"motivo\":\"Lenguaje inapropiado\",\"comentario\":\"me llama a mi sin ser nada de eso yo\"}]}";

    static public ListaAdminSerializable listaAdmin = new ListaAdminSerializable();
    static public ListaReporteSerializable listaReporte = new ListaReporteSerializable();
    static public ListaReporteSerializable listaTotalReportes = new ListaReporteSerializable();

    [Header("Mostrar Admins")]
    [SerializeField] GameObject areaListarAdmins;
    [SerializeField] GameObject areaAEscribirAdmins;

    [Header("Crear Admin")]
    [SerializeField] GameObject menuCreacion;
    [SerializeField] TMP_InputField inputNombre;
    [SerializeField] TMP_InputField inputContraseña;
    public GameObject invalidoCreacion;

    [Header("Borrar Admin")]
    [SerializeField] GameObject menuBorrado;
    public GameObject textoBoton;
    public GameObject textoNoAdmins;

    [Header("Historial Reportes")]
    [SerializeField] GameObject menuHistorialReportes;

    [Header("Gestion Reportes")]
    [SerializeField] GameObject menuGestionReportes;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Admins"))
        {
            PlayerPrefs.SetString("Admins", AdminJson);
        } else
        {
            AdminJson = PlayerPrefs.GetString("Admins");

            listaAdmin = JsonUtility.FromJson<ListaAdminSerializable>(AdminJson);
        }

        if (!PlayerPrefs.HasKey("Reportes"))
        {
            
            PlayerPrefs.SetString("Reportes", ReporteJson);
        }
        else
        {
            ReporteJson = PlayerPrefs.GetString("Reportes");

            listaReporte = JsonUtility.FromJson<ListaReporteSerializable>(ReporteJson);
        }

        if (!PlayerPrefs.HasKey("ReportesTodos"))
        {
            PlayerPrefs.SetString("ReportesTodos", ReporteJson);
        }
        else
        {

            listaTotalReportes = JsonUtility.FromJson<ListaReporteSerializable>(PlayerPrefs.GetString("ReportesTodos"));
        }
    }

    public List<SerializableAdmin> ObtenerListaAdmin()
    {
        if (PlayerPrefs.HasKey("Admins"))
        {
            listaAdmin = JsonUtility.FromJson<ListaAdminSerializable>(PlayerPrefs.GetString("Admins"));
        } else
        {
            textoNoAdmins.SetActive(true);
        }
        return Requisitos.listaAdmin.list;
    }

    public List<SerializableReporte> ObtenerListaReporte()
    {
        if (!string.IsNullOrEmpty(ReporteJson))
        {
            listaReporte = JsonUtility.FromJson<ListaReporteSerializable>(ReporteJson);
        }
        return Requisitos.listaReporte.list;
    }

    public void AbrirMostrarAdmin()
    {
        areaListarAdmins.SetActive(true);
    }

    public void CerrarMostrarAdmins()
    {
        areaListarAdmins.SetActive(false);
    }

    public void CrearCuenta()
    {

        if (inputNombre.text != null && inputContraseña.text != null)
        {
            invalidoCreacion.SetActive(false);

            var nombre = inputNombre.text;
            var contraseña = inputContraseña.text;

            bool valido = true;
            int contador = 0;

            while (contador < listaAdmin.list.Count && valido)
            {
                valido = (nombre != listaAdmin.list[contador].nombre);
                contador++;
            }


            if (valido)
            {
                AdminJson = PlayerPrefs.GetString("Admins");

                listaAdmin = JsonUtility.FromJson<ListaAdminSerializable>(AdminJson);

                Debug.Log("Creado");
                SerializableAdmin nuevoAdmin = new SerializableAdmin(nombre, contraseña);
                listaAdmin.list.Add(nuevoAdmin);

                PlayerPrefs.SetString("Admins", JsonUtility.ToJson(listaAdmin));

                invalidoCreacion.GetComponent<TextMeshProUGUI>().text = "¡Cuenta creada!";
                invalidoCreacion.SetActive(true);

            } else
            {
                invalidoCreacion.GetComponent<TextMeshProUGUI>().text = "Ese nombre de usuario ya está en uso. Por favor, introduzca uno nuevo.";
                invalidoCreacion.SetActive(true);
            }
        } else
        {
            invalidoCreacion.GetComponent<TextMeshProUGUI>().text = "Por favor, rellene todos los campos.";
            invalidoCreacion.SetActive(true);
        }
    }

    public void AbrirCreacionCuenta()
    {
        menuCreacion.SetActive(true);
    }

    public void CerrarCreacionCuenta()
    {
        invalidoCreacion.SetActive(false);
        menuCreacion.SetActive(false);
    }

    public void AbrirBorradoCuenta()
    {
        menuBorrado.SetActive(true);
    }

    public void CerrarBorradoCuenta()
    {
        menuBorrado.SetActive(false);
    }

    public void AbrirHistorialReportes()
    {
        menuHistorialReportes.SetActive(true);
    }

    public void CerrarHistorialReportes()
    {
        menuHistorialReportes.SetActive(false);
    }

    public void AbrirGestionReportes()
    {
        listaReporte = JsonUtility.FromJson<ListaReporteSerializable>(PlayerPrefs.GetString("Reportes"));
        menuGestionReportes.SetActive(true);
    }

    public void CerrarGestionReportes()
    {
        menuGestionReportes.SetActive(false);
    }
}


