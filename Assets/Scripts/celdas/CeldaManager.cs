using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeldaManager : MonoBehaviour
{
    private Celda cellInfo;
    [SerializeField] private int x;
    [SerializeField] private int y;


    private void Awake()
    {
        cellInfo = new Celda(x, y);
    }
    public void setPersonaje(GameObject personaje) 
    { 
        cellInfo.SetPersonaje(personaje);
        if (!cellInfo.IsOccupied())
            cellInfo.ChangeOccupied();
    }

    public Celda getCelda() { return cellInfo; }
}
