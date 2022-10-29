using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanificationManager : MonoBehaviour
{
    private GameObject playerSelected;
    [SerializeField] private GameObject canvasParent;
    private int personajesSeleccionados = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var pointer = new PointerEventData(EventSystem.current) { position = Input.mousePosition};
            var raycast = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycast);

            if(raycast.Count > 0)
            {
                foreach(var hit in raycast)
                {
                    if (hit.gameObject.CompareTag("Player") && !hit.gameObject.transform.parent.CompareTag("Cell"))
                    {
                        if(hit.gameObject.transform.Find("Character").GetComponent<SeleccionableManager>().isSelectable())
                            playerSelected = hit.gameObject;

                    }
                    else if(hit.gameObject.CompareTag("Cell"))
                    {
                        if (!hit.gameObject.GetComponent<CeldaManager>().getCelda().IsOccupied())
                        {
                            if (playerSelected != null && personajesSeleccionados < 3)
                            {
                                hit.gameObject.GetComponent<CeldaManager>().getCelda().SetPersonaje(playerSelected);
                                hit.gameObject.GetComponent<CeldaManager>().getCelda().ChangeOccupied();
                                playerSelected.gameObject.transform.SetParent(hit.gameObject.transform);
                                playerSelected.gameObject.transform.position = hit.gameObject.transform.position;
                                playerSelected = null;
                                personajesSeleccionados++;
                            }
                            
                        }
                        else
                        {
                            if(playerSelected != null)
                            {
                                hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                    .GetPersonaje().transform.SetParent(canvasParent.transform);

                                hit.gameObject.GetComponent<CeldaManager>().getCelda().SetPersonaje(null);
                                hit.gameObject.GetComponent<CeldaManager>().getCelda().SetPersonaje(playerSelected);
                                playerSelected.gameObject.transform.SetParent(hit.gameObject.transform);
                                playerSelected.gameObject.transform.position = hit.gameObject.transform.position;
                                playerSelected = null;
                            }
                            else
                            {
                                playerSelected = hit.gameObject.GetComponent<CeldaManager>().getCelda().GetPersonaje();
                                hit.gameObject.GetComponent<CeldaManager>().getCelda().SetPersonaje(null);
                                hit.gameObject.GetComponent<CeldaManager>().getCelda().ChangeOccupied();
                            }
                            
                        }
                        
                    }
                }
            }

        }
    }
}
