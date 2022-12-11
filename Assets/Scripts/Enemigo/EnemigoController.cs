using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private Enemigo enemigo;
    [SerializeField] private List<Sprite> spritesEnemigos;

    public Enemigo getEnemigo() { return enemigo; }
    // Start is called before the first frame update
    public void crearEnemigo(int tipoEnemigo, int mundo, int nivel, int tipoAtaque)
    {
        var level = nivel + (mundo - 1) * 10;


        switch (tipoEnemigo)
        {
            case 0:
                transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = spritesEnemigos[Random.Range(0,3)];
                break;
            case 1:
                transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = spritesEnemigos[Random.Range(3, 6)];
                break;
            case 2:
                transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = spritesEnemigos[Random.Range(6, 9)];
                transform.Find("Sprite").GetComponent<SpriteRenderer>().flipX= true;
                break;
            case 3:
                transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = spritesEnemigos[Random.Range(9, 12)];
                transform.Find("Sprite").GetComponent<SpriteRenderer>().flipX = true;
                break;
            case 4: 
                transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = spritesEnemigos[Random.Range(12, 15)];
                transform.Find("Sprite").GetComponent<SpriteRenderer>().flipX = true;
                break;
        }
        
        enemigo = new Enemigo((TipoEnemigo)tipoEnemigo, level, (TipoAtaque)tipoAtaque);
    }

}
