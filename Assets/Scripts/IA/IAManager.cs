using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager
{
    // ATRIBUTOS

    private List<GameObject> ejercito = new List<GameObject>();
    private readonly int FACTOR_ALEATORIEDAD;

    // CONSTRUCTORS

    public IAManager() {}

    public IAManager(int factor = 2)
    {
        this.FACTOR_ALEATORIEDAD = factor;
    }

    // GETTERS & SETTERS

    public List<GameObject> GetEjercito() { return this.ejercito; }
    public void SetEjercito(List<GameObject> ejercito) { this.ejercito = ejercito; }

    // METODOS

    public void ConsigueEjercito(Grid grid)
    {
        Celda[,] celdas = grid.GetCeldas();

        for (int i = 0; i < celdas.GetLength(0); i++)
        {
            for (int j = 0; j < celdas.GetLength(1); j++)
            {
                if (celdas[i, j].IsOccupied())
                {
                    ejercito.Add(celdas[i, j].GetPersonaje());
                }
            }
        }
    }

    public Celda CompruebaSingle(Grid gridEnemigo)
    {
        Celda objetivo = new Celda();
        float PeorVida = Mathf.Infinity;

        for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(0); i++)
        {
            for (int j = 0; j < gridEnemigo.GetCeldas().GetLength(1); j++)
            {
                if (gridEnemigo.GetCeldas()[i, j].IsOccupied())
                {
                    var accionAleatoria = Random.Range(1, 10);

                    if(gridEnemigo.GetCeldas()[i, j].GetPersonaje().GetComponent<PlayerController>().getPersonaje().GetVida() <= PeorVida)
                    {
                        objetivo = gridEnemigo.GetCeldas()[i, j];
                    }
                }
            }
        }
        return objetivo;
    }

    public int CompruebaColumn(Grid gridEnemigo)
    {
        int columnaObj = 0;
        int nEnemigos = 0;
        int mejorColumna = 0;

        for (int j = 0; j < gridEnemigo.GetCeldas().GetLength(1); j++)
        {
            nEnemigos = 0;
            var accionAleatoria = Random.Range(1, 10);

            for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(0); i++)
            {
                if (gridEnemigo.GetCeldas()[i, j].IsOccupied())
                {
                    nEnemigos++;
                }
            }

            if (nEnemigos > mejorColumna)
            {
                mejorColumna = nEnemigos;
                columnaObj = j;
            }
        }

        return columnaObj;
    }

    public int CompruebaRow(Grid gridEnemigo)
    {
        int filaObj = 0;
        int nEnemigos = 0;
        int mejorFila = 0;

        for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(0); i++)
        {
            nEnemigos = 0;
            var accionAleatoria = Random.Range(1, 10);

            for (int j = 0; j < gridEnemigo.GetCeldas().GetLength(1); j++)
            {
                if (gridEnemigo.GetCeldas()[i, j].IsOccupied())
                {
                    nEnemigos++;
                }
            }

            if (nEnemigos > mejorFila)
            {
                mejorFila = nEnemigos;
                filaObj = i;
            }
        }

        return filaObj;
    }

    //public void AtaqueGrid(Grid gridEnemigo)
    //{
    //    for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(0); i++)
    //    {
    //        for (int j = 0; j < gridEnemigo.GetCeldas().GetLength(1); j++)
    //        {
    //            if (gridEnemigo.GetCeldas()[i, j].IsOccupied())
    //            {
    //                gridEnemigo
    //                    .GetCeldas()[i, j]
    //                    .GetPersonaje()
    //                    .SetVida(
    //                    gridEnemigo.GetCeldas()[i, j].GetPersonaje().GetVida() - 10);
    //            }
    //        }
    //    }
    //}

    //public void AtaqueSingle(Grid gridEnemigo, int[] pos)
    //{
    //    gridEnemigo
    //        .GetCeldas()[pos[0], pos[1]]
    //        .GetPersonaje()
    //        .SetVida(
    //        gridEnemigo.GetCeldas()[pos[0], pos[1]].GetPersonaje().GetVida() - 10);
    //}

    //public void AtaqueColumn(Grid gridEnemigo, int col)
    //{
    //    for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(0); i++)
    //    {
    //        if (gridEnemigo.GetCeldas()[i, col].IsOccupied())
    //        {
    //            gridEnemigo
    //                .GetCeldas()[i, col]
    //                .GetPersonaje()
    //                .SetVida(
    //                gridEnemigo.GetCeldas()[i, col].GetPersonaje().GetVida() - 10);
    //        }
    //    }
    //}

    //public void AtaqueRow(Grid gridEnemigo, int row)
    //{
    //    for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(1); i++)
    //    {
    //        if (gridEnemigo.GetCeldas()[row, i].IsOccupied())
    //        {
    //            gridEnemigo
    //                .GetCeldas()[row, i]
    //                .GetPersonaje()
    //                .SetVida(
    //                gridEnemigo.GetCeldas()[row, i].GetPersonaje().GetVida() - 10);
    //        }
    //    }
    //}

    //public void Heal(Grid gridAliado)
    //{
    //    for (int i = 0; i < gridAliado.GetCeldas().GetLength(0); i++)
    //    {
    //        for (int j = 0; j < gridAliado.GetCeldas().GetLength(1); j++)
    //        {
    //            if (gridAliado.GetCeldas()[i, j].IsOccupied())
    //            {
    //                gridAliado
    //                    .GetCeldas()[i, j]
    //                    .GetPersonaje()
    //                    .SetVida(
    //                    gridAliado.GetCeldas()[i, j].GetPersonaje().GetVida() + 10);
    //            }
    //        }
    //    }
    //}

    public void Atacar(Grid gridAliado, Grid gridEnemigo, GameObject personaje)
    {
        switch (personaje.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque())
        {
            case TipoAtaque.GRID:
                // Invocar ataque grid

                Debug.Log("He atacado en GRID");
                break;
            case TipoAtaque.SINGLE:
                Celda celdaObj = CompruebaSingle(gridEnemigo);
                // Invocar ataque single

                Debug.Log("He atacado en SINGLE a la casilla: " + celdaObj.GetX() + ", " + celdaObj.GetY());
                break;
            case TipoAtaque.COLUMN:
                int columnaObj = CompruebaColumn(gridEnemigo);
                // Invocar ataque column

                Debug.Log("He atacado en COLUMN a la columna: " + columnaObj);
                break;
            case TipoAtaque.ROW:
                int filaObj = CompruebaRow(gridEnemigo);
                // Invocar ataque row

                Debug.Log("He atacado en ROW a la fila: " + filaObj);
                break;
            case TipoAtaque.HEAL:
                // Invocar ataque heal

                Debug.Log("He HEALeado");
                break;
            default:
                break;
        }
    }

    public Celda BuscaRandom(Grid grid)
    {
        int x, y;

        do
        {
            x = Random.Range(0, 3);
            y = Random.Range(0, 3);
        } while (!grid.GetCeldas()[x, y].IsOccupied());

        return grid.GetCeldas()[x, y];
    }

    public void AtacarRandom(Grid gridAliado, Grid gridEnemigo, GameObject personaje)
    {
        switch (personaje.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque())
        {
            case TipoAtaque.GRID:
                // Invocar ataque grid

                Debug.Log("He atacado RANDOM en GRID");
                break;
            case TipoAtaque.SINGLE:
                Celda objetivoSingle = BuscaRandom(gridEnemigo);
                // Invocar ataque single

                Debug.Log("He atacado RANDOM en SINGLE a la casilla: " + objetivoSingle.GetX() + ", " + objetivoSingle.GetY());
                break;
            case TipoAtaque.COLUMN:
                Celda objetivoColumn = BuscaRandom(gridEnemigo);
                // Invocar ataque column

                Debug.Log("He atacado RANDOM en COLUMN a la columna: " + objetivoColumn.GetY());
                break;
            case TipoAtaque.ROW:
                Celda objetivoRow = BuscaRandom(gridEnemigo);
                // Invocar ataque row

                Debug.Log("He atacado RANDOM en ROW a la fila: " + objetivoRow.GetX());
                break;
            case TipoAtaque.HEAL:
                // Invocar ataque heal

                Debug.Log("He HEALeado RANDOM");
                break;
            default:
                break;
        }
    }

    public void RealizarTurno(Grid gridAliado, Grid gridEnemigo)
    {
        foreach (GameObject personaje in this.ejercito)
        {
            int factorInteligencia = Random.Range(0, 10);
            if (factorInteligencia > FACTOR_ALEATORIEDAD)
            {
                Atacar(gridAliado, gridEnemigo, personaje);
            } else
            {
                AtacarRandom(gridAliado, gridEnemigo, personaje);
            }
        }
    }
}
