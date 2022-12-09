using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class ListaPlayerSerializable
{
    public List<SerializablePlayer> list= new List<SerializablePlayer>();
}

[Serializable]
public class SerializablePlayer
{
    public int flequillo;
    public int pelo;
    public int pestanha;
    public int orejas;
    public int narices;
    public int bocas;
    public int extras;
    public int cejas;
    public int ropa;
    public int arma_delante;
    public int arma_detras;
    public float rc;
    public float gc;
    public float bc;
    public float rp;
    public float gp;
    public float bp;
    public float ri;
    public float gi;
    public float bi;

    public float ataque;
    public float defensa;
    public float vida;
    public float vidaMax;
    public int tipoAtaque;

    public float ataqueBase;
    public float defensaBase;
    public float vidaBase;

    public string nombre;
    public int rareza;

    public int nivel;
    public int xp;
    public int xpSubida;
    

    public SerializablePlayer() { }


    public SerializablePlayer(int flequillo, int pelo, int pestanha, int orejas, int narices, int bocas,
        int extras, int cejas, int ropa, int arma_delante, int arma_detras, float rc, float gc, float bc, float rp, float gp, float bp, float ri, float gi, float bi, 
        float ataque, float defensa, float vida, float vidaMax, int tipoAtaque, float ataqueBase, 
        float defensaBase, float vidaBase, string nombre, int rareza,int nivel, int xp,
        int xpSubida)

    {
        this.flequillo = flequillo;
        this.pelo = pelo;
        this.pestanha = pestanha;
        this.orejas = orejas;
        this.narices = narices;
        this.bocas = bocas;
        this.extras = extras;
        this.cejas = cejas;
        this.ropa = ropa;
        this.rc = rc;
        this.gc = gc;
        this.bc = bc;
        this.rp = rp;
        this.gp = gp;
        this.bp = bp;
        this.ri = ri;
        this.gi = gi;
        this.bi = bi;
        this.arma_delante = arma_delante;
        this.arma_detras = arma_detras;
        this.ataque = ataque;
        this.defensa = defensa;
        this.vida = vida;
        this.vidaMax = vidaMax;
        this.tipoAtaque = tipoAtaque;
        this.ataqueBase = ataqueBase;
        this.defensaBase = defensaBase;
        this.vidaBase = vidaBase;
        this.nombre = nombre;
        this.rareza = rareza;  
        this.nivel = nivel;
        this.xp = xp;
        this.xpSubida = xpSubida;
    }
}
