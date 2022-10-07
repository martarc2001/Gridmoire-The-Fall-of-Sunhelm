using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] private int x, y;
    private GameObject enemyCell;
    private GameObject allyCell;
    // Start is called before the first frame update

    #region Methods
    /// <summary>
    /// Determina que posición tiene la celda dentro del grid
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void posInGrid(int x, int y) { this.x = x; this.y = y; }

    //Función usada para pruebas
    public string returnPosition()
    {
        var celda = "Celda: (" + this.x + "," + y + ")";
        return celda;
    }
    #endregion

    #region Getters y Setters
    /// <summary>
    /// Devuelve la fila de la celda
    /// </summary>
    /// <returns></returns>
    public int returnRow() { return x; }

    /// <summary>
    /// Devuelve la columna de la celda
    /// </summary>
    /// <returns></returns>
    public int returnCol() { return y; }

    //Función creada para pruebas
    public void setEnemy() { 
        GetComponent<EnemyController>().hasEnemy = true;
        GetComponent<EnemyController>().vida = 1;
    }

    public GameObject isEnemyInCell() {return enemyCell;}
    public GameObject isAllyInCell() { return allyCell;}
    #endregion


    
}
