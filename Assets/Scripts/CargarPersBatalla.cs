using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersBatalla : MonoBehaviour
{
    private ListaPlayerSerializable grid;
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<CeldaManager> headPosition;
    [SerializeField] private List<GameObject> cabezasInfo;

    [SerializeField] private GridManager gridPlayer;

    [SerializeField] private LevelFlow level;

    [SerializeField] private List<Sprite> flequillos;
    [SerializeField] private List<Sprite> pelos;
    [SerializeField] private List<Sprite> pestanhas;
    [SerializeField] private List<Sprite> orejas;
    [SerializeField] private List<Sprite> narices;
    [SerializeField] private List<Sprite> bocas;
    [SerializeField] private List<Sprite> extras;
    [SerializeField] private List<Sprite> cejas;
    [SerializeField] private List<Sprite> ropas;

    [SerializeField] private List<Sprite> armas_delante;
    [SerializeField] private List<Sprite> armas_detras;

    [SerializeField] private List<Sprite> tiposAtaque;


    [SerializeField] private List<LifeUI> listaVidas;
    private void Start()
    {
        grid = FindObjectOfType<DataToBattle>().getLSP();
        var celdas = FindObjectOfType<DataToBattle>().getCeldas();

        var posSituar = new List<Transform>();


        foreach(var celda in celdas)
        {
            for(var i = 0; i < headPosition.Count; i++)
            {
                if(celda.getCelda().GetX() == headPosition[i].getCelda().GetX() 
                    && celda.getCelda().GetY() == headPosition[i].getCelda().GetY())
                {
                    posSituar.Add(headPosition[i].transform);
                }
            }

            
        }

        for (var i = 0; i < grid.list.Count; i++)
        {
            instanciarPersonaje(grid.list[i], posSituar[i], celdas[i]);
            cabezasInfo[i].SetActive(true);
            cargarCabeza(grid.list[i], cabezasInfo[i]);
        }

        foreach(var celda in gridPlayer.getCeldas())
        {
            foreach (var barra in listaVidas)
            {
                var cell = barra.GetCelda().getCelda();
                if (cell.GetX() == celda.getCelda().GetX() && cell.GetY() == celda.getCelda().GetY())
                {
                    if(celda.getCelda().GetPersonaje() != null)
                    {
                        barra.setPlayer(celda.getCelda().GetPersonaje().GetComponent<PlayerController>());
                        barra.activar();
                    }
                    
                }
            }
        }
    }

    public GridManager GetGridManager() { return gridPlayer; }
    private void instanciarPersonaje(SerializablePlayer sp, Transform transPos, CeldaManager celda)
    {
        var newCharacter = Instantiate(prefab, transPos.position, Quaternion.identity);
        newCharacter.transform.SetParent(transPos);

        switch (celda.getCelda().GetX())
        {
            case 0:
                if(celda.getCelda().GetY() == 0)
                {
                    newCharacter.transform.position = new Vector3(transPos.position.x+0.019f, transPos.position.y + 0.766f, 1f);
                }else if(celda.getCelda().GetY() == 1)
                {
                    newCharacter.transform.position = new Vector3(transPos.position.x+0.005f, transPos.position.y + 0.805f, 1f);
                }
                else
                {
                    newCharacter.transform.position = new Vector3(transPos.position.x+0.261f, transPos.position.y + 0.794f, 1f);
                }
                newCharacter.transform.localScale = new Vector3(0.6f, 0.6f, 1f); 
                break;
            case 1:
                if (celda.getCelda().GetY() == 0)
                {
                    newCharacter.transform.position = new Vector3(transPos.position.x+0.044f, transPos.position.y+0.933f, 1f);
                }
                else if (celda.getCelda().GetY() == 1)
                {
                    newCharacter.transform.position = new Vector3(transPos.position.x+0.039f, transPos.position.y+0.961f, 1f);
                }
                else
                {
                    newCharacter.transform.position = new Vector3(transPos.position.x+0.03f, transPos.position.y+0.905f, 1f);
                }
                newCharacter.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
                break;
            case 2:
                if (celda.getCelda().GetY() == 0)
                {
                    newCharacter.transform.position = new Vector3(transPos.position.x + 0.05f, transPos.position.y +1.072f, 1f);
                }
                else if (celda.getCelda().GetY() == 1)
                {
                    newCharacter.transform.position = new Vector3(transPos.position.x+0.022f, transPos.position.y+1.049f, 1f);
                }
                else
                {
                    newCharacter.transform.position = new Vector3(transPos.position.x-0.027f, transPos.position.y +1.011f, 1f);
                }
                newCharacter.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
                break;
        }
        /////// CHARACTER CUSTOMIZATION ///////

        var newFlequillo = newCharacter.transform.Find("Flequillo").GetComponent<SpriteRenderer>();
        newFlequillo.sprite = flequillos[sp.flequillo-1];

        var newPelo = newCharacter.transform.Find("Pelo").GetComponent<SpriteRenderer>();
        newPelo.sprite = pelos[sp.pelo-1];

        var newPestanhas = newCharacter.transform.Find("Pestanhas").GetComponent<SpriteRenderer>();
        newPestanhas.sprite = pestanhas[sp.pestanha-1];

        var newOrejas = newCharacter.transform.Find("Orejas").GetComponent<SpriteRenderer>();
        newOrejas.sprite = orejas[sp.orejas-1];

        var newNarices = newCharacter.transform.Find("Nariz").GetComponent<SpriteRenderer>();
        newNarices.sprite = narices[sp.narices-1];

        var newBoca = newCharacter.transform.Find("Boca").GetComponent<SpriteRenderer>();
        newBoca.sprite = bocas[sp.bocas-1];

        var newExtra = newCharacter.transform.Find("Extra").GetComponent<SpriteRenderer>();
        newExtra.sprite = extras[sp.extras-1];

        var newCejas = newCharacter.transform.Find("Cejas").GetComponent<SpriteRenderer>();
        newCejas.sprite = cejas[sp.cejas-1];

        var ropa = newCharacter.transform.Find("Ropa").GetComponent<SpriteRenderer>();
        ropa.sprite = ropas[sp.ropa-1];

        var armaDelante = newCharacter.transform.Find("Arma_delante").GetComponent<SpriteRenderer>();
        armaDelante.sprite = armas_delante[sp.arma_delante - 1];

        var armaDetras = newCharacter.transform.Find("Arma_detras").GetComponent<SpriteRenderer>();
        armaDetras.sprite = armas_detras[sp.arma_detras - 1];

        var cuerpo = newCharacter.transform.Find("CUERPO BASE").GetComponent<SpriteRenderer>();
        cuerpo.color = new Color(sp.rc, sp.gc, sp.bc);

        newFlequillo.color = new Color(sp.rp, sp.gp, sp.bp);
        newPelo.color = new Color(sp.rp, sp.gp, sp.bp);

        var newIris = newCharacter.transform.Find("Ojos").transform.Find("Iris").GetComponent<SpriteRenderer>();
        newIris.color = new Color(sp.rp, sp.gi, sp.bi);

        var personaje = new Personaje();
        personaje.SetAtaque(sp.ataque);
        personaje.SetDefensa(sp.defensa);
        personaje.SetVida(sp.vida);
        personaje.setVidaMax(sp.vidaMax);
        personaje.SetTipoAtaque((TipoAtaque)sp.tipoAtaque);
        personaje.SetNombre(sp.nombre);
        personaje.SetRareza((Rareza)sp.rareza);
        personaje.SetNivel(sp.nivel);
        personaje.SetXp(sp.xp);
        personaje.SetXpSubida(sp.xpSubida);
        personaje.SetXpSubidaPrev(sp.xpSubidaPrev);
        newCharacter.GetComponent<PlayerController>().setPersonaje(personaje);

        gridPlayer.getGridInfo().GetCeldas()[celda.getCelda().GetX(), celda.getCelda().GetY()].SetPersonaje(newCharacter);
        gridPlayer.getGridInfo().GetCeldas()[celda.getCelda().GetX(), celda.getCelda().GetY()].NowOccupied();

        
        level.addPersonaje(newCharacter.GetComponent<PlayerController>());
    }

    private void cargarCabeza(SerializablePlayer sp, GameObject cabeza)
    {
        cabeza.transform.Find("Flequillo").GetComponent<SpriteRenderer>().sprite = flequillos[sp.flequillo-1];

        cabeza.transform.Find("Cejas").GetComponent<SpriteRenderer>().sprite = cejas[sp.cejas - 1];
        cabeza.transform.Find("Extra").GetComponent<SpriteRenderer>().sprite = extras[sp.extras - 1];
        cabeza.transform.Find("Pestanhas").GetComponent<SpriteRenderer>().sprite = pestanhas[sp.pestanha - 1];

        cabeza.transform.Find("Nariz").GetComponent<SpriteRenderer>().sprite = narices[sp.narices - 1];
        cabeza.transform.Find("Boca").GetComponent<SpriteRenderer>().sprite = bocas[sp.bocas - 1];
        cabeza.transform.Find("Orejas").GetComponent<SpriteRenderer>().sprite = orejas[sp.orejas - 1];

        cabeza.transform.Find("Flequillo").GetComponent<SpriteRenderer>().color = new Color(sp.rp, sp.gp, sp.bp);

        cabeza.transform.Find("Ojos").transform.Find("Iris").GetComponent<SpriteRenderer>().color = new Color(sp.rp, sp.gi, sp.bi);


        var ataque = cabeza.transform.Find("Ataque").GetComponent<SpriteRenderer>();

        switch (sp.tipoAtaque)
        {
            case (int)TipoAtaque.SINGLE:
                ataque.sprite = tiposAtaque[0];
                break;
            case (int)TipoAtaque.ROW:
                ataque.sprite = tiposAtaque[1];
                break;
            case (int)TipoAtaque.COLUMN:
                ataque.sprite = tiposAtaque[2];
                break;
            case (int)TipoAtaque.GRID:
                ataque.sprite = tiposAtaque[3];
                break;
            case (int)TipoAtaque.HEAL:
                ataque.sprite = tiposAtaque[4];
                break;
        }
    }
}
