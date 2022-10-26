using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager
{
    // ATRIBUTOS

    private List<Personaje> ejercito = new List<Personaje>();
    [SerializeField] private readonly int FACTOR_ALEATORIEDAD;

    // CONSTRUCTORS

    public IAManager() {}

    public IAManager(int factor = 2)
    {
        this.FACTOR_ALEATORIEDAD = factor;
    }



    // GETTERS & SETTERS

    public List<Personaje> GetEjercito() { return this.ejercito; }
    public void SetEjercito(List<Personaje> ejercito) { this.ejercito = ejercito; }

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

    public int[] CompruebaSingle(Grid gridEnemigo)
    {
        int[] objetivo = new int[2];
        float PeorVida = Mathf.Infinity;

        for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(0); i++)
        {
            for (int j = 0; j < gridEnemigo.GetCeldas().GetLength(1); j++)
            {
                if (gridEnemigo.GetCeldas()[i, j].IsOccupied())
                {
                    var accionAleatoria = Random.Range(1, 10);

                    if(gridEnemigo.GetCeldas()[i, j].GetPersonaje().GetVida() <= PeorVida)
                    {
                        objetivo = new int[] {i, j};
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

    public void AtaqueGrid(Grid gridEnemigo)
    {
        for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(0); i++)
        {
            for (int j = 0; j < gridEnemigo.GetCeldas().GetLength(1); j++)
            {
                if (gridEnemigo.GetCeldas()[i, j].IsOccupied())
                {
                    gridEnemigo
                        .GetCeldas()[i, j]
                        .GetPersonaje()
                        .SetVida(
                        gridEnemigo.GetCeldas()[i, j].GetPersonaje().GetVida() - 10);
                }
            }
        }
    }

    public void AtaqueSingle(Grid gridEnemigo, int[] pos)
    {
        gridEnemigo
            .GetCeldas()[pos[0], pos[1]]
            .GetPersonaje()
            .SetVida(
            gridEnemigo.GetCeldas()[pos[0], pos[1]].GetPersonaje().GetVida() - 10);
    }

    public void AtaqueColumn(Grid gridEnemigo, int col)
    {
        for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(0); i++)
        {
            if (gridEnemigo.GetCeldas()[i, col].IsOccupied())
            {
                gridEnemigo
                    .GetCeldas()[i, col]
                    .GetPersonaje()
                    .SetVida(
                    gridEnemigo.GetCeldas()[i, col].GetPersonaje().GetVida() - 10);
            }
        }
    }

    public void AtaqueRow(Grid gridEnemigo, int row)
    {
        for (int i = 0; i < gridEnemigo.GetCeldas().GetLength(1); i++)
        {
            if (gridEnemigo.GetCeldas()[row, i].IsOccupied())
            {
                gridEnemigo
                    .GetCeldas()[row, i]
                    .GetPersonaje()
                    .SetVida(
                    gridEnemigo.GetCeldas()[row, i].GetPersonaje().GetVida() - 10);
            }
        }
    }

    public void Heal(Grid gridAliado)
    {
        for (int i = 0; i < gridAliado.GetCeldas().GetLength(0); i++)
        {
            for (int j = 0; j < gridAliado.GetCeldas().GetLength(1); j++)
            {
                if (gridAliado.GetCeldas()[i, j].IsOccupied())
                {
                    gridAliado
                        .GetCeldas()[i, j]
                        .GetPersonaje()
                        .SetVida(
                        gridAliado.GetCeldas()[i, j].GetPersonaje().GetVida() + 10);
                }
            }
        }
    }

    public void Atacar(Grid gridAliado, Grid gridEnemigo, Personaje personaje)
    {
        switch (personaje.GetTipoAtaque())
        {
            case TipoAtaque.GRID:
                // Invocar ataque grid
                AtaqueGrid(gridEnemigo);
                Debug.Log("He atacado en GRID");
                break;
            case TipoAtaque.SINGLE:
                int[] celdaObj = CompruebaSingle(gridEnemigo);
                // Invocar ataque single
                AtaqueSingle(gridEnemigo, celdaObj);
                Debug.Log("He atacado en SINGLE a la casilla: " + celdaObj[0] + ", " + celdaObj[1]);
                break;
            case TipoAtaque.COLUMN:
                int columnaObj = CompruebaColumn(gridEnemigo);
                // Invocar ataque column
                AtaqueColumn(gridEnemigo, columnaObj);
                Debug.Log("He atacado en COLUMN a la columna: " + columnaObj);
                break;
            case TipoAtaque.ROW:
                int filaObj = CompruebaRow(gridEnemigo);
                AtaqueColumn(gridEnemigo, filaObj);
                // Invocar ataque row
                Debug.Log("He atacado en ROW a la fila: " + filaObj);
                break;
            case TipoAtaque.HEAL:
                // Invocar ataque heal
                Heal(gridAliado);
                Debug.Log("He HEALeado");
                break;
            default:
                break;
        }
    }

    public int[] BuscaRandom(Grid grid)
    {
        int x, y;

        do
        {
            x = Random.Range(0, 3);
            y = Random.Range(0, 3);
        } while (!grid.GetCeldas()[x, y].IsOccupied());

        return new int[2] { x, y };
    }

    public void AtacarRandom(Grid gridAliado, Grid gridEnemigo, Personaje personaje)
    {

        

        switch (personaje.GetTipoAtaque())
        {
            case TipoAtaque.GRID:
                // Invocar ataque grid
                AtaqueGrid(gridEnemigo);
                Debug.Log("He atacado RANDOM en GRID");
                break;
            case TipoAtaque.SINGLE:
                int[] objetivoSingle = BuscaRandom(gridEnemigo);
                // Invocar ataque single
                AtaqueSingle(gridEnemigo, objetivoSingle);
                Debug.Log("He atacado RANDOM en SINGLE a la casilla: " + objetivoSingle[0] + ", " + objetivoSingle[1]);
                break;
            case TipoAtaque.COLUMN:
                int[] objetivoColumn = BuscaRandom(gridEnemigo);
                // Invocar ataque column
                AtaqueColumn(gridEnemigo, objetivoColumn[1]);
                Debug.Log("He atacado RANDOM en COLUMN a la columna: " + objetivoColumn[1]);
                break;
            case TipoAtaque.ROW:
                int[] objetivoRow = BuscaRandom(gridEnemigo);
                AtaqueColumn(gridEnemigo, objetivoRow[0]);
                // Invocar ataque row
                Debug.Log("He atacado RANDOM en ROW a la fila: " + objetivoRow[0]);
                break;
            case TipoAtaque.HEAL:
                // Invocar ataque heal
                Heal(gridAliado);
                Debug.Log("He HEALeado RANDOM");
                break;
            default:
                break;
        }
    }

    public void RealizarTurno(Grid gridAliado, Grid gridEnemigo)
    {
        foreach (Personaje personaje in this.ejercito)
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
