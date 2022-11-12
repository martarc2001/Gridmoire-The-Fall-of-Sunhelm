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
    [SerializeField] private List<Sprite> pestañas;
    [SerializeField] private List<Sprite> orejas;
    [SerializeField] private List<Sprite> narices;
    [SerializeField] private List<Sprite> bocas;
    [SerializeField] private List<Sprite> extras;
    [SerializeField] private List<Sprite> cejas;
    [SerializeField] private List<Sprite> ropas;

    // Start is called before the first frame update
    void Start()
    {
        string json = PlayerPrefs.GetString("ejercito");

        if (!string.IsNullOrEmpty(json))
        {
            lsp = JsonUtility.FromJson<ListaPlayerSerializable>(json);

            foreach (var p in lsp.list)
            {
                instanciarPersonaje(p);
            }
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
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

        var newPestañas = newCharacter.transform.Find("Pestañas").GetComponent<Image>();
        newPestañas.sprite = pestañas[sp.pestanha];

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


        newFlequillo.color = new Color(sp.rp, sp.gp, sp.bp);
        newPelo.color = new Color(sp.rp, sp.gp, sp.bp);


        var newIris = newCharacter.transform.Find("Ojos").transform.Find("Iris").GetComponent<Image>();
        newIris.color = new Color(sp.rp, sp.gi, sp.bi);

        
        var personaje = new Personaje();
        personaje.SetAtaque(sp.ataque);
        personaje.SetDefensa(sp.defensa);
        personaje.SetVida(sp.vida);
        personaje.SetTipoAtaque((TipoAtaque)sp.tipoAtaque);
        personaje.SetRareza((Rareza)sp.rareza);
        personaje.SetNombre(sp.nombre);
        newCharacter.GetComponent<PlayerController>().setPersonaje(personaje);


    }
}
