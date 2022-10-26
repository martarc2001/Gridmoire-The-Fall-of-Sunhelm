using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlow : MonoBehaviour
{
    // atributos

    private Grid gridIA = new Grid();
    private Grid gridPlayer = new Grid();

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
                if (celdas[x, y].IsOccupied() && celdas[x, y].GetPersonaje().GetVida() > 0)
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

    private void CreaGrids()
    {
        Celda[,] nuevoGridIA = new Celda[3, 3];
        Celda[,] nuevoGridPlayer = new Celda[3, 3];

        for (int i = 0; i < nuevoGridIA.GetLength(0); i++)
        {
            for (int j = 0; j < nuevoGridIA.GetLength(1); j++)
            {
                nuevoGridIA[i, j] = new Celda(i, j);
                nuevoGridPlayer[i, j] = new Celda(i, j);
            }
        }

        gridIA.SetCeldas(nuevoGridIA);
        gridPlayer.SetCeldas(nuevoGridPlayer);
    }

    private void rellenarGrid(Grid grid)
    {
        int x, y;
        int nEnemigos = 0;

        while (nEnemigos < 3)
        {
            do
            {
                x = Random.Range(0, 2);
                y = Random.Range(0, 2);
            } while ( grid.GetCeldas()[x, y].IsOccupied());

            Personaje enemigo = new Personaje();
            enemigo.SetVida(100);
            enemigo.SetAtaque(100);
            enemigo.SetDefensa(100);
            enemigo.SetTipoAtaque((TipoAtaque)Random.Range(0, 3));

            grid.GetCeldas()[x, y].SetPersonaje(enemigo);
            grid.GetCeldas()[x, y].ChangeOccupied();

            nEnemigos++;
        }
    }

    public void SimulaPartida()
    {
        // Inicialzar grids
        CreaGrids();

        // Generar partida
        rellenarGrid(gridIA);
        rellenarGrid(gridPlayer);

        ia.ConsigueEjercito(gridIA);
        player.ConsigueEjercito(gridPlayer);

        // Batallar
        Debug.Log("Empieza la partida.");
        do
        {
            Debug.Log("TURNO PLAYER");
            player.RealizarTurno(gridIA);
            if (QuedanMoñecos(gridIA))
            {
                Debug.Log("TURNO IA");
                ia.RealizarTurno(gridPlayer);
            }

        } while (QuedanMoñecos(gridIA) && QuedanMoñecos(gridPlayer));
        Debug.Log("Se ha terminado la partida.");
    }
}
