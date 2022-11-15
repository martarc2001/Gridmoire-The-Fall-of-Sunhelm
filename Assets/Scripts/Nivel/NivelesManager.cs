using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelesManager : MonoBehaviour
{
    // Atributos

    [SerializeField] private NivelesDataStream nivelesDS;
    [SerializeField] private List<SerializableLevel> niveles;


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
    }
    
    
}
