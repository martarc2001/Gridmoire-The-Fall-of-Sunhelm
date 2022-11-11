using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CargarNiveles : MonoBehaviour
{
    private ListaLevelSerializable lls = new ListaLevelSerializable();
    [SerializeField] private GameObject llsPrefab;

    [SerializeField] private List<int> ids;
    [SerializeField] private List<string> nombres;
    [SerializeField] private List<Estado> estados;
    [SerializeField] private List<List<Personaje>> listasEnemigos;
    [SerializeField] private List<int> monedas;
    [SerializeField] private List<int> experiencias;

    // Start is called before the first frame update
    void Start()
    {
        string json = PlayerPrefs.GetString("ejercito");

        if (!string.IsNullOrEmpty(json))
        {
            lls = JsonUtility.FromJson<ListaLevelSerializable>(json);

            foreach (var level in lls.list)
            {
                //instanciarNivel(level);
            }
        }
    }
/*
    private void instanciarNivel(SerializableLevel sl)
    {
        var uiLevel = Instantiate(llsPrefab, transform);

        var newLevel = uiLevel.transform.Find("Character");

        /////// CHARACTER CUSTOMIZATION ///////

        var newFlequillo = newLevel.transform.Find("Flequillo").GetComponent<Image>();
        newFlequillo.sprite = flequillos[sl.flequillo];

        var newPelo = newLevel.transform.Find("Pelo").GetComponent<Image>();
        newPelo.sprite = pelos[sl.pelo];

        var newPestañas = newLevel.transform.Find("Pestañas").GetComponent<Image>();
        newPestañas.sprite = pestañas[sl.pestanha];

        var newOrejas = newLevel.transform.Find("Orejas").GetComponent<Image>();
        newOrejas.sprite = orejas[sl.orejas];

        var newNarices = newLevel.transform.Find("Nariz").GetComponent<Image>();
        newNarices.sprite = narices[sl.narices];

        var newBoca = newLevel.transform.Find("Boca").GetComponent<Image>();
        newBoca.sprite = bocas[sl.bocas];

        var newExtra = newLevel.transform.Find("Extra").GetComponent<Image>();
        newExtra.sprite = extras[sl.extras];

        var newCejas = newLevel.transform.Find("Cejas").GetComponent<Image>();
        newCejas.sprite = cejas[sl.cejas];

        var ropa = newLevel.transform.Find("Ropa").GetComponent<Image>();
        ropa.sprite = ropas[sl.ropa];


        newFlequillo.color = new Color(sl.rp, sl.gp, sl.bp);
        newPelo.color = new Color(sl.rp, sl.gp, sl.bp);


        var newIris = newLevel.transform.Find("Ojos").transform.Find("Iris").GetComponent<Image>();
        newIris.color = new Color(sl.rp, sl.gi, sl.bi);


        var personaje = new Personaje();
        personaje.SetAtaque(sl.ataque);
        personaje.SetDefensa(sl.defensa);
        personaje.SetVida(sl.vida);
        personaje.SetTipoAtaque((TipoAtaque)sl.tipoAtaque);
        newLevel.GetComponent<PlayerController>().setPersonaje(personaje);


    }*/
}
