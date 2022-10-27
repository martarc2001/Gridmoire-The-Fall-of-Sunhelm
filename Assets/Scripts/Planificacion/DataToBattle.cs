using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataToBattle : MonoBehaviour
{
    private Grid celdas;
    private ListaPlayerSerializable lsp = new ListaPlayerSerializable();

    public void putGrid()
    {
        var grid = FindObjectOfType<GridManager>();

        celdas = grid.getGridInfo();
        
        foreach(var celda in celdas.GetCeldas())
        {
            if(celda.GetPersonaje() != null)
                addSP(celda.GetPersonaje().GetComponent<RectTransform>().Find("Character").gameObject);
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Batalla");
    }

    public Grid getGrid() { return celdas; }
    public ListaPlayerSerializable getLSP() { return lsp; }

    private void addSP(GameObject p)
    {
        var newFlequillo = p.transform.Find("Flequillo").GetComponent<Image>();
        var fn = newFlequillo.sprite.name;

        var newPelo = p.transform.Find("Pelo").GetComponent<Image>().sprite.name;

        var newPestañas = p.transform.Find("Pestañas").GetComponent<Image>().sprite.name;

        var newOrejas = p.transform.Find("Orejas").GetComponent<Image>().sprite.name;

        var newNarices = p.transform.Find("Nariz").GetComponent<Image>().sprite.name;

        var newBoca = p.transform.Find("Boca").GetComponent<Image>().sprite.name;

        var newExtra = p.transform.Find("Extra").GetComponent<Image>().sprite.name;

        var newCejas = p.transform.Find("Cejas").GetComponent<Image>().sprite.name;

        var ropa = p.transform.Find("Ropa").GetComponent<Image>().sprite.name;

        var newIris = p.transform.Find("Ojos").transform.Find("Iris").GetComponent<Image>();

        var rp = newFlequillo.color.r;
        var gp = newFlequillo.color.g;
        var bp = newFlequillo.color.b;

        var ri = newIris.color.r;
        var gi = newIris.color.g;
        var bi = newIris.color.b;

        var person = p.GetComponent<PlayerController>().getPersonaje();
        SerializablePlayer sp = new SerializablePlayer(int.Parse(fn),int.Parse(newPelo),int.Parse(newPestañas),int.Parse(newOrejas)
            ,int.Parse(newNarices),int.Parse(newBoca)
            ,int.Parse(newExtra),int.Parse(newCejas),int.Parse(ropa),rp,gp,bp,ri,gi,bi,person);

        Debug.Log(int.Parse(fn));
        lsp.list.Add(sp);
    }
}
