using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class DataToBattle : MonoBehaviour
{
    private ListaPlayerSerializable lsp = new ListaPlayerSerializable();
    private Celda[] listaCeldas;
    private List<CeldaManager> listCeldas = new List<CeldaManager>();

    public GameObject fadeEffect;

    public void putGrid()
    {
        

        if (listCeldas.Count > 0)
        {
            fadeEffect.SetActive(true);
            var i = 0;
            listaCeldas = new Celda[listCeldas.Count];
            foreach (var celda in listCeldas)
            {
                if (celda.getCelda().GetPersonaje() != null)
                {
                    addSP(celda.getCelda().GetPersonaje().GetComponent<RectTransform>().Find("Character").gameObject);
                    listaCeldas[i] = celda.getCelda();
                    i++;
                }

            }

            DontDestroyOnLoad(gameObject);

            Invoke("CargaBatalla", fadeEffect.GetComponent<GDTFadeEffect>().timeEffect);
        }
        
    }

    public ListaPlayerSerializable getLSP() { return lsp; }
    public List<CeldaManager> getCeldas() { return listCeldas; }

    public void addCelda(CeldaManager celda) 
    { 
        listCeldas.Add(celda); 
    }

    public void removeCelda(CeldaManager celda) { listCeldas.Remove(celda); }
    private void addSP(GameObject p)
    {
        //Debug.Log("Añadir personaje: " + p);
        var cuerpo = p.transform.Find("CUERPO BASE").GetComponent<SpriteRenderer>();

        var newFlequillo = p.transform.Find("Flequillo").GetComponent<SpriteRenderer>();
        var fn = newFlequillo.sprite.name;

        var newPelo = p.transform.Find("Pelo").GetComponent<SpriteRenderer>().sprite.name;

        var newPestanhas = p.transform.Find("Pestanhas").GetComponent<SpriteRenderer>().sprite.name;

        var newOrejas = p.transform.Find("Orejas").GetComponent<SpriteRenderer>().sprite.name;

        var newNarices = p.transform.Find("Nariz").GetComponent<SpriteRenderer>().sprite.name;

        var newBoca = p.transform.Find("Boca").GetComponent<SpriteRenderer>().sprite.name;

        var newExtra = p.transform.Find("Extra").GetComponent<SpriteRenderer>().sprite.name;

        var newCejas = p.transform.Find("Cejas").GetComponent<SpriteRenderer>().sprite.name;

        var ropa = p.transform.Find("Ropa").GetComponent<SpriteRenderer>().sprite.name;

        var arma_delante = p.transform.Find("Arma_delante").GetComponent<SpriteRenderer>().sprite.name;

        var arma_detras = p.transform.Find("Arma_detras").GetComponent<SpriteRenderer>().sprite.name;

        var newIris = p.transform.Find("Ojos").transform.Find("Iris").GetComponent<SpriteRenderer>();

        var rc = cuerpo.color.r;
        var gc = cuerpo.color.g;
        var bc = cuerpo.color.b;
        
        var rp = newFlequillo.color.r;
        var gp = newFlequillo.color.g;
        var bp = newFlequillo.color.b;

        var ri = newIris.color.r;
        var gi = newIris.color.g;
        var bi = newIris.color.b;

        
        var person = p.GetComponent<PlayerController>().getPersonaje();
        SerializablePlayer sp = new SerializablePlayer(int.Parse(fn),int.Parse(newPelo),int.Parse(newPestanhas),int.Parse(newOrejas)
            ,int.Parse(newNarices),int.Parse(newBoca)
            ,int.Parse(newExtra),int.Parse(newCejas),int.Parse(ropa),int.Parse(arma_delante),int.Parse(arma_detras),rc,gc,bc,rp,gp,bp,ri,gi,bi,person.GetAtaque(),
            person.GetDefensa(),person.GetVida(),person.getVidaMax(),(int)person.GetTipoAtaque(),
            person.GetAtaqueBase(),person.GetDefensaBase(),person.GetVidaBase(),person.GetNombre(),(int)person.GetRareza(),
            person.GetNivel(),person.GetXp(),person.GetXpSubida());


        lsp.list.Add(sp);
    }

    private void CargaBatalla()
    {
        SigEscena.CrossSceneInformation = "Batalla";
        SceneManager.LoadScene("PantallaCarga2");
    }
}
