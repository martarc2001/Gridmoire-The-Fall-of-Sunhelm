using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlow : MonoBehaviour
{
    // atributos

    private Grid gridIA;
    private Grid gridPlayer;

    private IAManager ia;
    private IAManager player;

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

    public void SimulaPartida()
    {
        // Generar partida
        Debug.Log("Empieza la partida.");
        do
        {
            player.RealizarTurno(gridIA);
            if (QuedanMoñecos(gridIA))
            {
                ia.RealizarTurno(gridPlayer);
            }

        } while (QuedanMoñecos(gridIA) && QuedanMoñecos(gridPlayer));
        Debug.Log("Se ha terminado la partida.");
    }

    private bool QuedanMoñecos(Grid comprobar)
    {
        Celda[,] celdas = comprobar.GetCeldas();

        int x = 0;
        int y = 0;

        while (x < celdas.GetLength(0))
        {
            while(y < celdas.GetLength(1))
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
}
