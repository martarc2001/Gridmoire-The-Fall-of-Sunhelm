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
        item.id = text - '0';
        item.comentario = transform.Find("com").GetComponent<TextMeshProUGUI>().text;
        item.motivo = transform.Find("mot").GetComponent<TextMeshProUGUI>().text;
        item.perdonado = true;
        Requisitos.listaReporte.list.Remove(item);
        Requisitos.listaTotalReportes.list.Add(item);

        Destroy(gameObject);
    }

    public void mantenerBan()
    {
        var item = new SerializableReporte();
        var text = transform.Find("id").GetComponent<TextMeshProUGUI>().text[4];
        item.id = text - '0';
        item.comentario = transform.Find("com").GetComponent<TextMeshProUGUI>().text;
        item.motivo = transform.Find("mot").GetComponent<TextMeshProUGUI>().text;
        item.perdonado = false;
        Requisitos.listaReporte.list.Remove(item);
        Requisitos.listaTotalReportes.list.Add(item);

        Destroy(gameObject);
    }
}
