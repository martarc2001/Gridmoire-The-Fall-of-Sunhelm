using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Requisitos : MonoBehaviour
{
    private string AdminJson = "{\"list\":[]}";
    private string ReporteJson = "{\"list\":[]}";

    private ListaAdminSerializable listaAdmin = new ListaAdminSerializable();
    private ListaReporteSerializable listaReporte = new ListaReporteSerializable();

    [Header("Mostrar Admins")]
    [SerializeField] GameObject areaListarAdmins;
    [SerializeField] GameObject areaAEscribirAdmins;
    [SerializeField] GameObject textoModificableListarAdmins;

    [Header("Crear Admin")]
    [SerializeField] GameObject menuCreacion;
    [SerializeField] TMP_InputField inputNombre;
    [SerializeField] TMP_InputField inputContraseña;
    public GameObject invalidoCreacion;
    

    [Header("Borrar Admin")]
    [SerializeField] GameObject menuBorrado;

    public GameObject textoBoton;

    public GameObject textoNoAdmins;


    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Admins"))
        {
            PlayerPrefs.SetString("Admins", AdminJson);
        }

        if (!PlayerPrefs.HasKey("Reportes"))
        {
            PlayerPrefs.SetString("Reportes", ReporteJson);
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
        return this.listaAdmin.list;
    }

    public List<SerializableReporte> ObtenerListaReporte()
    {
        if (!string.IsNullOrEmpty(ReporteJson))
        {
            listaReporte = JsonUtility.FromJson<ListaReporteSerializable>(ReporteJson);
        }
        return this.listaReporte.list;
    }

    public void MostrarAdmin()
    {
        areaListarAdmins.SetActive(true);
        ObtenerListaAdmin();
        int n = -1;
        foreach (SerializableAdmin elemento in  listaAdmin.list)
        {
            //textoModificableListarAdmins.GetComponent<TMPro.TextMeshProUGUI>().text += elemento.ToString();
            GameObject newButton = Instantiate(textoBoton) as GameObject;
            newButton.transform.SetParent(areaAEscribirAdmins.transform, false);
            newButton.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(0, -n, 0), new Quaternion(0, 0, 0,0));
            newButton.GetComponent<TMPro.TextMeshProUGUI>().text += elemento.ToString();
            //newButton.transform.FindChild("nameOfChildObject").GetComponentInChildren<TMPro.TextMeshProUGUI>().text += elemento.ToString();
            n++;
        }

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

    public void BorrarCuenta()
    {
        // Hay que ver como cogemos el admin al que pulsamos y eliminarlo de la lista. Pero eso ya lo tenía hecho Dani para Gridmoire.
    }

    public void AbrirCreacionCuenta()
    {
        menuCreacion.SetActive(true);
    }

    public void CerrarCreacionCuenta()
    {
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

    public void CierraAdmins()
    {
        areaListarAdmins.SetActive(false);
    }

    public void BorrarAdmin()
    {
        Destroy(this.transform.parent.gameObject);
    }

}


