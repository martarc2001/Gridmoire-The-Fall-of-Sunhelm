using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuestraAdmins : MonoBehaviour
{
    [SerializeField] GameObject prefabNombre;

    [SerializeField] GameObject textoVacio;

    private void OnEnable()
    {
        if(Requisitos.listaAdmin.list.Count > 0)
        {
            Debug.Log(Requisitos.listaAdmin.list.Count);
            textoVacio.SetActive(false);

            foreach (SerializableAdmin admin in Requisitos.listaAdmin.list)
            {
                var nuevoAdmin = Instantiate(prefabNombre, transform);

                nuevoAdmin.GetComponent<TextMeshProUGUI>().text = admin.nombre;

                nuevoAdmin.gameObject.SetActive(true);
            }
        } else
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
