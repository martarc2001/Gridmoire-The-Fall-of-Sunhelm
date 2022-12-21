using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonBorrar : MonoBehaviour
{


    public void BorrarAdmin(SerializableAdmin admin, GameObject nuevoAdmin)
    {
        Requisitos.listaAdmin.list.Remove(admin);

        string json = JsonUtility.ToJson(Requisitos.listaAdmin);

        PlayerPrefs.SetString("Admins", json);

        Destroy(nuevoAdmin);
        Destroy(gameObject);
    }
}
