using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Celda
{
    // ATRIBUTOS
    #region Atributos
    private int x;
    private int y;

    private Personaje personaje;
    private bool occupied = false;
    #endregion


    #region Constructores
    // DEFAULT CONSTRUCTOR
    
    public Celda()
    {
        x = 0;
        y = 0;
        personaje = null;
    }

    // PARAMETERIZED CONSTRUCTOR

    public Celda(int x, int y)
    {
        this.x = x;
        this.y = y;
        personaje = null;
    }
    #endregion

    // GETTERS & SETTERS
    #region Getters & Setters
    public int GetX() { return this.x; }
    public int GetY() { return this.y; }
    public Personaje GetPersonaje() { return this.personaje; }
    public bool IsOccupied() { return this.occupied; }

    public void SetX(int x) { this.x = x; }
    public void SetY(int y) { this.y = y; }
    public void SetPersonaje(GameObject personaje) 
    { 
        this.personaje = personaje;
        Debug.Log(this.personaje);
    }
    public void ChangeOccupied() { this.occupied = !this.occupied; }
    #endregion
}
