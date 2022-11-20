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
    [SerializeField] DataToBattle dataBattle;

    private List<string> nombres = new List<string>();
    [SerializeField] private CargarPersonajes cargarScript;

    public List<string> getNombres() { return nombres; }

    void Start()
    {
        var obj = FindObjectOfType<NivelDataHandler>() as NivelDataHandler;

        Debug.Log(obj.GetMonedas());
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var pointer = new PointerEventData(EventSystem.current) { position = Input.mousePosition};
            inputController(pointer);
        }else if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            var pointer = new PointerEventData(EventSystem.current) { position = Input.GetTouch(0).position };
            inputController(pointer);
        }
    }

    private void inputController(PointerEventData pointer)
    {
        var raycast = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycast);

        if (raycast.Count > 0)
        {
            foreach (var hit in raycast)
            {
                if (hit.gameObject.CompareTag("Player") && !hit.gameObject.transform.parent.CompareTag("Cell"))
                {
                    if (hit.gameObject.transform.Find("Character").GetComponent<SeleccionableManager>().isSelectable())
                        playerSelected = hit.gameObject;
                }
                else if (hit.gameObject.CompareTag("Cell"))
                {
                    if (!hit.gameObject.GetComponent<CeldaManager>().getCelda().IsOccupied())
                    {
                        if (playerSelected != null && personajesSeleccionados < 4)
                        {
                            hit.gameObject.GetComponent<CeldaManager>().getCelda().SetPersonaje(playerSelected);
                            hit.gameObject.GetComponent<CeldaManager>().getCelda().ChangeOccupied();
                            playerSelected.gameObject.transform.SetParent(hit.gameObject.transform);
                            playerSelected.gameObject.transform.position = hit.gameObject.transform.position;
                            playerSelected.gameObject.transform.localScale = new Vector3(1, 1, 1);
                            playerSelected.gameObject.transform.Find("Ataque").gameObject.SetActive(false);
                            playerSelected.gameObject.transform.Find("Defensa").gameObject.SetActive(false);
                            playerSelected.gameObject.transform.Find("HP").gameObject.SetActive(false);
                            playerSelected.gameObject.transform.Find("Nivel").gameObject.SetActive(false);
                            playerSelected.gameObject.transform.Find("TipoAtaque").gameObject.SetActive(false);
                            nombres.Add(playerSelected.transform.Find("Character").GetComponent<PlayerController>().getPersonaje().GetNombre());
                            playerSelected = null;
                            personajesSeleccionados++;
                            dataBattle.addCelda(hit.gameObject.GetComponent<CeldaManager>());
                        }

                    }
                    else
                    {
                        if (playerSelected != null)
                        {

                            nombres.Remove(hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                .GetPersonaje().transform.Find("Character").GetComponent<PlayerController>()
                                .getPersonaje().GetNombre()
                                );

                            if (hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                .GetPersonaje().transform.Find("Character").GetComponent<PlayerController>()
                                .getPersonaje().GetRareza() == cargarScript.getRarezaAtual())
                            {
                                hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                .GetPersonaje().transform.SetParent(canvasParent.transform);
                                hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                    .GetPersonaje().transform.localScale = new Vector3(3, 3, 3);

                                hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                .GetPersonaje().gameObject.transform.Find("Ataque").gameObject.SetActive(true);
                                hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                .GetPersonaje().gameObject.transform.Find("Defensa").gameObject.SetActive(true);
                                hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                .GetPersonaje().gameObject.transform.Find("HP").gameObject.SetActive(true);
                                hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                .GetPersonaje().gameObject.transform.Find("Nivel").gameObject.SetActive(true);
                                hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                .GetPersonaje().gameObject.transform.Find("TipoAtaque").gameObject.SetActive(true);

                            }
                            else
                            {
                                Destroy(hit.gameObject.GetComponent<CeldaManager>().getCelda()
                                .GetPersonaje().gameObject);
                            }
                            

                            hit.gameObject.GetComponent<CeldaManager>().getCelda().SetPersonaje(null);
                            hit.gameObject.GetComponent<CeldaManager>().getCelda().SetPersonaje(playerSelected);
                            playerSelected.gameObject.transform.SetParent(hit.gameObject.transform);
                            playerSelected.gameObject.transform.localScale = new Vector3(1, 1, 1);
                            playerSelected.gameObject.transform.Find("Ataque").gameObject.SetActive(false);
                            playerSelected.gameObject.transform.Find("Defensa").gameObject.SetActive(false);
                            playerSelected.gameObject.transform.Find("HP").gameObject.SetActive(false);
                            playerSelected.gameObject.transform.Find("Nivel").gameObject.SetActive(false);
                            playerSelected.gameObject.transform.Find("TipoAtaque").gameObject.SetActive(false);
                            playerSelected.gameObject.transform.position = hit.gameObject.transform.position;
                            nombres.Add(playerSelected.transform.Find("Character").GetComponent<PlayerController>().getPersonaje().GetNombre());
                            playerSelected = null;
                        }
                        else
                        {
                            personajesSeleccionados--;
                            playerSelected = hit.gameObject.GetComponent<CeldaManager>().getCelda().GetPersonaje();
                            hit.gameObject.GetComponent<CeldaManager>().getCelda().SetPersonaje(null);
                            hit.gameObject.GetComponent<CeldaManager>().getCelda().ChangeOccupied();
                            dataBattle.removeCelda(hit.gameObject.GetComponent<CeldaManager>());
                            nombres.Remove(playerSelected.transform.Find("Character").GetComponent<PlayerController>().getPersonaje().GetNombre());
                        }

                    }

                }
            }
        }
    }


}
