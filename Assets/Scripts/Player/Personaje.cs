using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Personaje
{
    // ATRIBUTOS

    /*------ Identificador ------*/
    private string nombre;

    /*------ Estadisticas ------*/
    [SerializeField]
    private float vida;

    [SerializeField]
    private float vidaMax;

    [SerializeField]
    private float ataque;

    [SerializeField]
    private float defensa;

    /*------ Modificadores ------*/
    [SerializeField]
    private TipoAtaque tipoAtaque;

    private Rareza rareza;

    /*------ Nivel y experiencia ------*/
    private int nivel;

    private int xp;

    private int xpSubida;

    private int xpSubidaPrev;

    // CONSTRUCTORES

    public Personaje() { }

    public Personaje(string nombre, TipoAtaque tipoAtaque, Rareza rareza)
    {
        this.nombre = nombre;

        switch (rareza) {
            case Rareza.COMUN:
                this.vida = UnityEngine.Random.Range(14,26);
                this.ataque = UnityEngine.Random.Range(4, 6);
                this.defensa = UnityEngine.Random.Range(2, 5);
                this.vidaMax = this.vida;
                break;
            case Rareza.RARO:
                this.vida = UnityEngine.Random.Range(20, 31);
                this.ataque = UnityEngine.Random.Range(10, 14);
                this.defensa = UnityEngine.Random.Range(5, 8);
                this.vidaMax = this.vida;
                break;
            case Rareza.SUPER_RARO:
                this.vida = UnityEngine.Random.Range(25, 41);
                this.ataque = UnityEngine.Random.Range(12, 17);
                this.defensa = UnityEngine.Random.Range(7, 11);
                this.vidaMax = this.vida;
                break;
            default:
                break;
        }

        this.tipoAtaque = tipoAtaque;
        this.rareza = rareza;

        this.nivel = 1;
        this.xp = 0;

        this.xpSubida = 500;
        this.xpSubidaPrev = 250;
    }



    // GETTERS & SETTERS

    public string GetNombre() { return this.nombre; }
    public float GetVida() { return this.vida; }
    public float getVidaMax() { return this.vidaMax; }
    public float GetAtaque() { return this.ataque; }
    public float GetDefensa() { return this.defensa; }
    public TipoAtaque GetTipoAtaque() { return this.tipoAtaque; }
    public Rareza GetRareza() { return this.rareza; }
    public int GetNivel() { return this.nivel; }
    public int GetXp() { return this.xp; }
    public int GetXpSubida() { return this.xpSubida; }
    public int GetXpSubidaPrev() { return this.xpSubidaPrev; }

    public void SetNombre(string nombre) { this.nombre = nombre; }
    public void SetVida(float vida) { this.vida = vida; }
    public void SetAtaque(float ataque) { this.ataque = ataque; }
    public void SetDefensa(float defensa) { this.defensa = defensa; }
    public void SetTipoAtaque(TipoAtaque tipoAtaque) { this.tipoAtaque = tipoAtaque; }
    public void SetRareza(Rareza rareza) { this.rareza = rareza; }
    public void SetNivel(int nivel) { this.nivel = nivel; }
    public void SetXp(int xp) { this.xp += xp; }
    public void SetXpSubida(int xpSubida) { this.xpSubida = xpSubida; }
    public void SetXpSubidaPrev(int xpSubidaPrev) { this.xpSubidaPrev = xpSubidaPrev; }
    public void setVidaMax(float vidaMax) { this.vidaMax = vidaMax; }

    // METODOS

    public void takeDamage(float damage) { this.vida -= damage; }

    public void curar(float cura)
    {
        if(vida+cura > vidaMax)
        {
            vida = vidaMax;
        }
        else
        {
            vida += cura;
        }
    }

    private void SubirNivel()
    {
        this.nivel += 1;

        switch (rareza)
        {
            case Rareza.COMUN:
                this.vida += UnityEngine.Random.Range(3, 6);
                this.ataque += UnityEngine.Random.Range(2, 5);
                this.defensa += UnityEngine.Random.Range(1, 3);
                this.vidaMax = this.vida;
                break;
            case Rareza.RARO:
                this.vida += UnityEngine.Random.Range(5, 8);
                this.ataque += UnityEngine.Random.Range(3, 6);
                this.defensa += UnityEngine.Random.Range(2, 4);
                this.vidaMax = this.vida;
                break;
            case Rareza.SUPER_RARO:
                this.vida += UnityEngine.Random.Range(6, 11);
                this.ataque += UnityEngine.Random.Range(5, 8);
                this.defensa += UnityEngine.Random.Range(3, 6);
                this.vidaMax = this.vida;
                break;
            default:
                break;
        }
    }

    public void ComprobarNivel()
    {
        while (this.xp >= this.xpSubida)
        {
            this.SubirNivel();
            
            this.xp -= this.xpSubida; // Opcional
            
            int aux = this.xpSubida;
            this.xpSubida += this.xpSubidaPrev;
            this.xpSubidaPrev = aux;
        }
    }
}



[Serializable]
public enum TipoAtaque
{
    SINGLE, COLUMN, ROW, GRID, HEAL
}

public enum Rareza
{
    COMUN, RARO, SUPER_RARO
}

/*
 * 
 * Posible función de llamada de subir de nivel
 * 
 * public ComprobarNivel(){
 *      while(this.xp >= this.xpSubida){
 *          this.SubirNivel();
 *          
 *          this.xp -= this.xpSubida;
 *          
 *          int aux = this.xpSubida;
 *          this.xpSubida += this.xpSubidaPrev;
 *          this.xpSubidaPrev = aux;
 *       }
 * }
 * 
 */