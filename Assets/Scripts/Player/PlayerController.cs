using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Personaje personaje;
    public Personaje getPersonaje() { return personaje; }

    public void setPersonaje(Personaje personaje) { this.personaje = personaje; }

}
