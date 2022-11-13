using UnityEngine;

public class Enemigo
{
    /*------ Estadisticas ------*/
    [SerializeField]
    private float vida;

    [SerializeField]
    private float ataque;

    [SerializeField]
    private float defensa;

    /*------ Modificadores ------*/
    [SerializeField]
    private TipoAtaque tipoAtaque;

    public Enemigo() { }

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

public enum TipoEnemigo
{
    PERRO_INFERNAL,
    MURICELAGO_VAMPIRO,
    GOBLIN,
    DEMONIO_HEMBRA,
    DEMONIO_MACHO
}