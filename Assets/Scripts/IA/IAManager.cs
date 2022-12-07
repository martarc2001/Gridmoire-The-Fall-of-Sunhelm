using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class IAManager
{
    // ATRIBUTOS

    private List<EnemigoController> ejercito = new List<EnemigoController>();
    private readonly int FACTOR_ALEATORIEDAD;
    private Celda celdaObj;

    // CONSTRUCTORS

    public IAManager() {}

    public IAManager(int factor = 2)
    {
        this.FACTOR_ALEATORIEDAD = factor;
    }



    // GETTERS & SETTERS

    public List<EnemigoController> GetEjercito() { return this.ejercito; }
    public void SetEjercito(List<EnemigoController> ejercito) { this.ejercito = ejercito; }

    // METODOS

    public Celda CompruebaSingle(GridManager gridEnemigo)
    {
        Celda objetivo = new Celda();
        float PeorVida = Mathf.Infinity;


        foreach(var cell in gridEnemigo.getCeldas())
        {
            Debug.Log(cell.getCelda().IsOccupied());
            if (cell.getCelda().IsOccupied())
            {
                if(cell.getCelda().GetPersonaje().GetComponent<PlayerController>().getPersonaje().GetVida() <= PeorVida)
                {
                    objetivo = cell.getCelda();
                    Debug.Log("Celda seleccionada: " + objetivo.GetX() + "-" + objetivo.GetY());
                }
            }
        }
        return objetivo;
    }

    public Celda ComprubeaHeal(GridManager gridAliado)
    {
        Celda objetivo = new Celda();
        float PeorVida = Mathf.Infinity;


        foreach (var cell in gridAliado.getCeldas())
        {
            Debug.Log(cell.getCelda().IsOccupied());
            if (cell.getCelda().IsOccupied())
            {
                if (cell.getCelda().GetPersonaje().GetComponent<EnemigoController>().getEnemigo().GetVida() <= PeorVida)
                {
                    objetivo = cell.getCelda();
                    Debug.Log("Celda seleccionada: " + objetivo.GetX() + "-" + objetivo.GetY());
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
                Debug.Log("Celda seleccionada: " + columnaObj);
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
                Debug.Log("Celda seleccionada: " + filaObj);
            }
        }

        return filaObj;
    }

    public void Atacar(GridManager gridAliado, GridManager gridEnemigo, EnemigoController personaje)
    {
        switch (personaje.getEnemigo().GetTipoAtaque())
        {
            case TipoAtaque.GRID:
                personaje.GetComponent<EnemyAttack>().gridAttack(gridEnemigo);
                break;
            case TipoAtaque.SINGLE:
                if(celdaObj.GetPersonaje() == null)
                    celdaObj = CompruebaSingle(gridEnemigo);
                personaje.GetComponent<EnemyAttack>().singleAttack(celdaObj);
                break;
            case TipoAtaque.COLUMN:
                if (celdaObj.GetPersonaje() == null)
                    celdaObj = new Celda(0, CompruebaColumn(gridEnemigo));
                personaje.GetComponent<EnemyAttack>().columnAttack(gridEnemigo, gridEnemigo.getGridInfo().GetCeldas()[0, celdaObj.GetY()]);
                break;
            case TipoAtaque.ROW:
                if (celdaObj.GetPersonaje() == null)
                    celdaObj = new Celda(CompruebaRow(gridEnemigo), 0);
                personaje.GetComponent<EnemyAttack>().rowAttack(gridEnemigo, gridEnemigo.getGridInfo().GetCeldas()[celdaObj.GetX(), 0]);
                break;
            case TipoAtaque.HEAL:
                if (celdaObj.GetPersonaje() == null)
                    celdaObj = ComprubeaHeal(gridAliado);
                personaje.GetComponent<EnemyAttack>().healAttack(celdaObj);
                break;
            default:
                break;
        }
    }

    public void resaltarAtaque(GridManager gridAliado, GridManager gridEnemigo, EnemigoController personaje)
    {
        switch (personaje.getEnemigo().GetTipoAtaque())
        {
            case TipoAtaque.GRID:
                resaltarGrid(gridEnemigo);
                break;
            case TipoAtaque.SINGLE:
                celdaObj = CompruebaSingle(gridEnemigo);
                resaltarSingle(gridEnemigo, celdaObj);
                break;
            case TipoAtaque.COLUMN:
                celdaObj = new Celda(0, CompruebaColumn(gridEnemigo));
                resaltarColumn(gridEnemigo, celdaObj.GetY());
                break;
            case TipoAtaque.ROW:
                celdaObj = new Celda(CompruebaRow(gridEnemigo),0);
                resaltarRow(gridEnemigo, celdaObj.GetX());
                break;
            case TipoAtaque.HEAL:
                celdaObj = ComprubeaHeal(gridAliado);
                resaltarHeal(gridAliado, celdaObj);
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

    public void AtacarRandom(GridManager gridAliado, GridManager gridEnemigo, EnemigoController personaje)
    {
        switch (personaje.getEnemigo().GetTipoAtaque())
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
                Celda objetivoHeal = BuscaRandom(gridAliado);
                personaje.GetComponent<Attack>().healAttack(objetivoHeal);
                Debug.Log("He HEALeado RANDOM");
                break;
            default:
                break;
        }
    }

    

    public void resetEnemigos()
    {
        foreach(var personaje in this.ejercito)
        {
            personaje.transform.Find("Sprite").GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void resaltarSingle(GridManager gridEnemigo, Celda celda)
    {
        foreach(var cell in gridEnemigo.getCeldas())
        {
            if(cell.getCelda().GetX() == celda.GetX() && cell.getCelda().GetY() == celda.GetY())
                cell.GetComponent<SpriteRenderer>().color = Color.red;
        }
        
    }

    private void resaltarRow(GridManager gridEnemigo, int celda)
    {
        foreach (var cell in gridEnemigo.getCeldas())
        {
            if (cell.getCelda().GetX() == celda)
            {
                cell.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void resaltarColumn(GridManager gridEnemigo, int celda)
    {
        foreach (var cell in gridEnemigo.getCeldas())
        {
            if (cell.getCelda().GetY() == celda)
            {
                cell.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void resaltarGrid(GridManager gridEnemigo)
    {
        foreach (var cell in gridEnemigo.getCeldas())
        {
            cell.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void resaltarHeal(GridManager gridAliado, Celda celda)
    {
        foreach (var cell in gridAliado.getCeldas())
        {
            if (cell.getCelda().GetX() == celda.GetX() && cell.getCelda().GetY() == celda.GetY())
                cell.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    public void resetResalto(GridManager gridAliado, GridManager gridEnemigo)

    {
        foreach (var cell in gridAliado.getCeldas())
        {
            cell.GetComponent<SpriteRenderer>().color = Color.white;
        }

        foreach (var cell in gridEnemigo.getCeldas())
        {
            cell.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

}
