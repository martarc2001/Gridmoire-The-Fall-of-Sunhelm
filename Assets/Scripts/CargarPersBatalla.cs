using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersBatalla : MonoBehaviour
{
    private ListaPlayerSerializable grid;
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<CeldaManager> headPosition;

    [SerializeField] private List<Sprite> flequillos;
    [SerializeField] private List<Sprite> pelos;
    [SerializeField] private List<Sprite> pestañas;
    [SerializeField] private List<Sprite> orejas;
    [SerializeField] private List<Sprite> narices;
    [SerializeField] private List<Sprite> bocas;
    [SerializeField] private List<Sprite> extras;
    [SerializeField] private List<Sprite> cejas;
    [SerializeField] private List<Sprite> ropas;

    private void Start()
    {
        grid = FindObjectOfType<DataToBattle>().getLSP();
        var celdas = FindObjectOfType<DataToBattle>().getCeldas();

        var posSituar = new List<Transform>();

        foreach(var celda in celdas)
        {
            for(var i = 0; i < headPosition.Count; i++)
            {
                if(celda.GetX() == headPosition[i].getCelda().GetX() 
                    && celda.GetY() == headPosition[i].getCelda().GetY())
                {
                    posSituar.Add(headPosition[i].transform);
                }
            }
        }

        for (var i = 0; i < grid.list.Count; i++)
        {
            instanciarPersonaje(grid.list[i], posSituar[i]);
        }
    }

    private void instanciarPersonaje(SerializablePlayer sp, Transform transPos)
    {
        var newCharacter = Instantiate(prefab, transPos.position, Quaternion.identity);

        /////// CHARACTER CUSTOMIZATION ///////

        var newFlequillo = newCharacter.transform.Find("Flequillo").GetComponent<SpriteRenderer>();
        newFlequillo.sprite = flequillos[sp.flequillo-1];

        var newPelo = newCharacter.transform.Find("Pelo").GetComponent<SpriteRenderer>();
        newPelo.sprite = pelos[sp.pelo-1];

        var newPestañas = newCharacter.transform.Find("Pestañas").GetComponent<SpriteRenderer>();
        newPestañas.sprite = pestañas[sp.pestanha-1];

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

        newFlequillo.color = new Color(sp.rp, sp.gp, sp.bp);
        newPelo.color = new Color(sp.rp, sp.gp, sp.bp);

        var newIris = newCharacter.transform.Find("Ojos").transform.Find("Iris").GetComponent<SpriteRenderer>();
        newIris.color = new Color(sp.rp, sp.gi, sp.bi);

        newCharacter.GetComponent<PlayerController>().setPersonaje(sp.personaje);


    }
}
