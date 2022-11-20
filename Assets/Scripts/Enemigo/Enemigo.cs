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

    public Enemigo(TipoEnemigo tipoEnemigo, int nivel) 
    {
        switch (tipoEnemigo)
        {
            case TipoEnemigo.PERRO_INFERNAL:
                ataque = Random.Range(2+nivel, 7+nivel);
                defensa = Random.Range(1+nivel, 6+nivel);
                vida = Random.Range(5+nivel, 15+nivel);
                vidaMax = vida;
                tipoAtaque = (TipoAtaque)Random.Range(0, 2);
                break;

            case TipoEnemigo.MURICELAGO_VAMPIRO:
                ataque = Random.Range(3+nivel, 9+nivel);
                defensa = Random.Range(2+nivel, 6+nivel);
                vida = Random.Range(5+nivel, 20+nivel);
                vidaMax = vida;
                tipoAtaque = (TipoAtaque)Random.Range(1, 3);
                break;

            case TipoEnemigo.GOBLIN:
                ataque = Random.Range(5+nivel, 10+nivel);
                defensa = Random.Range(4+nivel, 8+nivel);
                vida = Random.Range(10+nivel, 25+nivel);
                vidaMax = vida;
                tipoAtaque = (TipoAtaque)Random.Range(0, 3);
                break;

            case TipoEnemigo.DEMONIO_HEMBRA:
                ataque = Random.Range(12+nivel, 20+nivel);
                defensa = Random.Range(8+nivel, 18+nivel);
                vida = Random.Range(15+nivel, 30+nivel);
                vidaMax = vida;
                tipoAtaque = (TipoAtaque)Random.Range(0, 5);
                break;

            case TipoEnemigo.DEMONIO_MACHO:
                ataque = Random.Range(10+nivel, 18 + nivel);
                defensa = Random.Range(10+nivel, 20+nivel);
                vida = Random.Range(15 + nivel, 30 +nivel);
                vidaMax = vida;
                tipoAtaque = (TipoAtaque)Random.Range(0, 5);
                break;
        }
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