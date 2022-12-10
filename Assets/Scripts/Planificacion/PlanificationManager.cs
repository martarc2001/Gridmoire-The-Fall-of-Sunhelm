using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanificationManager : MonoBehaviour
{
    [SerializeField] private GameObject playerSelected;
    [SerializeField] private GameObject canvasParent;
    private int personajesSeleccionados = 0;
    [SerializeField] DataToBattle dataBattle;
    [SerializeField] private GridManager grid;

    private List<string> nombres = new List<string>();
    [SerializeField] private CargarPersonajes cargarScript;

    [Header("Fondo")]
    [SerializeField] private List<Sprite> fondos;
    [SerializeField] private SpriteRenderer fondo;
    public List<string> getNombres() { return nombres; }

    private List<CeldaManager> celdasToRemove= new List<CeldaManager>();

    void Start()
    {
        var obj = FindObjectOfType<NivelDataHandler>();

        fondo.sprite = fondos[obj.GetFondo()];

        foreach(var celda in grid.getCeldas())
        {
            Debug.Log(obj.GetCeldasX().Count);

            for (var i = 0; i < obj.GetCeldasX().Count; i++)
            {
                Debug.Log("Celda a remover: (" + obj.GetCeldasX()[i] + "," + obj.GetCeldasY()[i] + ")");
                if (obj.GetCeldasX()[i] == celda.getCelda().GetX() && obj.GetCeldasY()[i] == celda.getCelda().GetY())
                {
                    celdasToRemove.Add(celda);
                }
            }
        }

        foreach(var celda in celdasToRemove)
        {
            grid.getCeldas().Remove(celda);
            Destroy(celda.gameObject);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var pointer = new PointerEventData(EventSystem.current) { position = Input.mousePosition};
            inputController(pointer);
        }/*else if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            var pointer = new PointerEventData(EventSystem.current) { position = Input.GetTouch(0).position };
            inputController(pointer);
        }*/
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
                    if(playerSelected != null)
                    {
                        if(playerSelected.transform.Find("Character").GetComponent<PlayerController>().getPersonaje().GetRareza() == cargarScript.getRarezaAtual())
                        {
                            playerSelected.transform.SetParent(canvasParent.transform);
                            playerSelected.transform.localScale = new Vector3(3, 3, 3);

                            playerSelected.transform.Find("Ataque").gameObject.SetActive(true);
                            playerSelected.transform.Find("Defensa").gameObject.SetActive(true);
                            playerSelected.transform.Find("HP").gameObject.SetActive(true);
                            playerSelected.transform.Find("Nivel").gameObject.SetActive(true);
                            playerSelected.transform.Find("TipoAtaque").gameObject.SetActive(true);

                            if (hit.gameObject.transform.Find("Character").GetComponent<SeleccionableManager>().isSelectable())
                                playerSelected = hit.gameObject;

                        }
                    }
                    else 
                    {
                        if (hit.gameObject.transform.Find("Character").GetComponent<SeleccionableManager>().isSelectable())
                            playerSelected = hit.gameObject;
                    }
                    
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
