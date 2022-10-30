using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanificationManager : MonoBehaviour
{
    private GameObject playerSelected;

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
                    if (hit.gameObject.CompareTag("Player"))
                    {
                        playerSelected = hit.gameObject;
                    }else if(hit.gameObject.CompareTag("Cell") && playerSelected != null)
                    {
                        hit.gameObject.GetComponent<CeldaManager>().getCelda().SetPersonaje(playerSelected);
                        var copia = Instantiate(playerSelected, hit.gameObject.transform.position, Quaternion.identity);
                        copia.gameObject.transform.SetParent(hit.gameObject.transform);
                    }else if (hit.gameObject.CompareTag("Button"))
                    {
                        hit.gameObject.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }

        }
    }
}
