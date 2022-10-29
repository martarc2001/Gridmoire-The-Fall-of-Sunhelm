using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFlow : MonoBehaviour
{
    // atributos

    //private Grid gridIA = new Grid(3);
    //private Grid gridPlayer = new Grid(3);

    [SerializeField] private GridManager gridIA;
    [SerializeField] private GridManager gridPlayer;

    private IAManager ia = new IAManager();
    private bool initialize = false;

    [SerializeField] private GameObject enemyPrefab;

    private List<PlayerController> ejercitoJugador = new List<PlayerController>();
    private List<PlayerController> ejercitoEnemigo = new List<PlayerController>();

    // getter & setters

    public GridManager GetGridIA() { return gridIA; }
    public GridManager GetGridPlayer() { return gridPlayer; }
    public IAManager GetIAManager() { return ia; }
    public bool isInitialized() { return initialize; }
    

    public void SetGridIA(GridManager gridIA) { this.gridIA = gridIA; }
    public void SetGridPlayer(GridManager gridPlayer) { this.gridPlayer = gridPlayer; }
    public void SetIAManager(IAManager ia) { this.ia = ia; }


    // Metodos
    /*private void Start()
    {
        SimulaPartida();
    }*/

    private void Update()
    {
        if (initialize)
        {
            if (QuedanPersonajes(ejercitoEnemigo) && QuedanPersonajes(ejercitoJugador))
            {
                if (GetComponent<BattleController>().getTurnos() < 3)
                {
                    //Debug.Log(GetComponent<BattleController>().getTurnos());
                }
                else if (QuedanPersonajes(ejercitoEnemigo))
                {
                    ia.RealizarTurno(gridIA.getGridInfo(), gridPlayer.getGridInfo());
                    GetComponent<BattleController>().resetTurno();
                }


            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
        
    }
    private bool QuedanPersonajes(List<PlayerController> comprobar)
    {
        var result = false;
        List<PlayerController> persEliminar = new List<PlayerController>();
        foreach(var personaje in comprobar)
        {
            if(personaje.getPersonaje().GetVida() <= 0)
            {
                persEliminar.Add(personaje);
            }
            if(personaje.getPersonaje().GetVida() > 0)
            {
                result = true;      
            }
        }

        foreach(var eliminados in persEliminar)
        {
            comprobar.Remove(eliminados);
            Destroy(eliminados.gameObject);
        }
        return result;
    }

    private void rellenarGrid(GridManager grid)
    {
        int x, y;
        int nEnemigos = 0;
        Transform celdaTransform = transform;

        while (nEnemigos < 3)
        {
            do
            {
                x = Random.Range(0, 3);
                y = Random.Range(0, 3);
            } while ( grid.getGridInfo().GetCeldas()[x, y].IsOccupied());

           foreach(var celda in grid.getCeldas())
            {
                if(celda.getCelda().GetX() == x && celda.getCelda().GetY() == y)
                {
                    celdaTransform = celda.gameObject.transform;
                }
            }

            Personaje enemigo = new Personaje();
            var vida = Random.Range(10.0f, 100.0f);
            enemigo.SetVida(10);
            var ataque = Random.Range(10.0f, 100.0f);
            enemigo.SetAtaque(ataque);
            var defensa = Random.Range(10.0f, 100.0f);
            enemigo.SetDefensa(0);
            enemigo.SetTipoAtaque((TipoAtaque)Random.Range(0, 5));

            var objEnemigo = Instantiate(enemyPrefab, celdaTransform.position, Quaternion.identity);
            objEnemigo.GetComponent<PlayerController>().setPersonaje(enemigo);
            objEnemigo.transform.SetParent(celdaTransform);
            grid.getGridInfo().GetCeldas()[x, y].SetPersonaje(objEnemigo);
            grid.getGridInfo().GetCeldas()[x, y].ChangeOccupied();
            ejercitoEnemigo.Add(objEnemigo.GetComponent<PlayerController>());
            nEnemigos++;
        }
    }

    public void SimulaPartida()
    {
        // Inicialzar grids
        rellenarGrid(gridIA);

        foreach(var celda in gridIA.getCeldas())
        {
            Debug.Log(celda.getCelda().IsOccupied());
        }

        ia.SetEjercito(ejercitoEnemigo);
        initialize = true;
    }

    public void addPersonaje(PlayerController add) { ejercitoJugador.Add(add); }
}
