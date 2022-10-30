using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private TipoAtaque tipoAtaque;

    void Start()
    {
        tipoAtaque = GetComponent<PlayerController>().getPersonaje().GetTipoAtaque();
    }

    

    public void performAttack(GridManager grid, CeldaManager objetivo)
    {
        switch (tipoAtaque)
        {
            case TipoAtaque.SINGLE:
                singleAttack(objetivo);
                break;
            case TipoAtaque.COLUMN:
                columnAttack(grid, objetivo);
                break;
            case TipoAtaque.ROW:
                rowAttack(grid, objetivo);
                break;
            case TipoAtaque.GRID:
                gridAttack(grid);
                break;
            case TipoAtaque.HEAL:
                healAttack(grid);
                break;
        }
    }

    private void singleAttack(CeldaManager celda) 
    {
        var damage = GetComponent<PlayerController>().getPersonaje().GetAtaque();

        var enemigo = celda.getCelda().GetPersonaje();
        if(enemigo != null)
        {
            var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
            var damageTotal = damage * Random.Range(0.75f, 1);
            if (damageTotal - defEnemigo > 0)
                enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
            Debug.Log(enemigo.GetComponent<PlayerController>().getPersonaje().GetVida());
        }
    }

    private void columnAttack(GridManager grid, CeldaManager objetivo) 
    {
        var damage = GetComponent<PlayerController>().getPersonaje().GetAtaque();
        foreach (var celda in grid.getGridInfo().getColumn(objetivo.getCelda().GetY()))
        {
            var enemigo = celda.GetPersonaje();
            Debug.Log(enemigo);
            if(enemigo != null)
            {
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.5f, 0.75f);
                if (damageTotal - defEnemigo > 0)
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
                Debug.Log(enemigo.GetComponent<PlayerController>().getPersonaje().GetVida());
            }
            
        }
    }

    private void rowAttack(GridManager grid, CeldaManager objetivo) 
    {
        var damage = GetComponent<PlayerController>().getPersonaje().GetAtaque();
        foreach (var celda in grid.getGridInfo().getRow(objetivo.getCelda().GetX()))
        {
            
            var enemigo = celda.GetPersonaje();
            Debug.Log(enemigo);
            if (enemigo != null)
            {
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.5f, 0.75f);
                if (damageTotal - defEnemigo > 0)
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
                Debug.Log(enemigo.GetComponent<PlayerController>().getPersonaje().GetVida());
            }
            
        }
    }

    private void gridAttack(GridManager grid) 
    {
        var damage = GetComponent<PlayerController>().getPersonaje().GetAtaque();
        foreach (var celda in grid.getGridInfo().GetCeldas())
        {
            var enemigo = celda.GetPersonaje();
            if(enemigo != null)
            {
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.25f, 0.5f);
                if (damageTotal - defEnemigo > 0)
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
                Debug.Log(enemigo.GetComponent<PlayerController>().getPersonaje().GetVida());
            }
            
        }
    }

    private void healAttack(GridManager grid) 
    {
        var damage = GetComponent<PlayerController>().getPersonaje().GetAtaque();
        foreach (var celda in grid.getGridInfo().GetCeldas())
        {
            
            var damageTotal = damage * Random.Range(0.25f, 0.5f);
            var aliado = celda.GetPersonaje();
            if(aliado != null)
                aliado.GetComponent<PlayerController>().getPersonaje().takeDamage(-damageTotal);
        }
    }
}
