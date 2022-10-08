using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObjects : MonoBehaviour
{
    #region Variables
    [SerializeField] private Vector3 initialPosition; //guardar la posición inicial para moverla ahí si no está en casilla
    [SerializeField] private Vector3 toMovePosition; //guarda la posición de la casilla donde se va a mover
    private bool isDrag; //variable de control. Determina si se está moviendo
    private GameObject cell; //almacena la casilla donde es arrastrado
    #endregion

    #region Unity Methods
    private void Awake()
    {
        initialPosition = transform.position;
        toMovePosition = transform.position;
    }

    //Si no se arrastra, se mueve a la posición marcada como posición objetivo
    private void FixedUpdate()
    {
        if (!isDrag)
        {
            transform.position = toMovePosition;
        }
    }
    #endregion

    #region Collision Methods
    //si se colisiona con una celda, se establece la posición a la que se moverá con la posición de la celda.
    //Además se almacena qué celda es
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cell"))
        {
            toMovePosition = collision.transform.position;
            cell = collision.gameObject;
            GetComponent<Attack>().setCell(cell);
            //cell.GetComponent<CellController>().setEnemy();
        }
    }

    //Si se deja de colisionar con una celda, se determina que la posición a la que se moverá es la inicial.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cell"))
        {
            toMovePosition = initialPosition;
            cell = null;
        }
    }
    #endregion

    #region Getters y Setters
    /// <summary>
    /// Setter de la variable isDrag
    /// </summary>
    /// <param name="newValue"></param>
    public void setIsDrag(bool newValue) { isDrag = newValue; }
    #endregion
}
