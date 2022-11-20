using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CargarPersonajes : MonoBehaviour
{
    private ListaPlayerSerializable lsp = new ListaPlayerSerializable();
    [SerializeField] private GameObject lspPrefab;

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

    // Start is called before the first frame update
    void Start()
    {
        changeRareness("Comun");

    }

    public void changeRareness(string rareness)
    {

        lsp.list.Clear();
        vaciarLista();
        switch(rareness) 
        {
            case "Comun":
                string com = PlayerPrefs.GetString("commons");

                if (!string.IsNullOrEmpty(com))
                {
                    lsp = JsonUtility.FromJson<ListaPlayerSerializable>(com);

                    foreach (var p in lsp.list)
                    {
                        instanciarPersonaje(p);
                    }
                }
                break;
            case "Raro":
                string rar = PlayerPrefs.GetString("rares");

                if (!string.IsNullOrEmpty(rar))
                {
                    lsp = JsonUtility.FromJson<ListaPlayerSerializable>(rar);

                    foreach (var p in lsp.list)
                    {
                        instanciarPersonaje(p);
                    }
                }
                break;
            case "SuperRaro":
                string sr = PlayerPrefs.GetString("superRares");

                if (!string.IsNullOrEmpty(sr))
                {
                    lsp = JsonUtility.FromJson<ListaPlayerSerializable>(sr);

                    foreach (var p in lsp.list)
                    {
                        instanciarPersonaje(p);
                    }
                }
                break;
        }
    }

    private void vaciarLista()
    {
        for(var i =0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }


    private void instanciarPersonaje(SerializablePlayer sp)
    {
        var uiCharacter = Instantiate(lspPrefab,transform);

        var newCharacter = uiCharacter.transform.Find("Character");

        /////// CHARACTER CUSTOMIZATION ///////

        var newFlequillo = newCharacter.transform.Find("Flequillo").GetComponent<Image>();
        newFlequillo.sprite = flequillos[sp.flequillo];

        var newPelo = newCharacter.transform.Find("Pelo").GetComponent<Image>();
        newPelo.sprite = pelos[sp.pelo];

        var newPestanhas = newCharacter.transform.Find("Pestanhas").GetComponent<Image>();
        newPestanhas.sprite = pestanhas[sp.pestanha];

        var newOrejas = newCharacter.transform.Find("Orejas").GetComponent<Image>();
        newOrejas.sprite = orejas[sp.orejas];

        var newNarices = newCharacter.transform.Find("Nariz").GetComponent<Image>();
        newNarices.sprite = narices[sp.narices];

        var newBoca = newCharacter.transform.Find("Boca").GetComponent<Image>();
        newBoca.sprite = bocas[sp.bocas];

        var newExtra = newCharacter.transform.Find("Extra").GetComponent<Image>();
        newExtra.sprite = extras[sp.extras];

        var newCejas = newCharacter.transform.Find("Cejas").GetComponent<Image>();
        newCejas.sprite = cejas[sp.cejas];

        var ropa = newCharacter.transform.Find("Ropa").GetComponent<Image>();
        ropa.sprite = ropas[sp.ropa];

        var arma_delante = newCharacter.transform.Find("Arma_delante").GetComponent<Image>();
        arma_delante.sprite = armas_delante[sp.arma_delante];

        var arma_detras = newCharacter.transform.Find("Arma_detras").GetComponent<Image>();
        arma_detras.sprite = armas_detras[sp.arma_detras];


        var cuerpo = newCharacter.transform.Find("CUERPO BASE").GetComponent<Image>();
        cuerpo.color = new Color(sp.rc, sp.gc, sp.bc);


        newFlequillo.color = new Color(sp.rp, sp.gp, sp.bp);
        newPelo.color = new Color(sp.rp, sp.gp, sp.bp);


        var newIris = newCharacter.transform.Find("Ojos").transform.Find("Iris").GetComponent<Image>();
        newIris.color = new Color(sp.rp, sp.gi, sp.bi);

        
        var personaje = new Personaje();
        personaje.SetAtaque(sp.ataque);
        personaje.SetDefensa(sp.defensa);
        personaje.SetVida(sp.vida);
        personaje.setVidaMax(sp.vidaMax);
        personaje.SetTipoAtaque((TipoAtaque)sp.tipoAtaque);
        personaje.SetRareza((Rareza)sp.rareza);
        personaje.SetNombre(sp.nombre);
        newCharacter.GetComponent<PlayerController>().setPersonaje(personaje);


    }
}
