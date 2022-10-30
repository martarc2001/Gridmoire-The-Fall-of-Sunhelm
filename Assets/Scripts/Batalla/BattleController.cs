using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleController : MonoBehaviour
{
    private GridManager gridEnemigo;
    private GridManager gridAliado;
    private GameObject playerSelected;

    private int turnosJugados=0;

    private void Start()
    {
        gridEnemigo = GetComponent<LevelFlow>().GetGridIA();
        gridAliado = GetComponent<LevelFlow>().GetGridPlayer();
    }
    void Update()
    {
        if (GetComponent<LevelFlow>().isInitialized())
        {
            if (turnosJugados < 3)
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
                playerSelected = hit.collider.gameObject;
            }
            else if (hit.collider.CompareTag("CellEnemy"))
            {
                if (playerSelected != null && 
                    playerSelected.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque()
                    != TipoAtaque.HEAL)
                {
                    var celda = hit.collider.gameObject.GetComponent<CeldaManager>();
                    playerSelected.GetComponent<Attack>().performAttack(gridEnemigo, celda.getCelda());
                    turnosJugados++;
                    Debug.Log("Turno terminado");
                }
            }else if (hit.collider.CompareTag("CellPlayer"))
            {
                if(playerSelected != null 
                    && playerSelected.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque() 
                    == TipoAtaque.HEAL)
                {
                    var celda = hit.collider.gameObject.GetComponent<CeldaManager>();
                    playerSelected.GetComponent<Attack>().performAttack(gridAliado, celda.getCelda());
                    turnosJugados++;
                    Debug.Log("Turno terminado");
                }
            }
        }
    }

    public int getTurnos() { return turnosJugados; }

    public void resetTurno() { turnosJugados = 0; }
}
