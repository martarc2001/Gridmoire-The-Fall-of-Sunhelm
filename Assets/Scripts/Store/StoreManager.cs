using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject character;

    //[SerializeField] private GameObject ejercito;
    //private EjercitoManager em;
    private GameObject lastCreated;
    private ListaPlayerSerializable spl = new ListaPlayerSerializable();

    [SerializeField] private GameObject stats;

    private Rareza newRareza;

    private List<Color> pieles = new List<Color>() {new Color(255f / 255f, 231f / 255f, 209f / 255f), new Color(255f / 255f, 241f / 255f, 229f / 255f), new Color(255f / 255f, 214f / 255f, 175f / 255f), new Color(225f / 255f, 163f / 255f, 106f / 255f), new Color(174f / 255f, 120f / 255f, 71f / 255f), new Color(122f / 255f, 85f / 255f, 51f / 255f), new Color(79f / 255f, 55f / 255f, 32f / 255f), new Color(41f / 255f, 27f / 255f, 15f / 255f) };

    [SerializeField] private List<string> nombres;
    [SerializeField] private List<string> titulos;
    [SerializeField] private List<Sprite> flequillos;
    [SerializeField] private List<Sprite> pelos;
    [SerializeField] private List<Sprite> pestanha;
    [SerializeField] private List<Sprite> orejas;
    [SerializeField] private List<Sprite> narices;
    [SerializeField] private List<Sprite> bocas;
    [SerializeField] private List<Sprite> extras;
    [SerializeField] private List<Sprite> cejas;
    [SerializeField] private List<Sprite> ropas;
    [SerializeField] private List<Sprite> armas_delante;
    [SerializeField] private List<Sprite> armas_detras;
    [SerializeField] private List<Sprite> tiposAtaque;

    [SerializeField] private TextMeshProUGUI textoNoDinero;
    [SerializeField] private TextMeshProUGUI textoCompra;

    [SerializeField] private GameObject moneda;
    public void Start()
    {
        newRareza = Rareza.COMUN;
        changeRareness("Comun");
    }
    public void Awake()
    {
        newRareza = Rareza.COMUN;
        //changeRareness("Comun");
    }

    public void changeRareness(string rareness)
    {
        switch (rareness)
        {
            case "Comun":
                moneda.SetActive(true);
                textoCompra.text = "Comprar: 150";
                newRareza = Rareza.COMUN;
                spl.list.Clear();
                var com = PlayerPrefs.GetString("commons");

                if (!string.IsNullOrEmpty(com))
                {
                    spl = JsonUtility.FromJson<ListaPlayerSerializable>(com);
                }
                break;
            case "Raro":
                moneda.SetActive(true);
                textoCompra.text = "Comprar: 500";
                newRareza = Rareza.RARO;
                spl.list.Clear();
                var rar = PlayerPrefs.GetString("rares");

                if (!string.IsNullOrEmpty(rar))
                {
                    spl = JsonUtility.FromJson<ListaPlayerSerializable>(rar);
                }
                break;
            case "SuperRaro":
                moneda.SetActive(true);
                textoCompra.text = "Comprar: 2500";
                newRareza = Rareza.SUPER_RARO;
                spl.list.Clear();
                var ur = PlayerPrefs.GetString("superRares");

                if (!string.IsNullOrEmpty(ur))
                {
                    spl = JsonUtility.FromJson<ListaPlayerSerializable>(ur);
                }
                break;
        }
    }

    public void comprarPersonaje()
    {
        if (lastCreated != null)
        {
            Destroy(lastCreated);
        }
        textoNoDinero.text = "";

        switch (newRareza)
        {
            case Rareza.COMUN:
                if(GameManager.instance.getDineroJugador() >= 150)
                {
                    generateRandomCharacter();
                }
                else
                {
                    textoNoDinero.text = "No tienes suficiente dinero";
                }
                break;
            case Rareza.RARO:
                if (GameManager.instance.getDineroJugador() >= 500)
                {
                    generateRandomCharacter();
                }
                else
                {
                    textoNoDinero.text = "No tienes suficiente dinero";
                }
                break;
            case Rareza.SUPER_RARO:
                if (GameManager.instance.getDineroJugador() >= 1500)
                {
                    generateRandomCharacter();
                }
                else
                {
                    textoNoDinero.text = "No tienes suficiente dinero";
                }
                break;
        }
    }

    public void generateRandomCharacter()
    {

        
        var newCharacter = Instantiate(character);

        string newNombre = nombres[Random.Range(0, nombres.Count)];
        string newTitulo = titulos[Random.Range(0, titulos.Count)];
        string newNombrePersonaje = newNombre + " " + newTitulo;

        /////// CHARACTER CUSTOMIZATION ///////

        var cuerpo = newCharacter.transform.Find("CUERPO BASE").GetComponent<SpriteRenderer>();
        Color piel = this.pieles[Random.Range(0, this.pieles.Count)];
        cuerpo.color = piel;
        newCharacter.transform.Find("Cara").GetComponent<SpriteRenderer>().color = piel;

        var newFlequillo = newCharacter.transform.Find("Flequillo").GetComponent<SpriteRenderer>();
        var iFlequillo = Random.Range(0, flequillos.Count);
        newFlequillo.sprite = flequillos[iFlequillo];

        var newPelo = newCharacter.transform.Find("Pelo").GetComponent<SpriteRenderer>();
        var iPelo = Random.Range(0, pelos.Count);
        newPelo.sprite = pelos[iPelo];

        var newPestanhas = newCharacter.transform.Find("Pestanhas").GetComponent<SpriteRenderer>();
        var iPest = Random.Range(0, pestanha.Count);
        newPestanhas.sprite = pestanha[iPest];

        var newOrejas = newCharacter.transform.Find("Orejas").GetComponent<SpriteRenderer>();
        var iOrej = Random.Range(0, orejas.Count);
        newOrejas.sprite = orejas[iOrej];

        var newNarices = newCharacter.transform.Find("Nariz").GetComponent<SpriteRenderer>();
        var iNari = Random.Range(0, narices.Count);
        newNarices.sprite = narices[iNari];

        var newBoca = newCharacter.transform.Find("Boca").GetComponent<SpriteRenderer>();
        var iBoca = Random.Range(0, bocas.Count);
        newBoca.sprite = bocas[iBoca];

        var newExtra = newCharacter.transform.Find("Extra").GetComponent<SpriteRenderer>();
        var iExtra = Random.Range(0, extras.Count);
        newExtra.sprite = extras[iExtra];

        var newCejas = newCharacter.transform.Find("Cejas").GetComponent<SpriteRenderer>();
        var iCejas = Random.Range(0, cejas.Count);
        newCejas.sprite = cejas[iCejas];

        var ropa = newCharacter.transform.Find("Ropa").GetComponent<SpriteRenderer>();
        var iRopa = Random.Range(0, ropas.Count);
        ropa.sprite = ropas[iRopa];

        var newArma = newCharacter.transform.Find("Arma_delante").GetComponent<SpriteRenderer>();
        var iArma = Random.Range(0, armas_delante.Count);
        newArma.sprite = armas_delante[iArma];

        var iArmaDetras = 5;
        if(iArma < 5)
        {
            iArmaDetras = iArma;
        }
        var newArmaDetras = newCharacter.transform.Find("Arma_detras").GetComponent<SpriteRenderer>();
        newArmaDetras.sprite = armas_detras[iArmaDetras];

        newOrejas.color = piel;

        var RP = Random.Range(0, 255) / 255f;
        var GP = Random.Range(0, 255) / 255f;
        var BP = Random.Range(0, 255) / 255f;

        newFlequillo.color = new Color(RP, GP, BP);
        newPelo.color = new Color(RP, GP, BP);
        newCejas.color = new Color(RP, GP, BP);

        var RI = Random.Range(0, 255) / 255f;
        var GI = Random.Range(0, 255) / 255f;
        var BI = Random.Range(0, 255) / 255f;

        var newIris = newCharacter.transform.Find("Ojos").transform.Find("Iris").GetComponent<SpriteRenderer>();
        newIris.color = new Color(RI, GI, BI);


        /////// ATTACK SELECTION ///////

        var tipoAtaque = (TipoAtaque)Random.Range(0, 5);

        switch ((int)tipoAtaque)
        {
            case 0:
                newCharacter.transform.Find("Ataque").GetComponent<SpriteRenderer>().sprite = tiposAtaque[0];
                break;
            case 1:
                newCharacter.transform.Find("Ataque").GetComponent<SpriteRenderer>().sprite = tiposAtaque[1];
                break;
            case 2:
                newCharacter.transform.Find("Ataque").GetComponent<SpriteRenderer>().sprite = tiposAtaque[2];
                break;
            case 3:
                newCharacter.transform.Find("Ataque").GetComponent<SpriteRenderer>().sprite = tiposAtaque[3];
                break;
            case 4:
                newCharacter.transform.Find("Ataque").GetComponent<SpriteRenderer>().sprite = tiposAtaque[4];
                break;
        }

        ///// CHARACTER GENERATION /////

        Personaje pers = new Personaje(newNombrePersonaje, tipoAtaque, this.newRareza);

        newCharacter.GetComponent<PlayerController>().setPersonaje(pers);

        lastCreated = newCharacter;


        var sp = new SerializablePlayer(iFlequillo,iPelo,iPest,iOrej,iNari,iBoca,iExtra,iCejas,
            iRopa, iArma, iArmaDetras, piel.r, piel.g, piel.b,RP,GP,BP,RI,GI,BI,pers.GetAtaque(),pers.GetDefensa(),pers.GetVida(),pers.getVidaMax(), 
            (int)pers.GetTipoAtaque(),pers.GetNombre(),(int)pers.GetRareza(),1,0,500,250);

        spl.list.Add(sp);

        switch (newRareza)
        {
            case Rareza.COMUN:
                GameManager.instance.restarDinero(150);
                PlayerPrefs.SetString("commons", JsonUtility.ToJson(spl));
                break;
            case Rareza.RARO:
                GameManager.instance.restarDinero(500);
                PlayerPrefs.SetString("rares", JsonUtility.ToJson(spl));
                break;
            case Rareza.SUPER_RARO:
                GameManager.instance.restarDinero(1500);
                PlayerPrefs.SetString("superRares", JsonUtility.ToJson(spl));
                
                break;
        }

        PlayerPrefs.SetInt("Dinero", GameManager.instance.getDineroJugador());
        PlayerPrefs.Save();


        var nombreStats = "Nombre: " + pers.GetNombre();
        var vidaStats = "Vida: " + pers.GetVida();
        var ataqueStats = "Ataque: " + pers.GetAtaque();
        var defensaStats = "Defensa: " + pers.GetDefensa();
        var tipoAtaqueStats = "Tipo de ataque: " + pers.GetTipoAtaque();

        stats.transform.Find("Nombre").GetComponent<TextMeshProUGUI>().text = nombreStats;
        stats.transform.Find("Vida").GetComponent<TextMeshProUGUI>().text = vidaStats;
        stats.transform.Find("Ataque").GetComponent<TextMeshProUGUI>().text = ataqueStats;
        stats.transform.Find("Defensa").GetComponent<TextMeshProUGUI>().text = defensaStats;
        stats.transform.Find("Tipo Ataque").GetComponent<TextMeshProUGUI>().text = tipoAtaqueStats;

        if (!stats.activeSelf)
        {
            stats.SetActive(true);
        }
    }
}
