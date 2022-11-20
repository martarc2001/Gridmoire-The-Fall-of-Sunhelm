using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercitoRecompensa : MonoBehaviour
{

    [SerializeField] private List<Personaje> recompensados = new List<Personaje>();

    public List<Personaje> getNombres() { return recompensados; }

    public void AddPersonaje(Personaje recompensado) { this.recompensados.Add(recompensado); }
}
