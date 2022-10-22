using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercitoManager : MonoBehaviour
{
    private List<Personaje> personajes = new List<Personaje>();

    // GETTERS & SETTERS

    public List<Personaje> GetEjercito() { return this.personajes; }

    public void SetEjercito(List<Personaje> lista) { this.personajes = lista; }
    
    // METODOS

    public void AddPersonaje(Personaje personaje) { this.personajes.Add(personaje); }
}
