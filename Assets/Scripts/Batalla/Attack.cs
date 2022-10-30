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

    

    public void performAttack(GridManager grid, Celda objetivo)
    {
        if(objetivo != null && grid != null)
        {
            Debug.Log("Atacado");
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
        
    }

    public void singleAttack(Celda celda) 
    {
        var damage = GetComponent<PlayerController>().getPersonaje().GetAtaque();

        
        if(celda.GetPersonaje() != null)
        {
            Debug.Log("Atacado");
            var enemigo = celda.GetPersonaje();
            var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
            var damageTotal = damage * Random.Range(0.75f, 1);
            if (damageTotal - defEnemigo > 0)
                enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
            Debug.Log(enemigo.GetComponent<PlayerController>().getPersonaje().GetVida());
        }
        
    }

    public void columnAttack(GridManager grid, Celda objetivo) 
    {

        var damage = GetComponent<PlayerController>().getPersonaje().GetAtaque();
        Debug.Log(objetivo.GetY());
        foreach (var celda in grid.getGridInfo().getColumn(objetivo.GetY()))
        {
            if(celda.GetPersonaje() != null)
            {
                Debug.Log("Atacado");
                var enemigo = celda.GetPersonaje();
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.5f, 0.75f);
                if (damageTotal - defEnemigo > 0)
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
                Debug.Log(enemigo.GetComponent<PlayerController>().getPersonaje().GetVida());
            }
            
        }
    }

    public void rowAttack(GridManager grid, Celda objetivo) 
    {
        var damage = GetComponent<PlayerController>().getPersonaje().GetAtaque();
        Debug.Log(objetivo.GetX());
        foreach (var celda in grid.getGridInfo().getRow(objetivo.GetX()))
        {
            if (celda.GetPersonaje() != null)
            {
                Debug.Log("Atacado");
                var enemigo = celda.GetPersonaje();
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.5f, 0.75f);
                if (damageTotal - defEnemigo > 0)
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
                Debug.Log(enemigo.GetComponent<PlayerController>().getPersonaje().GetVida());
            }
            
        }
    }

    public void gridAttack(GridManager grid) 
    {
        var damage = GetComponent<PlayerController>().getPersonaje().GetAtaque();
        foreach (var celda in grid.getGridInfo().GetCeldas())
        {
            
            if(celda.GetPersonaje() != null)
            {
                Debug.Log("Atacado");
                var enemigo = celda.GetPersonaje();
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.25f, 0.5f);
                if (damageTotal - defEnemigo > 0)
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
                Debug.Log(enemigo.GetComponent<PlayerController>().getPersonaje().GetVida());
            }
            
        }
    }

    public void healAttack(GridManager grid) 
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
