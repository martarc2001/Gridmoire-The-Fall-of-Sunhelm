using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private Enemigo enemigo;
    [SerializeField] private List<Sprite> spritesEnemigos;

    public Enemigo getEnemigo() { return enemigo; }
    // Start is called before the first frame update
    public void crearEnemigo(int tipoEnemigo, int mundo, int nivel)
    {
        var level = nivel + (mundo - 1) * 10;
        transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = spritesEnemigos[tipoEnemigo];
        enemigo = new Enemigo((TipoEnemigo)tipoEnemigo, level);
    }

}
