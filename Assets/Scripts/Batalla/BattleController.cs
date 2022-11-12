using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleController : MonoBehaviour
{
    private GridManager gridEnemigo;
    private GridManager gridAliado;
    private GameObject playerSelected;

    private List<SeleccionableManager> seleccionables = new List<SeleccionableManager>();

    private int turnosJugados=0;
    [SerializeField] private CeldaManager cellSelected;

    private void Start()
    {
        gridEnemigo = GetComponent<LevelFlow>().GetGridIA();
        gridAliado = GetComponent<LevelFlow>().GetGridPlayer();
    }
    void Update()
    {
        if (GetComponent<LevelFlow>().isInitialized())
        {
            if (turnosJugados < GetComponent<LevelFlow>().ejercitoJugador.Count)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    var pointer = Input.mousePosition;
                    inputController(pointer);
                }
                else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
                {
                    var pointer = Input.GetTouch(0).position;
                    inputController(pointer);
                }
            }
        }
        
        
    }

    private void inputController(Vector3 position)
    {
        var pos = Camera.main.ScreenToWorldPoint(position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (hit.collider.gameObject.GetComponent<SeleccionableManager>().isSelectable())
                {
                    playerSelected = hit.collider.gameObject;
                }
                else
                {
                    Debug.Log("Personaje no seleccionable");
                }
                    
            }
            else if (hit.collider.CompareTag("CellEnemy"))
            {
                if (playerSelected != null && playerSelected.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque()
                    != TipoAtaque.HEAL && cellSelected == null)
                {
                    cellSelected = hit.collider.gameObject.GetComponent<CeldaManager>();
                    resaltar();
                }

                else if (cellSelected != null)
                {
                    var celda = hit.collider.gameObject.GetComponent<CeldaManager>();
                    var coincide = false;
                    switch (playerSelected.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque())
                    {
                        case TipoAtaque.SINGLE:
                            coincide = comprobarSingle(cellSelected, celda);
                            break;
                        case TipoAtaque.COLUMN:
                            coincide = comprobarColumn(cellSelected, celda);
                            break;
                        case TipoAtaque.ROW:
                            coincide = comprobarRow(cellSelected, celda);
                            break;
                        case TipoAtaque.GRID:
                            coincide = true;
                            break;
                    }
                    if (coincide)
                    {
                        playerSelected.GetComponent<Attack>().performAttack(gridEnemigo, cellSelected.getCelda());
                        turnosJugados++;
                        seleccionables.Add(playerSelected.GetComponent<SeleccionableManager>());
                        playerSelected.GetComponent<SeleccionableManager>().changeSelectable();
                        playerSelected = null;
                        cellSelected = null;
                        resetResalto();
                    }
                    else
                    {
                        cellSelected = celda;
                        resetResalto();
                        resaltar();
                    }
                    
                }


            }else if (hit.collider.CompareTag("CellPlayer"))
            {
                if(playerSelected != null 
                    && playerSelected.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque() 
                    == TipoAtaque.HEAL && cellSelected==null)
                {
                    var celda = hit.collider.gameObject.GetComponent<CeldaManager>();
                    
                }

                else if (cellSelected != null)
                {
                    playerSelected.GetComponent<Attack>().performAttack(gridAliado, cellSelected.getCelda());
                    turnosJugados++;
                }
            }
        }
    }

    public int getTurnos() { return turnosJugados; }

    public void resetTurno() 
    { 
        turnosJugados = 0; 
        foreach(var personaje in seleccionables)
        {
            personaje.changeSelectable();
        }
    }

    private void resaltarSingle(CeldaManager celda) 
    {
        celda.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void resaltarRow(CeldaManager celda) 
    {
        foreach(var cell in gridEnemigo.getCeldas())
        {
            if(cell.getCelda().GetX() == celda.getCelda().GetX())
            {
                cell.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void resaltarColumn(CeldaManager celda) 
    {
        foreach (var cell in gridEnemigo.getCeldas())
        {
            if (cell.getCelda().GetY() == celda.getCelda().GetY())
            {
                cell.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void resaltarGrid() 
    { 
        foreach(var cell in gridEnemigo.getCeldas())
        {
            cell.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void resetResalto() 
    {
        foreach(var cell in gridAliado.getCeldas())
        {
            cell.GetComponent<SpriteRenderer>().color = Color.white;
        }

        foreach (var cell in gridEnemigo.getCeldas())
        {
            cell.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private bool comprobarSingle(CeldaManager celdaSelected, CeldaManager cellNew)
    {
        return celdaSelected.getCelda().GetX() == cellNew.getCelda().GetX()
            && celdaSelected.getCelda().GetY() == cellNew.getCelda().GetY();
    }

    private bool comprobarColumn(CeldaManager celdaSelected, CeldaManager cellNew)
    {
        return celdaSelected.getCelda().GetY() == cellNew.getCelda().GetY();
    }

    private bool comprobarRow(CeldaManager celdaSelected, CeldaManager cellNew)
    {
        return celdaSelected.getCelda().GetX() == cellNew.getCelda().GetX();
    }

    private void resaltar()
    {
        switch (playerSelected.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque())
        {
            case TipoAtaque.SINGLE:
                resaltarSingle(cellSelected);
                break;
            case TipoAtaque.COLUMN:
                resaltarColumn(cellSelected);
                break;
            case TipoAtaque.ROW:
                resaltarRow(cellSelected);
                break;
            case TipoAtaque.GRID:
                resaltarGrid();
                break;
        }
    }
}
