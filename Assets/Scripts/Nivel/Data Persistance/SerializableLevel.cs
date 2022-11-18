using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class ListaLevelSerializable
{
    public List<SerializableLevel> list = new List<SerializableLevel>();
}

[Serializable]
public class SerializableLevel
{
    public int mundo;
    public int id;
    public string nombre;

    public List<int> enemigos; // en un furturo será de la clase enemigo

    public int monedas;
    public int xp;


    public SerializableLevel() { }

    public SerializableLevel(int mundo, int id, string nombre, List<int> enemigos, int monedas, int xp)
    {
        this.mundo = mundo;
        this.id = id;
        this.nombre = nombre;
        this.enemigos = enemigos;
        this.monedas = monedas;
        this.xp = xp;
    }
}
