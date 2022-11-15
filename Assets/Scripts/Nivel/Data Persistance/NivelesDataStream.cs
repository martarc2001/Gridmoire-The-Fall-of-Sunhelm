using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class NivelesDataStream : MonoBehaviour
{
    private ListaLevelSerializable lls = new ListaLevelSerializable();

    // Start is called before the first frame update
    void Start()
    {
        StreamReader lector = new StreamReader("Assets/Data/Niveles.json");

        string jsonString = lector.ReadToEnd();

        Debug.Log(jsonString);

        if (!string.IsNullOrEmpty(jsonString))
        {
            lls = JsonUtility.FromJson<ListaLevelSerializable>(jsonString);

            Debug.Log(lls.list.Count);

            foreach(var sl in lls.list)
            {
                Debug.Log(sl.id);
                Debug.Log(sl.nombre);
                Debug.Log(sl.estado);
            }
        }
    }

    public List<SerializableLevel> GetLista()
    {
        return this.lls.list;
    }
}
