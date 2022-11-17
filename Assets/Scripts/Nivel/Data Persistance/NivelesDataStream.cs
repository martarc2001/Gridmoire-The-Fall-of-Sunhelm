using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class NivelesDataStream : MonoBehaviour
{

    private string nivelesJson = "{\"list\": [{\"mundo\": 1,\"id\": 1,\"nombre\": \"Patata\",\"enemigos\": [0, 1, 2],\"monedas\": 30,\"xp\": 30},{\"mundo\": 1,\"id\": 2,\"nombre\": \"Zanahoria\",\"enemigos\": [0, 1, 2],\"monedas\": 20,\"xp\": 20},{\"mundo\": 1,\"id\": 3,\"nombre\": \"Puerro\",\"estado\": 2,\"enemigos\": [0, 1, 2],\"monedas\": 10,\"xp\": 10}]}";

    private ListaLevelSerializable lls = new ListaLevelSerializable();

    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrEmpty(nivelesJson))
        {
            lls = JsonUtility.FromJson<ListaLevelSerializable>(nivelesJson);

            foreach (var sl in lls.list)
            {
                Debug.Log(sl.id);
                Debug.Log(sl.nombre);
            }
        }
    }

    public List<SerializableLevel> GetLista()
    {
        return this.lls.list;
    }
}
