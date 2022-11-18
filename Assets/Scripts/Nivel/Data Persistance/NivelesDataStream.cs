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

    private string nivelesJson = "{\"list\": [{\"mundo\": 1,\"id\": 1,\"nombre\": \"Patata\",\"enemigos\": [0, 0, 0],\"monedas\": 30,\"xp\": 1500},{\"mundo\": 1,\"id\": 2,\"nombre\": \"Zanahoria\",\"enemigos\": [0, 0, 0],\"monedas\": 20,\"xp\": 20},{\"mundo\": 1,\"id\": 3,\"nombre\": \"Puerro\",\"estado\": 2,\"enemigos\": [0, 1, 0],\"monedas\": 10,\"xp\": 10}]}";

    private ListaLevelSerializable lls = new ListaLevelSerializable();

    // Start is called before the first frame update

    public List<SerializableLevel> ObtenerLista()
    {
        if (!string.IsNullOrEmpty(nivelesJson))
        {
            lls = JsonUtility.FromJson<ListaLevelSerializable>(nivelesJson);
        }

        return this.lls.list;
    }
}
