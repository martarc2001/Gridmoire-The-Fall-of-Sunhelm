using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Requisitos : MonoBehaviour
{
    private string AdminJson = "{\"list\":[{\"nombre\":\"Admin1\"},{\"nombre\":\"Admin2\"},{\"nombre\":\"Admin3\"}]}";
    private string ReporteJson = "{\"list\":[{\"nombre\":\"Admin1\"}]}";

    private ListaAdminSerializable listaAdmin = new ListaAdminSerializable();
    private ListaReporteSerializable listaReporte = new ListaReporteSerializable();
    [SerializeField] GameObject areaListarAdmins;
    [SerializeField] GameObject areaAEscribirAdmins;
    [SerializeField] GameObject textoModificableListarAdmins;
    public GameObject textoBoton;
    public List<SerializableAdmin> ObtenerListaAdmin()
    {
        if (!string.IsNullOrEmpty(AdminJson))
        {
            listaAdmin = JsonUtility.FromJson<ListaAdminSerializable>(AdminJson);
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

    public void BorrarAdmin()
    {
        Destroy(this.transform.parent.gameObject);
    }

}


