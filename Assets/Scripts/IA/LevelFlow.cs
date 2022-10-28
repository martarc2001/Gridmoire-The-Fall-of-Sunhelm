using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlow : MonoBehaviour
{
    // atributos

    private Grid gridIA = new Grid(3);
    private Grid gridPlayer = new Grid(3);

    private IAManager ia = new IAManager();
    private IAManager player = new IAManager();

    // getter & setters

    public Grid GetGridIA() { return gridIA; }
    public Grid GetGridPlayer() { return gridPlayer; }
    public IAManager GetIAManager() { return ia; }
    public IAManager GetIAPlayer() { return player; }

    public void SetGridIA(Grid gridIA) { this.gridIA = gridIA; }
    public void SetGridPlayer(Grid gridPlayer) { this.gridPlayer = gridPlayer; }
    public void SetIAManager(IAManager ia) { this.ia = ia; }
    public void GetIAPlayer(IAManager player) { this.player = player; }

    // Metodos

    private bool QuedanMoñecos(Grid comprobar)
    {
        Celda[,] celdas = comprobar.GetCeldas();

        int x = 0;
        int y = 0;

        while (x < celdas.GetLength(0))
        {
            while (y < celdas.GetLength(1))
            {
                if (celdas[x, y].IsOccupied() && celdas[x, y].GetPersonaje().GetComponent<PlayerController>().getPersonaje().GetVida() > 0)
                {
                    return true;
                }
                y++;
            }
            y = 0;
            x++;
        }
        return false;
    }

    private void rellenarGrid(Grid grid)
    {
        int x, y;
        int nEnemigos = 0;

        while (nEnemigos < 3)
        {
            do
            {
                x = Random.Range(0, 3);
                y = Random.Range(0, 3);
            } while ( grid.GetCeldas()[x, y].IsOccupied());

            Personaje enemigo = new Personaje();
            enemigo.SetVida(100);
            enemigo.SetAtaque(100);
            enemigo.SetDefensa(100);
            enemigo.SetTipoAtaque((TipoAtaque)Random.Range(0, 5));

            GameObject objEnemigo = new GameObject();
            objEnemigo.AddComponent<PlayerController>();
            objEnemigo.GetComponent<PlayerController>().setPersonaje(enemigo);

            grid.GetCeldas()[x, y].SetPersonaje(objEnemigo);
            grid.GetCeldas()[x, y].ChangeOccupied();

            nEnemigos++;
        }
    }

    public void SimulaPartida()
    {
        // Inicialzar grids
        rellenarGrid(gridIA);
        rellenarGrid(gridPlayer);

        ia.ConsigueEjercito(gridIA);
        player.ConsigueEjercito(gridPlayer);

        // Batallar
        Debug.Log("Empieza la partida.");
        do
        {
            Debug.Log("TURNO PLAYER");
            player.RealizarTurno(gridPlayer, gridIA);
            if (QuedanMoñecos(gridIA))
            {
                Debug.Log("TURNO IA");
                ia.RealizarTurno(gridIA, gridPlayer);
            }

        } while (QuedanMoñecos(gridIA) && QuedanMoñecos(gridPlayer));
        Debug.Log("Se ha terminado la partida.");
    }
}
