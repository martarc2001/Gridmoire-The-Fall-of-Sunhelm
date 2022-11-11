using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class ListaLevelSerializable
{
    public List<SerializableLevel> list= new List<SerializableLevel>();
}

[Serializable]
public class SerializableLevel
{
    private int id;
    private string nombre;
    private Estado estado;

    private List<Personaje> enemigos; // en un furturo será de la clase enemigo

    private int monedas;
    private int xp;

    public SerializableLevel() { }

    public SerializableLevel(int id, string nombre, Estado estado, List<Personaje> enemigos, int monedas, int xp)
    {
        this.id = id;
        this.nombre = nombre;
        this.estado = estado;
        this.enemigos = enemigos;
        this.monedas = monedas;
        this.xp = xp;
    }
}
