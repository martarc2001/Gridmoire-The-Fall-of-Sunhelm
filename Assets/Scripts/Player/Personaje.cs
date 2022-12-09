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

    private float vidaBase;

    private float ataqueBase;

    private float defensaBase;

    /*------ Modificadores ------*/
    [SerializeField]
    private TipoAtaque tipoAtaque;

    private Rareza rareza;

    /*------ Nivel y experiencia ------*/
    private int nivel;

    private int xp;

    private int xpSubida;


    // CONSTRUCTORES

    public Personaje() { }

    public Personaje(string nombre, TipoAtaque tipoAtaque, Rareza rareza)
    {
        this.nombre = nombre;

        switch (rareza) {
            case Rareza.COMUN:
                this.vidaBase = this.vida = UnityEngine.Random.Range(14,26);
                this.ataqueBase = this.ataque = UnityEngine.Random.Range(4, 6);
                this.defensaBase = this.defensa = UnityEngine.Random.Range(2, 5);
                this.vidaMax = this.vida;
                break;
            case Rareza.RARO:
                this.vidaBase = this.vida = UnityEngine.Random.Range(20, 31);
                this.ataqueBase = this.ataque = UnityEngine.Random.Range(10, 14);
                this.defensa = this.defensa = UnityEngine.Random.Range(5, 8);
                this.vidaMax = this.vida;
                break;
            case Rareza.SUPER_RARO:
                this.vidaBase = this.vida = UnityEngine.Random.Range(25, 41);
                this.ataqueBase = this.ataque = UnityEngine.Random.Range(12, 17);
                this.defensaBase = this.defensa = UnityEngine.Random.Range(7, 11);
                this.vidaMax = this.vida;
                break;
            default:
                break;
        }

        this.tipoAtaque = tipoAtaque;
        this.rareza = rareza;

        this.nivel = 1;
        this.xp = 0;

        this.xpSubida = (int)1600/5;
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
    public float GetAtaqueBase() { return this.ataqueBase; }
    public float GetDefensaBase() { return this.defensaBase; }
    public float GetVidaBase() { return this.vidaBase; }

    public void SetNombre(string nombre) { this.nombre = nombre; }
    public void SetVida(float vida) { this.vida = vida; }
    public void SetAtaque(float ataque) { this.ataque = ataque; }
    public void SetDefensa(float defensa) { this.defensa = defensa; }
    public void SetTipoAtaque(TipoAtaque tipoAtaque) { this.tipoAtaque = tipoAtaque; }
    public void SetAtaqueBase(float ataqueBase) { this.ataqueBase = ataqueBase; }
    public void SetDefensaBase(float defensaBase) { this.defensaBase = defensaBase; }
    public void SetVidaBase(float vidaBase) { this.vidaBase = vidaBase; }
    public void SetRareza(Rareza rareza) { this.rareza = rareza; }
    public void SetNivel(int nivel) { this.nivel = nivel; }
    public void SetXp(int xp) { this.xp += xp; }
    public void SetXpSubida(int xpSubida) { this.xpSubida = xpSubida; }
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
                
                this.vidaMax += (float)Math.Pow(this.nivel, 2) / (6 - (this.vidaBase / 10)) < 1 ? 1 :
                    (float)Math.Pow(this.nivel, 2) / (6 - (this.vidaBase / 10));

                this.ataque += (float)Math.Pow(this.nivel, 2) / (6 - (this.ataqueBase / 10)) < 1 ? 1 :
                    (float)Math.Pow(this.nivel, 2) / (6 - (this.ataqueBase / 10));

                this.defensa += (float)Math.Pow(this.nivel, 2) / (6 - (this.defensaBase / 10)) < 1 ? 1 :
                    (float)Math.Pow(this.nivel, 2) / (6 - (this.defensaBase / 10)) ;

                this.vida = this.vidaMax;
                break;
            case Rareza.RARO:

                this.vidaMax += (float)Math.Pow(this.nivel, 2) / (6 - (this.vidaBase / 10)) < 1 ? 1 :
                    (float)Math.Pow(this.nivel, 2) / (6 - (this.vidaBase / 10));

                this.ataque += (float)Math.Pow(this.nivel, 2) / (6 - (this.ataqueBase / 10)) < 1 ? 1 :
                    (float)Math.Pow(this.nivel, 2) / (6 - (this.ataqueBase / 10));

                this.defensa += (float)Math.Pow(this.nivel, 2) / (6 - (this.defensaBase / 10)) < 1 ? 1 :
                    (float)Math.Pow(this.nivel, 2) / (6 - (this.defensaBase / 10));

                this.vida = this.vidaMax;
                break;
            case Rareza.SUPER_RARO:

                this.vidaMax += (float)Math.Pow(this.nivel, 2) / (6 - (this.vidaBase / 10)) < 1 ? 1 :
                    (float)Math.Pow(this.nivel, 2) / (6 - (this.vidaBase / 10));

                this.ataque += (float)Math.Pow(this.nivel, 2) / (6 - (this.ataqueBase / 10)) < 1 ? 1 :
                    (float)Math.Pow(this.nivel, 2) / (6 - (this.ataqueBase / 10));

                this.defensa += (float)Math.Pow(this.nivel, 2) / (6 - (this.defensaBase / 10)) < 1 ? 1 :
                    (float)Math.Pow(this.nivel, 2) / (6 - (this.defensaBase / 10));

                this.vida = this.vidaMax;
                break;
            default:
                break;
        }
    }

    public void ComprobarNivel()
    {
        if(this.nivel < 30)
        {
            while (this.xp >= this.xpSubida)
            {
                this.SubirNivel();

                this.xpSubida = (int)((4 * (Math.Pow(this.nivel + 1, 2))) / 5) * 100;
            }
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