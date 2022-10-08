using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private bool DragActive = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private DraggableObjects lastDrag;

    private void Awake()
    {
        DraggableObjects[] controllers = FindObjectsOfType<DraggableObjects>();
        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        if(DragActive)
        {
            if((Input.GetMouseButtonUp(0) ||
            (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
            {

                EndDrag();
                return;
            }
        }

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

    

    void StartDrag()
    {
        lastDrag.GetComponent<DraggableObjects>().setIsDrag(true);
        DragActive = true;
    }

    void DuringDrag()
    {
        lastDrag.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    void EndDrag()
    {
        lastDrag.GetComponent<DraggableObjects>().setIsDrag(false);
        DragActive = false;
    }

    
}
