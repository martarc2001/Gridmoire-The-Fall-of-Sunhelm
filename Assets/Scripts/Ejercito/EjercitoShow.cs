using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EjercitoShow : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject prefab;
    private ListaPlayerSerializable spl = new ListaPlayerSerializable();

    [Header("Spawn Position")]
    [SerializeField] private Transform spawn;

    [Header("No personajes")]
    [SerializeField] private GameObject noPersonajes;

    [Header("Stats canvas")]
    [SerializeField] private GameObject stats;
    private int indice;

    [Header("Sprites lists")]
    [SerializeField] private List<string> nombres;
    [SerializeField] private List<string> titulos;
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

    private GameObject characterShow;

    public void changeRareness(string rareness)
    {
        switch (rareness)
        {
            case "Comun":

                //cambio de rareza y carga de PlayerPref de esa rareza
                spl.list.Clear();
                indice = 0;
                var com = PlayerPrefs.GetString("commons");

                if (!string.IsNullOrEmpty(com))
                {
                    spl = JsonUtility.FromJson<ListaPlayerSerializable>(com);
                }
                break;
            case "Raro":
                //cambio de rareza y carga de PlayerPref de esa rareza
                spl.list.Clear();
                indice = 0;
                var rar = PlayerPrefs.GetString("rares");

                if (!string.IsNullOrEmpty(rar))
                {
                    spl = JsonUtility.FromJson<ListaPlayerSerializable>(rar);
                }
                break;
            case "SuperRaro":
                //cambio de rareza y carga de PlayerPref de esa rareza
                spl.list.Clear();
                indice = 0;
                var ur = PlayerPrefs.GetString("superRares");

                if (!string.IsNullOrEmpty(ur))
                {
                    spl = JsonUtility.FromJson<ListaPlayerSerializable>(ur);
                }
                break;
        }

        if (spl.list.Count>0) 
        {
            noPersonajes.SetActive(false);
            showCharacter();

        }
        else
        {
            noPersonajes.SetActive(true);
            stats.SetActive(false);
            if(characterShow != null)
            {
                Destroy(characterShow.gameObject);
            }
        }
        
    }

    public void showCharacter()
    {
        if(characterShow != null)
        {
            Destroy(characterShow.gameObject);
        }

        SerializablePlayer sp = spl.list[indice];
        var newCharacter = Instantiate(prefab, spawn.position, Quaternion.identity);

        Debug.Log(spl.list[indice].nombre);
        /////// CHARACTER CUSTOMIZATION ///////

        var newFlequillo = newCharacter.transform.Find("Flequillo").GetComponent<SpriteRenderer>();
        newFlequillo.sprite = flequillos[sp.flequillo];

        var newPelo = newCharacter.transform.Find("Pelo").GetComponent<SpriteRenderer>();
        newPelo.sprite = pelos[sp.pelo];

        var newPestanhas = newCharacter.transform.Find("Pestanhas").GetComponent<SpriteRenderer>();
        newPestanhas.sprite = pestanhas[sp.pestanha];

        var newOrejas = newCharacter.transform.Find("Orejas").GetComponent<SpriteRenderer>();
        newOrejas.sprite = orejas[sp.orejas];

        var newNarices = newCharacter.transform.Find("Nariz").GetComponent<SpriteRenderer>();
        newNarices.sprite = narices[sp.narices];

        var newBoca = newCharacter.transform.Find("Boca").GetComponent<SpriteRenderer>();
        newBoca.sprite = bocas[sp.bocas];

        var newExtra = newCharacter.transform.Find("Extra").GetComponent<SpriteRenderer>();
        newExtra.sprite = extras[sp.extras];

        var newCejas = newCharacter.transform.Find("Cejas").GetComponent<SpriteRenderer>();
        newCejas.sprite = cejas[sp.cejas];

        var ropa = newCharacter.transform.Find("Ropa").GetComponent<SpriteRenderer>();
        ropa.sprite = ropas[sp.ropa];

        var armaDelante = newCharacter.transform.Find("Arma_delante").GetComponent<SpriteRenderer>();
        armaDelante.sprite = armas_delante[sp.arma_delante];

        var armaDetras = newCharacter.transform.Find("Arma_detras").GetComponent<SpriteRenderer>();
        armaDetras.sprite = armas_detras[sp.arma_detras];

        var cuerpo = newCharacter.transform.Find("CUERPO BASE").GetComponent<SpriteRenderer>();
        cuerpo.color = new Color(sp.rc, sp.gc, sp.bc);

        newCharacter.transform.Find("Cara").GetComponent<SpriteRenderer>().color = new Color(sp.rc, sp.gc, sp.bc);
        newOrejas.color = new Color(sp.rc, sp.gc, sp.bc);

        newFlequillo.color = new Color(sp.rp, sp.gp, sp.bp);
        newPelo.color = new Color(sp.rp, sp.gp, sp.bp);
        newCejas.color = new Color(sp.rp, sp.gp, sp.bp);
        newExtra.color = new Color(sp.rp, sp.gp, sp.bp);

        var newIris = newCharacter.transform.Find("Ojos").transform.Find("Iris").GetComponent<SpriteRenderer>();
        newIris.color = new Color(sp.rp, sp.gi, sp.bi);

        

        newCharacter.transform.Find("Ataque").GetComponent<SpriteRenderer>().sprite = tiposAtaque[sp.tipoAtaque];

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
        newCharacter.GetComponent<PlayerController>().setPersonaje(personaje);

        var nombreStats = "Nombre: " + sp.nombre;
        var vidaStats = "Vida: " + sp.vidaMax;
        var ataqueStats = "Ataque: " + sp.ataque;
        var defensaStats = "Defensa: " + sp.defensa;
        var nivelStats = "Nivel: " + sp.nivel;
        var xpStats = "Experiencia: " + sp.xp + "/"+sp.xpSubida;

        stats.SetActive(true);

        stats.transform.Find("Nombre").GetComponent<TextMeshProUGUI>().text = nombreStats;
        stats.transform.Find("Vida").GetComponent<TextMeshProUGUI>().text = vidaStats;
        stats.transform.Find("Ataque").GetComponent<TextMeshProUGUI>().text = ataqueStats;
        stats.transform.Find("Defensa").GetComponent<TextMeshProUGUI>().text = defensaStats;
        stats.transform.Find("Nivel").GetComponent<TextMeshProUGUI>().text = nivelStats;
        stats.transform.Find("XP").GetComponent<TextMeshProUGUI>().text = xpStats;

        characterShow = newCharacter;
    }

    public void nextCharacter()
    {
        if(spl.list.Count > 0)
        {
            indice++;
            if (indice >= spl.list.Count)
            {
                indice = 0;
            }

            showCharacter();
        }
        
        
    }

    public void prevCharacter()
    {
        if(spl.list.Count > 0)
        {
            indice--;
            if (indice < 0)
            {
                indice = spl.list.Count-1;
            }

            showCharacter();
        }
       
        
    }
}
