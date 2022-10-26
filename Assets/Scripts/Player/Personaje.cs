using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje
{
    // ATRIBUTOS

    private float vida;
    private float ataque;
    private float defensa;
    private TipoAtaque tipoAtaque;

    private GameObject sprite;

    // GETTERS & SETTERS

    public float GetVida() { return this.vida; }
    public float GetAtaque() { return this.ataque; }
    public float GetDefensa() { return this.defensa; }
    public TipoAtaque GetTipoAtaque() { return this.tipoAtaque; }
    public GameObject GetSprite() { return this.sprite; }

    public void SetVida(float vida) { this.vida = vida; }
    public void SetAtaque(float ataque) { this.ataque = ataque; }
    public void SetDefensa(float defensa) { this.defensa = defensa; }
    public void SetTipoAtaque(TipoAtaque tipoAtaque) { this.tipoAtaque = tipoAtaque; }
    public void SetSprite(GameObject sprite) { this.sprite = sprite; }
}


public enum TipoAtaque
{
    SINGLE, COLUMN, ROW, GRID, HEAL
}