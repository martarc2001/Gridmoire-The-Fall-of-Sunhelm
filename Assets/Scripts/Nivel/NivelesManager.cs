using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NivelesManager : MonoBehaviour
{
    // Atributos

    [SerializeField] private NivelesDataStream nivelesDS;
    [SerializeField] private List<SerializableLevel> niveles;

    private int seleccion = 0;

    [SerializeField] private GameObject infoNivel;


    // GETTERS & SETTERS

    public NivelesDataStream GetNivelesDS() { return this.nivelesDS; }
    public List<SerializableLevel> GetNiveles() { return this.niveles; }
    public int GetSeleccion() { return this.seleccion; }

    public void SetNivelesDS(NivelesDataStream nivelesDS) { this.nivelesDS = nivelesDS; }
    public void SetNiveles(List<SerializableLevel> niveles) { this.niveles = niveles; }
    public void SetSeleccion(int seleccion) { this.seleccion = seleccion - 1; }


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
        niveles = nivelesDS.ObtenerLista();
    }
    
    public void ActivaInfo(int idx)
    {
        SetSeleccion(idx);
        RellenaInfo();
        infoNivel.SetActive(true);
    }

    public void DesactivaInfo()
    {
        infoNivel.SetActive(false);
    }

    private void RellenaInfo()
    {
        SerializableLevel sl = niveles[this.seleccion];

        var mundo = infoNivel.transform.Find("Mundo");
        var id = infoNivel.transform.Find("ID");
        var nombre = infoNivel.transform.Find("Nombre");

        mundo.GetComponent<TextMeshProUGUI>().SetText("Mundo: " + sl.mundo);
        id.GetComponent<TextMeshProUGUI>().SetText("ID: " + sl.id);
        nombre.GetComponent<TextMeshProUGUI>().SetText("Nombre: " + sl.nombre);
    }
}
