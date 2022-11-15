using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NivelesManager : MonoBehaviour
{
    // Atributos

    [SerializeField] private NivelesDataStream nivelesDS;
    [SerializeField] private List<SerializableLevel> niveles;

    [SerializeField] private GameObject infoNivel;


    // GETTERS & SETTERS

    public NivelesDataStream GetNivelesDS() { return this.nivelesDS; }
    public List<SerializableLevel> GetNiveles() { return this.niveles; }

    public void SetNivelesDS(NivelesDataStream nivelesDS) { this.nivelesDS = nivelesDS; }
    public void SetNiveles(List<SerializableLevel> niveles) { this.niveles = niveles; }


    // CONSTRUCTORES

    public NivelesManager() { }
    public NivelesManager(NivelesDataStream nivelesDS, List<SerializableLevel> niveles)
    {
        this.nivelesDS = nivelesDS;
        this.niveles = niveles;
    }

    // Start is called before the first frame update
    void Start()
    {
        while (nivelesDS.GetLista().Count == 0) { }
        niveles = nivelesDS.GetLista();

        RellenaInfo(niveles[0]);
    }
    
    public void RellenaInfo(SerializableLevel sl)
    {
        var id = infoNivel.transform.Find("ID");
        var nombre = infoNivel.transform.Find("Nombre");
        var estado = infoNivel.transform.Find("Estado");

        id.GetComponent<TextMeshProUGUI>().SetText("ID: " + sl.id);
        nombre.GetComponent<TextMeshProUGUI>().SetText("Nombre: " + sl.nombre);
        estado.GetComponent<TextMeshProUGUI>().SetText("Estado: " + sl.estado);
    }
}
