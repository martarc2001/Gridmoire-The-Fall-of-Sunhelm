using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Personaje
{
    // ATRIBUTOS

    [SerializeField]
    private float vida;

    [SerializeField]
    private float ataque;

    [SerializeField]
    private float defensa;

    [SerializeField]
    private TipoAtaque tipoAtaque;
    
    // GETTERS & SETTERS

    public float GetVida() { return this.vida; }
    public float GetAtaque() { return this.ataque; }
    public float GetDefensa() { return this.defensa; }
    public TipoAtaque GetTipoAtaque() { return this.tipoAtaque; }

    public void SetVida(float vida) { this.vida = vida; }
    public void SetAtaque(float ataque) { this.ataque = ataque; }
    public void SetDefensa(float defensa) { this.defensa = defensa; }
    public void SetTipoAtaque(TipoAtaque tipoAtaque) { this.tipoAtaque = tipoAtaque; }

    public void takeDamage(float damage) { this.vida -= damage; }
}

[Serializable]
public enum TipoAtaque
{
    SINGLE, COLUMN, ROW, GRID, HEAL
}