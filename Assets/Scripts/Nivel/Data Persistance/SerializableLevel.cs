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
    public int id;
    public string nombre;
    public Estado estado;

    public List<SerializablePlayer> enemigos; // en un furturo será de la clase enemigo

    public int monedas;
    public int xp;


    public SerializableLevel() { }

    public SerializableLevel(int id, string nombre, Estado estado, List<SerializablePlayer> enemigos, int monedas, int xp)
    {
        this.id = id;
        this.nombre = nombre;
        this.estado = estado;
        this.enemigos = enemigos;
        this.monedas = monedas;
        this.xp = xp;
    }

    //public int GetId() { return id; }
    //public string GetNombre() { return this.nombre; }
    //public Estado GetEstado() { return this.estado; }

}
