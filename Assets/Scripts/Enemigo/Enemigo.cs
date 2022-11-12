using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private TipoEnemigo tipoEnemigo;
    [SerializeField] private PlayerController playerController;
    private Personaje enemigo;

    // Start is called before the first frame update
    public void crearEnemigo() 
    {
        enemigo = new Personaje();
        switch (tipoEnemigo)
        {
            case TipoEnemigo.PERRO_INFERNAL:
                crearPerro();
                break;
            case TipoEnemigo.MURICELAGO_VAMPIRO:
                crearMurcielago();
                break;
            case TipoEnemigo.GOBLIN:
                crearGoblin();
                break;
            case TipoEnemigo.DEMONIO_HEMBRA:
                crearDemonioHembra();
                break;
            case TipoEnemigo.DEMONIO_MACHO:
                crearDemonioMacho();
                break;
        }
    }

    private void crearPerro() 
    {
        var ataque = Random.Range(2, 7);
        var defensa = Random.Range(1, 6);
        var hp = Random.Range(5, 15);
        var tipoAtaque = Random.Range(0, 2);

        enemigo.SetAtaque(ataque);
        enemigo.SetDefensa(defensa);
        enemigo.SetVida(hp);
        enemigo.SetTipoAtaque((TipoAtaque)tipoAtaque);

        playerController.setPersonaje(enemigo);

        changeColorAttack(tipoAtaque);
    }

    private void crearMurcielago() 
    {
        var ataque = Random.Range(3, 8);
        var defensa = Random.Range(2, 8);
        var hp = Random.Range(5, 20);
        var tipoAtaque = Random.Range(1, 3);

        enemigo.SetAtaque(ataque);
        enemigo.SetDefensa(defensa);
        enemigo.SetVida(hp);
        enemigo.SetTipoAtaque((TipoAtaque)tipoAtaque);

        playerController.setPersonaje(enemigo);

        changeColorAttack(tipoAtaque);
    }

    private void crearGoblin() 
    {
        var ataque = Random.Range(5, 10);
        var defensa = Random.Range(4, 8);
        var hp = Random.Range(10, 25);
        var tipoAtaque = Random.Range(0, 3);

        enemigo.SetAtaque(ataque);
        enemigo.SetDefensa(defensa);
        enemigo.SetVida(hp);
        enemigo.SetTipoAtaque((TipoAtaque)tipoAtaque);

        playerController.setPersonaje(enemigo);

        changeColorAttack(tipoAtaque);
    }

    private void crearDemonioHembra() 
    {
        var ataque = Random.Range(8, 20);
        var defensa = Random.Range(8, 15);
        var hp = Random.Range(15, 30);
        var tipoAtaque = Random.Range(0, 5);

        enemigo.SetAtaque(ataque);
        enemigo.SetDefensa(defensa);
        enemigo.SetVida(hp);
        enemigo.SetTipoAtaque((TipoAtaque)tipoAtaque);

        playerController.setPersonaje(enemigo);

        changeColorAttack(tipoAtaque);
    }

    private void crearDemonioMacho() 
    {
        var ataque = Random.Range(8, 20);
        var defensa = Random.Range(8, 15);
        var hp = Random.Range(15, 30);
        var tipoAtaque = Random.Range(0, 5);

        enemigo.SetAtaque(ataque);
        enemigo.SetDefensa(defensa);
        enemigo.SetVida(hp);
        enemigo.SetTipoAtaque((TipoAtaque)tipoAtaque);

        playerController.setPersonaje(enemigo);

        changeColorAttack(tipoAtaque);
    }

    private void changeColorAttack(int tipo)
    {
        var at = transform.Find("Ataque").GetComponent<SpriteRenderer>();
        switch ((TipoAtaque)tipo)
        {
            case TipoAtaque.SINGLE:
                at.color = Color.red;
                break;
            case TipoAtaque.ROW:
                at.color = Color.blue;
                break;
            case TipoAtaque.COLUMN:
                at.color = Color.yellow;
                break;
            case TipoAtaque.GRID:
                at.color = Color.black;
                break;
            case TipoAtaque.HEAL:
                at.color = Color.green;
                break;
        }
    }
}

public enum TipoEnemigo
{
    PERRO_INFERNAL,
    MURICELAGO_VAMPIRO,
    GOBLIN,
    DEMONIO_HEMBRA,
    DEMONIO_MACHO
}
