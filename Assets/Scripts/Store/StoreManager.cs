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

    private Rareza newRareza;

    private List<Color> pieles = new List<Color>() {new Color(255, 231, 209), new Color(255, 241, 229), new Color(255, 214, 175), new Color(225, 163, 106), new Color(174, 120, 71), new Color(122, 85, 51), new Color(79, 55, 32), new Color(41, 27, 15) };

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

    [SerializeField] private TextMeshProUGUI textoNoDinero;
    public void Start()
    {
    }
    public void Awake()
    {
        newRareza = Rareza.COMUN;
        changeRareness("Comun");
    }

    public void changeRareness(string rareness)
    {
        switch (rareness)
        {
            case "Comun":
                newRareza = Rareza.COMUN;
                spl.list.Clear();
                var com = PlayerPrefs.GetString("commons");

                if (!string.IsNullOrEmpty(com))
                {
                    spl = JsonUtility.FromJson<ListaPlayerSerializable>(com);
                }
                break;
            case "Raro":
                newRareza = Rareza.RARO;
                spl.list.Clear();
                var rar = PlayerPrefs.GetString("rares");

                if (!string.IsNullOrEmpty(rar))
                {
                    spl = JsonUtility.FromJson<ListaPlayerSerializable>(rar);
                }
                break;
            case "SuperRaro":
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
        cuerpo.material.color = piel;

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


        var RP = Random.Range(0, 255) / 255f;
        var GP = Random.Range(0, 255) / 255f;
        var BP = Random.Range(0, 255) / 255f;

        newFlequillo.material.color = new Color(RP, GP, BP);
        newPelo.material.color = new Color(RP, GP, BP);

        var RI = Random.Range(0, 255) / 255f;
        var GI = Random.Range(0, 255) / 255f;
        var BI = Random.Range(0, 255) / 255f;

        var newIris = newCharacter.transform.Find("Ojos").transform.Find("Iris").GetComponent<SpriteRenderer>();
        newIris.material.color = new Color(RI, GI, BI);

        /////// ATTACK SELECTION ///////

        var tipoAtaque = (TipoAtaque)Random.Range(0, 5);

        ///// CHARACTER GENERATION /////

        Personaje pers = new Personaje(newNombrePersonaje, tipoAtaque, this.newRareza);

        newCharacter.GetComponent<PlayerController>().setPersonaje(pers);

        Debug.Log(newCharacter.GetComponent<PlayerController>().getPersonaje().GetNombre());
        var ataque = newCharacter.transform.Find("Ataque").GetComponent<SpriteRenderer>();

        switch (tipoAtaque)
        {
            case TipoAtaque.SINGLE:
                ataque.color = Color.red;
                break;
            case TipoAtaque.ROW:
                ataque.color = Color.blue;
                break;
            case TipoAtaque.COLUMN:
                ataque.color = Color.yellow;
                break;
            case TipoAtaque.GRID:
                ataque.color = Color.black;
                break;
            case TipoAtaque.HEAL:
                ataque.color = Color.green;
                break;
        }

        lastCreated = newCharacter;


        var sp = new SerializablePlayer(iFlequillo,iPelo,iPest,iOrej,iNari,iBoca,iExtra,iCejas,
            iRopa,RP,GP,BP,RI,GI,BI,pers.GetAtaque(),pers.GetDefensa(),pers.GetVida(),pers.getVidaMax(), 
            (int)pers.GetTipoAtaque(),pers.GetNombre(),(int)pers.GetRareza());

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

    }
}
