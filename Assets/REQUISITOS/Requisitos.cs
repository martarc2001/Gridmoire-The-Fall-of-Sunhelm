using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Requisitos : MonoBehaviour
{
    private string AdminJson = "{\"list\":[{\"nombre\":\"Admin1\"}]}";
    private string ReporteJson = "{\"list\":[{\"nombre\":\"Admin1\"}]}";

    private ListaAdminSerializable listaAdmin = new ListaAdminSerializable();
    private ListaReporteSerializable listaReporte = new ListaReporteSerializable();

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
        Debug.Log(ObtenerListaAdmin().ToString());
    }
}


