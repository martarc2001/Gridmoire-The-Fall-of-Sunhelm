using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    // ATRIBUTOS

    private Celda[,] grid = new Celda[3,3];

    // GETTERS & SETTERS

    public Celda[,] GetCeldas() { return this.grid; }

    public void SetCeldas(Celda[,] grid) { this.grid = grid; }

    // METODOS

    public bool IsOccupied(int x, int y) { return this.grid[x,y].IsOccupied(); }
}
