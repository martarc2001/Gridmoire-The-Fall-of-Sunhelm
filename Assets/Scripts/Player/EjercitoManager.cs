using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercitoManager : MonoBehaviour
{
    private List<GameObject> personajes = new List<GameObject>();
    
    // GETTERS & SETTERS

    public List<GameObject> GetEjercito() { return this.personajes; }

    public void SetEjercito(List<GameObject> lista) { this.personajes = lista; }
    
    // METODOS

    public void AddPersonaje(GameObject personaje) { this.personajes.Add(personaje); }
}
