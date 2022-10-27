using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    // ATRIBUTOS

    private int M;

    private Celda[,] grid;

    // CNSTRUCTORS

    public Grid() {}

    public Grid(int m = 3)
    {
        this.M = m;
        this.grid = new Celda[m, m];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                this.grid[i, j] = new Celda(i, j);
            }
        }
    }

    // GETTERS & SETTERS

    public Celda[,] GetCeldas() { return this.grid; }

    public void SetCeldas(Celda[,] grid) { this.grid = grid; }

    // METODOS

    public bool IsOccupied(int x, int y) { return this.grid[x,y].IsOccupied(); }
}
