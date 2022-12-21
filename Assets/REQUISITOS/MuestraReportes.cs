using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuestraReportes : MonoBehaviour
{
    [SerializeField] GameObject prefabNombre;

    [SerializeField] GameObject textoVacio;

    private void OnEnable()
    {
        if (Requisitos.listaReporte.list.Count > 0)
        {
            textoVacio.SetActive(false);

            foreach (SerializableReporte reporte in Requisitos.listaReporte.list)
            {
                var nuevoReporte = Instantiate(prefabNombre, transform);

                nuevoReporte.transform.Find("id").GetComponent<TextMeshProUGUI>().text = "ID: " + reporte.id;
                nuevoReporte.transform.Find("com").GetComponent<TextMeshProUGUI>().text = "Descripcion: " + reporte.motivo;
                nuevoReporte.transform.Find("mot").GetComponent<TextMeshProUGUI>().text = "Comentario: " + reporte.comentario;
                if (reporte.perdonado)
                {
                    nuevoReporte.transform.Find("Estado").GetComponent<TextMeshProUGUI>().text = "Estado: Perdonado";
                } else
                {
                    nuevoReporte.transform.Find("Estado").GetComponent<TextMeshProUGUI>().text = "Estado: Banneado";
                }
                
                nuevoReporte.gameObject.SetActive(true);
            }
        }
        else
        {
            textoVacio.SetActive(true);
        }
    }

    private void OnDisable()
    {
        int childs = transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }
}
