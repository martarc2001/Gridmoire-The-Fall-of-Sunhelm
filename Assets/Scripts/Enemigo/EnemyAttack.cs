using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private TipoAtaque tipoAtaque;
    [SerializeField] private List<AudioClip> efectosSonido;
    [SerializeField] private ParticleSystem particulasCurar;

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
                    GameManager.instance.GetAudioSource().PlayOneShot(efectosSonido[0]);
                    break;
                case TipoAtaque.ROW:
                    rowAttack(grid, objetivo);
                    GameManager.instance.GetAudioSource().PlayOneShot(efectosSonido[0]);
                    break;
                case TipoAtaque.GRID:
                    gridAttack(grid);
                    GameManager.instance.GetAudioSource().PlayOneShot(efectosSonido[0]);
                    break;
                case TipoAtaque.HEAL:
                    healAttack(objetivo);
                    GameManager.instance.GetAudioSource().PlayOneShot(efectosSonido[1]);
                    break;
            }
        }

    }

    public void singleAttack(Celda celda)
    {
        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();

        GameManager.instance.GetAudioSource().PlayOneShot(efectosSonido[0]);
        if (celda.GetPersonaje() != null)
        {
            var enemigo = celda.GetPersonaje();
            var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
            var damageTotal = damage * Random.Range(1.05f, 1.1f);
            if (damage - defEnemigo > 0)
            {
                if (enemigo.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque() == TipoAtaque.ROW)
                {
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal + 0.25f - defEnemigo / 2);
                }
                else
                {
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo / 2);
                }
            }
            else
            {
                enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal * 3 / 5);
            }
        }


    }

    public void columnAttack(GridManager grid, Celda objetivo)
    {
        GameManager.instance.GetAudioSource().PlayOneShot(efectosSonido[0]);
        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();
        foreach (var celda in grid.getGridInfo().getColumn(objetivo.GetY()))
        {
            if (celda.GetPersonaje() != null)
            {
                var enemigo = celda.GetPersonaje();
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                if (damage - defEnemigo > 0)
                {
                    if (enemigo.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque() == TipoAtaque.GRID)
                    {
                        enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damage + 0.25f - defEnemigo / 2);
                    }
                    else
                    {
                        enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damage - defEnemigo / 2);
                    }
                }
                else
                {
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damage * 3 / 5);
                }
                
            }
        }
    }

    public void rowAttack(GridManager grid, Celda objetivo)
    {
        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();
        GameManager.instance.GetAudioSource().PlayOneShot(efectosSonido[0]);
        foreach (var celda in grid.getGridInfo().getRow(objetivo.GetX()))
        {
            if (celda.GetPersonaje() != null)
            {
                var enemigo = celda.GetPersonaje();
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                if (damage - defEnemigo > 0)
                {
                    if (enemigo.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque() == TipoAtaque.COLUMN)
                    {
                        enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damage + 0.25f - defEnemigo / 2);
                    }
                    else
                    {
                        enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damage - defEnemigo / 2);
                    }
                }
                else
                {
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damage * 3 / 5);
                }
            }
        }
    }

    public void gridAttack(GridManager grid)
    {
        GameManager.instance.GetAudioSource().PlayOneShot(efectosSonido[0]);
        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();
        foreach (var celda in grid.getGridInfo().GetCeldas())
        {

            if (celda.GetPersonaje() != null)
            {
                var enemigo = celda.GetPersonaje();
                var defEnemigo = enemigo.GetComponent<PlayerController>().getPersonaje().GetDefensa();
                var damageTotal = damage * Random.Range(0.9f, 0.95f);
                if (damage - defEnemigo > 0)
                {
                    if (enemigo.GetComponent<PlayerController>().getPersonaje().GetTipoAtaque() == TipoAtaque.SINGLE)
                    {
                        enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal + 0.25f - defEnemigo / 2);
                    }
                    else
                    {
                        enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal - defEnemigo / 2);
                    }
                }
                else
                {
                    enemigo.GetComponent<PlayerController>().getPersonaje().takeDamage(damageTotal * 3 / 5);
                }
            }

        }
    }

    public void healAttack(Celda celda)
    {
        Debug.Log(celda);
        GameManager.instance.GetAudioSource().PlayOneShot(efectosSonido[1]);
        var damage = GetComponent<EnemigoController>().getEnemigo().GetAtaque();
        if (celda.GetPersonaje() != null)
        {
            var enemigo = celda.GetPersonaje();
            var damageTotal = damage * Random.Range(0.35f, 0.5f);
            var particles = Instantiate(particulasCurar, enemigo.transform.position, Quaternion.Euler(-90, 0, 0));
            particles.transform.parent = enemigo.transform;
            particles.transform.localScale = Vector3.one;
            particles.Play();
            enemigo.GetComponent<EnemigoController>().getEnemigo().curar(damageTotal);
        }
    }
}
