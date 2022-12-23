using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CambiarBaneo : MonoBehaviour
{
    
    public void quitarBan()
    {
        var item = new SerializableReporte();
        var text = transform.Find("id").GetComponent<TextMeshProUGUI>().text[4];
        foreach(var reporte in Requisitos.listaReporte.list)
        {
            if(reporte.id == (text - '0'))
            {
                item = reporte;
            }
        }
        Requisitos.listaReporte.list.Remove(item);

        foreach(var reporte in Requisitos.listaTotalReportes.list)
        {
            if (reporte.id == item.id)
            {
                reporte.perdonado = true;
            }
        }
        //Requisitos.listaTotalReportes.list.Add(item);

        PlayerPrefs.SetString("Reportes", JsonUtility.ToJson(Requisitos.listaReporte));
        PlayerPrefs.SetString("ReportesTodos", JsonUtility.ToJson(Requisitos.listaTotalReportes));

        Destroy(gameObject);
    }

    public void mantenerBan()
    {
        var item = new SerializableReporte();
        var text = transform.Find("id").GetComponent<TextMeshProUGUI>().text[4];
        foreach (var reporte in Requisitos.listaReporte.list)
        {
            if (reporte.id == (text - '0'))
            {
                item = reporte;
            }
        }
        Requisitos.listaReporte.list.Remove(item);

        foreach (var reporte in Requisitos.listaTotalReportes.list)
        {
            if (reporte.id == item.id)
            {
                reporte.perdonado = false;
            }
        }

        PlayerPrefs.SetString("Reportes", JsonUtility.ToJson(Requisitos.listaReporte));
        PlayerPrefs.SetString("ReportesTodos", JsonUtility.ToJson(Requisitos.listaTotalReportes));

        Debug.Log(PlayerPrefs.GetString("Reportes"));
        Destroy(gameObject);
    }
}
