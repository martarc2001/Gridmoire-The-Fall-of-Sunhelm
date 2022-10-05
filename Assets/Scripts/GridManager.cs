using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    //Variables para generar celdas de manera procedural. Sin uso actualmente
    /*[SerializeField] private GameObject cell;

    [SerializeField] private int width, height;

    [SerializeField] private float anchoCelda, altoCelda;*/

    //Lista con todas las celdas, rellenada mediante el inspector
    [SerializeField] private List<GameObject> celdas = new List<GameObject>();
    #endregion
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        //generateGrid();
    }

    //Función de prueba para generar las celdas proceduralmente
    /*private void generateGrid()
    {
        for(var i = 0; i < width; i++)
        {
            for(var j = 0; j < height; j++)
            {
                if(i==0 && j==0)
                {
                    var newCell = Instantiate(cell, new Vector2(i, j), Quaternion.identity);
                    newCell.GetComponent<CellController>().posInGrid(i, j);
                    celdas.Add(newCell);
                }
                else
                {
                    var newCell = Instantiate(cell, new Vector2(i * anchoCelda, j * altoCelda), Quaternion.identity); ;
                    newCell.GetComponent<CellController>().posInGrid(i, j);
                    celdas.Add(newCell);
                }
                
            }
        }
    }*/

    /// <summary>
    /// Devuelve una lista con las celdas que están en la misma columna que la celda pasada como parámetro
    /// </summary>
    /// <param name="actualCell"></param>
    /// <returns></returns>
    public GameObject[] returnCol(GameObject actualCell)
    {
        var colCells = new GameObject[3];
        List<GameObject> posibles = new List<GameObject>();
        var script = actualCell.GetComponent<CellController>();

        colCells[0] = actualCell;

        for(var i = 0; i < celdas.Count; i++)
        {
            var scriptPosible = celdas[i].GetComponent<CellController>();
            if(script.returnCol() == scriptPosible.returnCol())
            {
                
                for(int j = 1; j < 3; j++)
                {
                    if ((script.returnRow() + j) == scriptPosible.returnRow())
                    {
                        posibles.Add(celdas[i]);
                    }
                } 
                
            }
        }

        for (var i = 0; i < celdas.Count; i++)
        {
            var scriptPosible = celdas[i].GetComponent<CellController>();
            if (script.returnCol() == scriptPosible.returnCol())
            {

                for (int j = 1; j < 3; j++)
                {
                    if ((script.returnRow() - j) == scriptPosible.returnRow())
                    {
                        posibles.Add(celdas[i]);
                    }
                }

            }
        }

        colCells[1] = posibles[0];
        colCells[2] = posibles[1];

        return colCells;
    }

    /// <summary>
    /// Devuelve una lista con las celdas que están en la misma fila que la celda pasada como parámetro
    /// </summary>
    /// <param name="actualCell"></param>
    /// <returns></returns>
    public GameObject[] returnRow(GameObject actualCell)
    {
        var rowCells = new GameObject[3];
        List<GameObject> posibles = new List<GameObject>();
        var script = actualCell.GetComponent<CellController>();

        rowCells[0] = actualCell;

        for (var i = 0; i < celdas.Count; i++)
        {
            var scriptPosible = celdas[i].GetComponent<CellController>();
            if (script.returnRow() == scriptPosible.returnRow())
            {

                for (int j = 1; j < 3; j++)
                {
                    if ((script.returnCol() + j) == scriptPosible.returnCol())
                    {
                        posibles.Add(celdas[i]);
                    }
                }

            }
        }

        for (var i = 0; i < celdas.Count; i++)
        {
            var scriptPosible = celdas[i].GetComponent<CellController>();
            if (script.returnRow() == scriptPosible.returnRow())
            {

                for (int j = 1; j < 3; j++)
                {
                    if ((script.returnCol() - j) == scriptPosible.returnCol())
                    {
                        posibles.Add(celdas[i]);
                    }
                }

            }
        }

        rowCells[1] = posibles[0];
        rowCells[2] = posibles[1];

        return rowCells;
    }

    /// <summary>
    /// Devuelve la lista con las celdas
    /// </summary>
    /// <returns></returns>
    public List<GameObject> returnGrid() { return celdas; }
}
