using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private TipoAtaque tipoAtaque;

    void Start()
    {
        tipoAtaque = GetComponent<EnemigoController>().getEnemigo().GetTipoAtaque();
    }



    public void performAttack(GridManager grid, Celda objetivo)
    {
        if (objetivo != null && grid != null)
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
                    healAttack(objetivo);
                    break;
            }
        }

    }

    public void singleAttack(Celda celda)
    {
        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();


        if (celda.GetPersonaje() != null)
        {
            var enemigo = celda.GetPersonaje();
            var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
            var damageTotal = damage * Random.Range(0.75f, 1);
            if (damageTotal - defEnemigo > 0)
                enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
            else
                enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal/5);
        }

    }

    public void columnAttack(GridManager grid, Celda objetivo)
    {

        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();
        foreach (var celda in grid.getGridInfo().getColumn(objetivo.GetY()))
        {
            if (celda.GetPersonaje() != null)
            {
                var enemigo = celda.GetPersonaje();
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.5f, 0.75f);
                if (damageTotal - defEnemigo > 0)
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
                else
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal / 5);
            }

        }
    }

    public void rowAttack(GridManager grid, Celda objetivo)
    {
        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();

        foreach (var celda in grid.getGridInfo().getRow(objetivo.GetX()))
        {
            if (celda.GetPersonaje() != null)
            {
                var enemigo = celda.GetPersonaje();
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.5f, 0.75f);
                if (damageTotal - defEnemigo > 0)
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
                else
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal / 5);
            }

        }
    }

    public void gridAttack(GridManager grid)
    {
        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();
        foreach (var celda in grid.getGridInfo().GetCeldas())
        {

            if (celda.GetPersonaje() != null)
            {
                var enemigo = celda.GetPersonaje();
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.25f, 0.5f);
                if (damageTotal - defEnemigo > 0)
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo);
                else
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal / 5);
            }

        }
    }

    public void healAttack(Celda celda)
    {
        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();
        if (celda.GetPersonaje() != null)
        {
            var enemigo = celda.GetPersonaje();
            var damageTotal = damage * Random.Range(0.05f, 0.15f);
            enemigo.GetComponent<EnemigoController>().getEnemigo().curar(damageTotal);
        }
    }
}
