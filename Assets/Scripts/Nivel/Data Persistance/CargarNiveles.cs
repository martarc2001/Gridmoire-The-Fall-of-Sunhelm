using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CargarNiveles : MonoBehaviour
{
    private ListaLevelSerializable lls = new ListaLevelSerializable();
    [SerializeField] private GameObject llsPrefab;

    [SerializeField] private List<int> ids;
    [SerializeField] private List<string> nombres;
    [SerializeField] private List<Estado> estados;
    [SerializeField] private List<List<Personaje>> listasEnemigos;
    [SerializeField] private List<int> monedas;
    [SerializeField] private List<int> experiencias;

    // Start is called before the first frame update
    void Start()
    {
        string json = PlayerPrefs.GetString("ejercito");

        if (!string.IsNullOrEmpty(json))
        {
            lls = JsonUtility.FromJson<ListaLevelSerializable>(json);
        }
    }

    public List<SerializableLevel> GetLista()
    {
        return this.lls.list;
    }
}
