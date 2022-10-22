using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Celda
{
    // ATRIBUTOS

    private int x;
    private int y;

    private GameObject personaje;
    private bool occupied = false;

    // GETTERS & SETTERS

    public int GetX() { return this.x; }
    public int GetY() { return this.y; }
    public GameObject GetPersonaje() { return this.personaje; }
    public bool IsOccupied() { return this.occupied; }

    public void SetX(int x) { this.x = x; }
    public void SetY(int y) { this.y = y; }
    public void SetPersonaje(GameObject personaje) { this.personaje = personaje; }
    public void ChangeOccupied() { this.occupied = !this.occupied; }

}
