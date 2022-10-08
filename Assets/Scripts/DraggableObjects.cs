using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObjects : MonoBehaviour
{

    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 toMovePosition;
    private bool isDrag;
    /*public delegate void DraggableObjectsDelegate(DraggableObjects obj);
    public DraggableObjectsDelegate dragObjectCallback;

    private bool isDragged = false;
    private Vector3 mouseStartPosition;
    private Vector3 spriteStartPosition;

    private void OnMouseDown()
    {
        isDragged = true;
        mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteStartPosition = transform.localPosition;
    }

    

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseStartPosition);
        }
    }

    private void OnMouseUp()
    {
        isDragged = false; 
        dragObjectCallback(this);
    }*/
    private void Awake()
    {
        initialPosition = transform.position;
        toMovePosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!isDrag)
        {
            transform.position = toMovePosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Holita");
        if (other.gameObject.CompareTag("cell"))
        {
            toMovePosition = other.transform.position;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("cell"))
            toMovePosition = initialPosition;
    }

    public void setIsDrag(bool newValue) { isDrag = newValue; }
}
