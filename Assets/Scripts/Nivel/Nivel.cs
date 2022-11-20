using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel
{
    // Variables

    private int id;
    private string nombre;
    private Estado estado;

    private List<Personaje> enemigos; // en un furturo será de la clase enemigo

    private int monedas;
    private int xp;


    // Constructores

    public Nivel(){}

    public Nivel(int id, string nombre, Estado estado, List<Personaje> enemigos, int monedas, int xp)
    {
        this.id = id;
        this.nombre = nombre;
        this.estado = estado;
        this.enemigos = enemigos;
        this.monedas = monedas;
        this.xp = xp;
    }


    // Getters y Setters

    public int GetID() { return this.id; }
    public string GetNombre() { return this.nombre; }
    public Estado GetEstado() { return this.estado; }
    public List<Personaje> GetEnemigos() { return this.enemigos; }
    public int GetMonedas() { return this.monedas; }
    public int GetXP() { return this.xp; }


    public void SetID(int id) { this.id = id; }
    public void SetNombre(string nombre) { this.nombre = nombre; }
    public void SetEstado(Estado estado) { this.estado = estado; }
    public void SetEnemigo(List<Personaje> enemigos) { this.enemigos = enemigos; }
    public void SetMonedas(int monedas) { this.monedas = monedas; }
    public void SetXP(int xp) { this.xp = xp; }
}

[Serializable]
public enum Estado
{
    BLOQUEADO, NO_JUGADO, JUGADO
}