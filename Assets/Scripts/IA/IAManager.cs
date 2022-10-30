using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager
{
    // ATRIBUTOS

    private List<PlayerController> ejercito = new List<PlayerController>();
    private readonly int FACTOR_ALEATORIEDAD;

    // CONSTRUCTORS

    public IAManager() {}

    public IAManager(int factor = 2)
    {
        this.FACTOR_ALEATORIEDAD = factor;
    }



    // GETTERS & SETTERS

    public List<PlayerController> GetEjercito() { return this.ejercito; }
    public void SetEjercito(List<PlayerController> ejercito) { this.ejercito = ejercito; }

    // METODOS

    public Celda CompruebaSingle(GridManager gridEnemigo)
    {
        Celda objetivo = new Celda();
        float PeorVida = Mathf.Infinity;

        for (int i = 0; i < gridEnemigo.getGridInfo().GetCeldas().GetLength(0); i++)
        {
            for (int j = 0; j < gridEnemigo.getGridInfo().GetCeldas().GetLength(1); j++)
            {
                if (gridEnemigo.getGridInfo().GetCeldas()[i, j].IsOccupied())
                {
                    var accionAleatoria = Random.Range(1, 10);

                    if(gridEnemigo.getGridInfo().GetCeldas()[i, j].GetPersonaje().GetComponent<PlayerController>().getPersonaje().GetVida() <= PeorVida)
                    {
                        objetivo = gridEnemigo.getGridInfo().GetCeldas()[i, j];
                    }
                }
            }
        }
        return objetivo;
    }

    public int CompruebaColumn(GridManager gridEnemigo)
    {
        int columnaObj = 0;
        int nEnemigos = 0;
        int mejorColumna = 0;

        for (int j = 0; j < gridEnemigo.getGridInfo().GetCeldas().GetLength(1); j++)
        {
            nEnemigos = 0;
            var accionAleatoria = Random.Range(1, 10);

            for (int i = 0; i < gridEnemigo.getGridInfo().GetCeldas().GetLength(0); i++)
            {
                if (gridEnemigo.getGridInfo().GetCeldas()[i, j].IsOccupied())
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

    public int CompruebaRow(GridManager gridEnemigo)
    {
        int filaObj = 0;
        int nEnemigos = 0;
        int mejorFila = 0;

        for (int i = 0; i < gridEnemigo.getGridInfo().GetCeldas().GetLength(0); i++)
        {
            nEnemigos = 0;
            var accionAleatoria = Random.Range(1, 10);

            for (int j = 0; j < gridEnemigo.getGridInfo().GetCeldas().GetLength(1); j++)
            {
                if (gridEnemigo.getGridInfo().GetCeldas()[i, j].IsOccupied())
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
    public void Atacar(GridManager gridAliado, GridManager gridEnemigo, PlayerController personaje)
    {
        switch (personaje.getPersonaje().GetTipoAtaque())
        {
            case TipoAtaque.GRID:
                // Invocar ataque grid
                personaje.GetComponent<Attack>().gridAttack(gridEnemigo);
                Debug.Log("He atacado en GRID");
                break;
            case TipoAtaque.SINGLE:
                Celda celdaObj = CompruebaSingle(gridEnemigo);
                // Invocar ataque single
                personaje.GetComponent<Attack>().singleAttack(celdaObj);
                //Debug.Log("He atacado en SINGLE a la casilla: " + celdaObj[0] + ", " + celdaObj[1]);
                break;
            case TipoAtaque.COLUMN:
                int columnaObj = CompruebaColumn(gridEnemigo);
                // Invocar ataque column
                personaje.GetComponent<Attack>().columnAttack(gridEnemigo, gridEnemigo.getGridInfo().GetCeldas()[0, columnaObj]);
                Debug.Log("He atacado en COLUMN a la columna: " + columnaObj);
                break;
            case TipoAtaque.ROW:
                int filaObj = CompruebaRow(gridEnemigo);
                // Invocar ataque row
                personaje.GetComponent<Attack>().rowAttack(gridEnemigo, gridEnemigo.getGridInfo().GetCeldas()[filaObj, 0]);
                Debug.Log("He atacado en ROW a la fila: " + filaObj);
                break;
            case TipoAtaque.HEAL:
                // Invocar ataque heal
                personaje.GetComponent<Attack>().healAttack(gridAliado);
                Debug.Log("He HEALeado");
                break;
            default:
                break;
        }
    }

    public Celda BuscaRandom(GridManager grid)
    {
        int x, y;

        do
        {
            x = Random.Range(0, 3);
            y = Random.Range(0, 3);
        } while (!grid.getGridInfo().GetCeldas()[x, y].IsOccupied());

        return grid.getGridInfo().GetCeldas()[x,y];
    }

    public void AtacarRandom(GridManager gridAliado, GridManager gridEnemigo, PlayerController personaje)
    {
        switch (personaje.getPersonaje().GetTipoAtaque())
        {
            case TipoAtaque.GRID:
                // Invocar ataque grid
                personaje.GetComponent<Attack>().gridAttack(gridEnemigo);
                Debug.Log("He atacado RANDOM en GRID");
                break;
            case TipoAtaque.SINGLE:
                Celda objetivoSingle = BuscaRandom(gridEnemigo);
                // Invocar ataque single
                personaje.GetComponent<Attack>().singleAttack(objetivoSingle);
                break;
            case TipoAtaque.COLUMN:
                Celda objetivoColumn = BuscaRandom(gridEnemigo);
                // Invocar ataque column
                personaje.GetComponent<Attack>().columnAttack(gridEnemigo, objetivoColumn);
                break;
            case TipoAtaque.ROW:
                Celda objetivoRow = BuscaRandom(gridEnemigo);
                // Invocar ataque row
                personaje.GetComponent<Attack>().rowAttack(gridEnemigo, objetivoRow);
                break;
            case TipoAtaque.HEAL:
                // Invocar ataque heal
                personaje.GetComponent<Attack>().healAttack(gridAliado);
                Debug.Log("He HEALeado RANDOM");
                break;
            default:
                break;
        }
    }

    public void RealizarTurno(GridManager gridAliado, GridManager gridEnemigo)
    {
        foreach (var personaje in this.ejercito)
        {
            int factorInteligencia = Random.Range(0, 10);
            if (factorInteligencia > FACTOR_ALEATORIEDAD)
            {
                Debug.Log(personaje);
                Atacar(gridAliado, gridEnemigo, personaje);
            } else
            {
                AtacarRandom(gridAliado, gridEnemigo, personaje);
            }
        }
    }
}
