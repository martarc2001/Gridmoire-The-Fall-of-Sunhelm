using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager
{
    // ATRIBUTOS
    private List<Personaje> ejercito = new List<Personaje>();
    private readonly int FACTOR_ALEATORIEDAD = 2;               // 20% de probabilidad de no coger la mejor opción

    // GETTERS & SETTERS
    public List<Personaje> GetEjercito() { return this.ejercito; }
    public void SetEjercito(List<Personaje> ejercito) { this.ejercito = ejercito; }

    // METODOS

    public void ConsigueEjercito(Grid grid)
    {
        Celda[,] celdas = grid.GetCeldas();

        for (int i = 0; i < celdas.GetLength(0); i++)
        {
            for (int j = 0; j < celdas.GetLength(1); i++)
            {
                if (celdas[i, j].IsOccupied())
                {
                    ejercito.Add(celdas[i, j].GetPersonaje());
                }
            }
        }
    }

    public int[] CompruebaSingle(Grid gridEnemigo)
    {
        int[] objetivo = new int[2];
        float PeorVida = Mathf.Infinity;

        for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(0); i++)
        {
            for (int j = 0; j < gridEnemigo.GetCeldas().GetLength(1); i++)
            {
                if (gridEnemigo.GetCeldas()[i, j].IsOccupied())
                {
                    var accionAleatoria = Random.Range(1, 10);
                    if(gridEnemigo.GetCeldas()[i, j].GetPersonaje().GetVida() <= PeorVida && accionAleatoria > FACTOR_ALEATORIEDAD)
                    {
                        objetivo = new int[] {i, j};
                    }
                }
            }
        }

        return objetivo;
    }

    public void Atacar(Grid gridEnemigo, Personaje personaje)
    {
        switch (personaje.GetTipoAtaque())
        {
            case TipoAtaque.GRID:
                // Invocar ataque grid
                break;
            case TipoAtaque.SINGLE:
                int[] objetivo = CompruebaSingle(gridEnemigo);
                // Invocar ataque single
                break;
            case TipoAtaque.COLUMN:

                // Invocar ataque column
                break;
            case TipoAtaque.ROW:

                // Invocar ataque row
                break;
            case TipoAtaque.HEAL:

                // Invocar ataque heal
                break;
            default:
                break;
        }
    }

    public void RealizarTurno(Grid gridEnemigo)
    {
        foreach (Personaje personaje in this.ejercito)
        {
            Atacar(gridEnemigo, personaje);
        }
    }
}
