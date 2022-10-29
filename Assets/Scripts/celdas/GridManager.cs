using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Grid grid = new Grid();
    [SerializeField] private List<CeldaManager> celdas = new List<CeldaManager>();
    [SerializeField] private GameObject prefabCelda;

    private void Awake()
    {
        grid = new Grid(3);
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(var celda in celdas)
        {
            grid.addCelda(celda.getCelda().GetX(), celda.getCelda().GetY(), celda.getCelda());
            //celda.SetPrefab(prefabCelda);
        }
    }

    public Grid getGridInfo() { return grid; }
}
