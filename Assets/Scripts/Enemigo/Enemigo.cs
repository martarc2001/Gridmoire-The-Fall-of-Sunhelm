using System;
using UnityEngine;

public class Enemigo
{
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

    public Enemigo(TipoEnemigo tipoEnemigo, int nivel, TipoAtaque tipoAtaque) 
    {
        switch (tipoEnemigo)
        {
            case TipoEnemigo.PERRO_INFERNAL:
                ataque = UnityEngine.Random.Range(2, 4);
                ataque += (float)Math.Pow(nivel, 2) / (6 - (ataque / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (ataque / 15));

                defensa = UnityEngine.Random.Range(1, 3);
                defensa += (float)Math.Pow(nivel, 2) / (6 - (defensa / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (defensa / 15));

                vida = UnityEngine.Random.Range(7, 15);
                vida += (float)Math.Pow(nivel, 2) / (6 - (vida / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (vida / 15));
                vidaMax = vida;
                this.tipoAtaque = tipoAtaque;
                break;

            case TipoEnemigo.MURICELAGO_VAMPIRO:
                ataque = UnityEngine.Random.Range(3, 5);
                ataque += (float)Math.Pow(nivel, 2) / (6 - (ataque / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (ataque / 15));

                defensa = UnityEngine.Random.Range(3, 5);
                defensa += (float)Math.Pow(nivel, 2) / (6 - (defensa / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (defensa / 15));

                vida = UnityEngine.Random.Range(9, 19);
                vida += (float)Math.Pow(nivel, 2) / (6 - (vida / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (vida / 15));

                vidaMax = vida;
                this.tipoAtaque = tipoAtaque;
                break;

            case TipoEnemigo.GOBLIN:
                ataque = UnityEngine.Random.Range(5, 10);
                ataque += (float)Math.Pow(nivel, 2) / (6 - (ataque / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (ataque / 15));

                defensa = UnityEngine.Random.Range(4, 8);
                defensa += (float)Math.Pow(nivel, 2) / (6 - (defensa / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (defensa / 15));

                vida = UnityEngine.Random.Range(19, 29);
                vida += (float)Math.Pow(nivel, 2) / (6 - (vida / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (vida / 15));

                vidaMax = vida;
                this.tipoAtaque = tipoAtaque;
                break;

            case TipoEnemigo.DEMONIO_HEMBRA:
                ataque = UnityEngine.Random.Range(11, 17);
                ataque += (float)Math.Pow(nivel, 2) / (6 - (ataque / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (ataque / 15));

                defensa = UnityEngine.Random.Range(6, 10);
                defensa += (float)Math.Pow(nivel, 2) / (6 - (defensa / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (defensa / 15));

                vida = UnityEngine.Random.Range(24, 38);
                vida += (float)Math.Pow(nivel, 2) / (6 - (vida / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (vida / 15));

                vidaMax = vida;
                this.tipoAtaque = tipoAtaque;
                break;

            case TipoEnemigo.DEMONIO_MACHO:
                ataque = UnityEngine.Random.Range(10, 14);
                ataque += (float)Math.Pow(nivel, 2) / (6 - (ataque / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (ataque / 15));

                defensa = UnityEngine.Random.Range(8, 12);
                defensa += (float)Math.Pow(nivel, 2) / (6 - (defensa / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (defensa / 15));

                vida = UnityEngine.Random.Range(24, 38);
                vida += (float)Math.Pow(nivel, 2) / (6 - (vida / 15)) < 1 ? 1 :
                    (float)Math.Pow(nivel, 2) / (6 - (vida / 15));

                vidaMax = vida;
                this.tipoAtaque = tipoAtaque;
                break;
        }

        Debug.Log(ataque + " " + defensa + " " + vida);
    }

    public float GetVida() { return this.vida; }
    public float GetVidaMax() { return this.vidaMax; }
    public float GetAtaque() { return this.ataque; }
    public float GetDefensa() { return this.defensa; }
    public TipoAtaque GetTipoAtaque() { return this.tipoAtaque; }
    public void SetVida(float vida) { this.vida = vida; }
    public void SetVidaMax(float vidaMax) { this.vidaMax = vidaMax; }
    public void SetAtaque(float ataque) { this.ataque = ataque; }
    public void SetDefensa(float defensa) { this.defensa = defensa; }
    public void SetTipoAtaque(TipoAtaque tipoAtaque) { this.tipoAtaque = tipoAtaque; }

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
}

public enum TipoEnemigo
{
    PERRO_INFERNAL,
    MURICELAGO_VAMPIRO,
    GOBLIN,
    DEMONIO_HEMBRA,
    DEMONIO_MACHO
}