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
    [SerializeField] TMP_InputField inputContrase�a;
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

        if (inputNombre.text != null && inputContrase�a.text != null)
        {
            invalidoCreacion.SetActive(false);

            var nombre = inputNombre.text;
            var contrase�a = inputContrase�a.text;

            SerializableAdmin nuevoAdmin = new SerializableAdmin(nombre, contrase�a);

            if (!listaAdmin.list.Contains(nuevoAdmin)) // Esto en realidad no funciona, pero deber�a ser algo as�. Yo creoque podemos ir 1 por 1 mirando, que nos saca del paso
            {
                listaAdmin.list.Add(nuevoAdmin);

                PlayerPrefs.SetString("Admins", JsonUtility.ToJson(listaAdmin));

                invalidoCreacion.GetComponent<TextMeshProUGUI>().text = "�Cuenta creada!";
                invalidoCreacion.SetActive(true);

            } else
            {
                invalidoCreacion.GetComponent<TextMeshProUGUI>().text = "Nombre de Usuario o contrase�a no v�lidos, por favor, introduzcalos de nuevo.";
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
        // Hay que ver como cogemos el admin al que pulsamos y eliminarlo de la lista. Pero eso ya lo ten�a hecho Dani para Gridmoire.
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


