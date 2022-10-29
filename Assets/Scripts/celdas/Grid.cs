using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    #region Atributos
    // ATRIBUTOS

    private int M;

    private Celda[,] grid;
    
    #endregion

    #region Constructor
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
    
    #endregion

    // GETTERS & SETTERS
    #region Getters & Setters
    public Celda[,] GetCeldas() { return this.grid; }

    public void SetCeldas(Celda[,] grid) { this.grid = grid; }

    public void addCelda(int x, int y, Celda celda) { grid[x, y] = celda; }
    #endregion
    // METODOS
    #region Methods
    public bool IsOccupied(int x, int y) { return this.grid[x,y].IsOccupied(); }

    public Celda[] getRow(int x)
    {
        var celdas = new Celda[3];
        for(int i = 0; i < grid.GetLength(1); i++)
        {
            celdas[i] = grid[x,i];
        }

        return celdas;
    }

    public Celda[] getColumn(int y)
    {
        var celdas = new Celda[3];
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            celdas[i] = grid[i, y];
        }

        return celdas;
    }
    #endregion;
}
