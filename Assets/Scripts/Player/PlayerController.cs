using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Personaje personaje;

    private void Start()
    {
        personaje = new Personaje();
    }

    public Personaje getPersonaje() { return personaje; }

    public void setPersonaje(Personaje personaje) { this.personaje = personaje; }
}
