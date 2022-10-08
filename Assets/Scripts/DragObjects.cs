using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    #region Variables
    private bool DragActive = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private DraggableObjects lastDrag;
    #endregion

    #region Unity Methods
    private void Update()
    {
        //Si se está arrastrando y se suelta el botón del mouse o se deja de pulsar la pantalla,
        //se deja de arrastrar
        if(DragActive)
        {
            if((Input.GetMouseButtonUp(0) ||
            (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
            {

                EndDrag();
                return;
            }
        }

        //determina la posición del puntero en la pantalla dependiendo del input del mouse o del touch en el móvil
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            screenPosition = new Vector2(mousePosition.x, mousePosition.y);
        }else if(Input.touchCount> 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        //Si no se está arrastrando, se crea un raycast desde la posición del puntero y si este choca con un objeto, se comprueba si es un objeto arrastrable.
        //Si lo es, se inicia el arrastre
        if (DragActive)
        {
            DuringDrag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                DraggableObjects draggable = hit.transform.gameObject.GetComponent<DraggableObjects>();
                if(draggable != null)
                {
                    lastDrag = draggable;
                    StartDrag();
                }
            }
        }
    }
    #endregion

    #region Metods
    /// <summary>
    /// Empieza el arrastre
    /// </summary>
    void StartDrag()
    {
        lastDrag.GetComponent<DraggableObjects>().setIsDrag(true);
        DragActive = true;
    }

    /// <summary>
    /// Va cambiando la posición del objeto arrastrado.
    /// </summary>
    void DuringDrag()
    {
        lastDrag.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    /// <summary>
    /// Finaliza el arrastre
    /// </summary>
    void EndDrag()
    {
        lastDrag.GetComponent<DraggableObjects>().setIsDrag(false);
        DragActive = false;
    }
    #endregion

}
