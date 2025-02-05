using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecompensaHandler : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textoMonedas;
    [SerializeField] private TextMeshProUGUI textoXP;

    [SerializeField] private AudioClip clip;

    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(GameManager.instance.playSound(clip));
        var nivelData = FindObjectOfType<NivelDataHandler>();
        GameManager.instance.sumarDinero(nivelData.GetMonedas());

        textoMonedas.text = "" + nivelData.GetMonedas();
        textoXP.text = "" + nivelData.GetXp();

        var ejercitoData = FindObjectOfType<EjercitoRecompensa>();


        foreach(var personaje in ejercitoData.getNombres())
        {
            personaje.SetXp(nivelData.GetXp());
            personaje.ComprobarNivel();

            Debug.Log("Nivel: " + personaje.GetNivel());
            switch (personaje.GetRareza())
            {
                case Rareza.COMUN:
                    recompensaCommons(personaje);
                    break;
                case Rareza.RARO:
                    recompensaRares(personaje);
                    break;
                case Rareza.SUPER_RARO:
                    recompensaSuperRares(personaje);
                    break;
            }
        }

        string estadosString = PlayerPrefs.GetString("Estados Niveles");

        SerializableEstadoList estados = JsonUtility.FromJson<SerializableEstadoList>(estadosString);

        var idx = (nivelData.GetMundo() - 1) * 10 + nivelData.GetID();

        estados.list[idx-1] = Estado.JUGADO;
        if(idx < 30)
        {
            estados.list[idx] = Estado.NO_JUGADO;
        }
        //else
        //{
        //    //esto est� porque no hay m�s de 10 niveles
        //}


        PlayerPrefs.SetString("Estados Niveles", JsonUtility.ToJson(estados));

        PlayerPrefs.Save();

    }

    void recompensaCommons(Personaje personaje)
    {
        string com = PlayerPrefs.GetString("commons");

        if (!string.IsNullOrEmpty(com))
        {
            var lsp = JsonUtility.FromJson<ListaPlayerSerializable>(com);
            var newList = new ListaPlayerSerializable();

            foreach (var p in lsp.list)
            {
                if (p.nombre.Equals(personaje.GetNombre()))
                {
                    p.ataque = personaje.GetAtaque();
                    p.ataqueBase = personaje.GetAtaqueBase();
                    p.defensa = personaje.GetDefensa();
                    p.defensaBase = personaje.GetDefensaBase();
                    p.vida = personaje.GetVida();
                    p.vidaBase = personaje.GetVidaBase();
                    p.vidaMax = personaje.getVidaMax();
                    p.nivel = personaje.GetNivel();
                    p.xp = personaje.GetXp();
                    p.xpSubida = personaje.GetXpSubida();
                }
                newList.list.Add(p);
            }
            PlayerPrefs.SetString("commons", JsonUtility.ToJson(newList));
        }
    }

    void recompensaRares(Personaje personaje)
    {
        string com = PlayerPrefs.GetString("rares");

        if (!string.IsNullOrEmpty(com))
        {
            var lsp = JsonUtility.FromJson<ListaPlayerSerializable>(com);
            var newList = new ListaPlayerSerializable();

            foreach (var p in lsp.list)
            {
                if (p.nombre.Equals(personaje.GetNombre()))
                {
                    p.ataque = personaje.GetAtaque();
                    p.ataqueBase = personaje.GetAtaqueBase();
                    p.defensa = personaje.GetDefensa();
                    p.defensaBase = personaje.GetDefensaBase();
                    p.vida = personaje.GetVida();
                    p.vidaBase = personaje.GetVidaBase();
                    p.vidaMax = personaje.getVidaMax();
                    p.nivel = personaje.GetNivel();
                    p.xp = personaje.GetXp();
                    p.xpSubida = personaje.GetXpSubida();
                }
                newList.list.Add(p);
            }
            PlayerPrefs.SetString("rares", JsonUtility.ToJson(newList));
        }
    }

    void recompensaSuperRares(Personaje personaje)
    {
        string com = PlayerPrefs.GetString("superRares");

        if (!string.IsNullOrEmpty(com))
        {
            var lsp = JsonUtility.FromJson<ListaPlayerSerializable>(com);

            var newList = new ListaPlayerSerializable();

            foreach (var p in lsp.list)
            {
                if (p.nombre.Equals(personaje.GetNombre()))
                {
                    p.ataque = personaje.GetAtaque();
                    p.ataqueBase = personaje.GetAtaqueBase();
                    p.defensa = personaje.GetDefensa();
                    p.defensaBase = personaje.GetDefensaBase();
                    p.vida = personaje.GetVida();
                    p.vidaBase = personaje.GetVidaBase();
                    p.vidaMax = personaje.getVidaMax();
                    p.nivel = personaje.GetNivel();
                    p.xp = personaje.GetXp();
                    p.xpSubida = personaje.GetXpSubida();
                }
                newList.list.Add(p);

            }
            PlayerPrefs.SetString("superRares", JsonUtility.ToJson(newList));
        }
    }

    public void terminarRecompensa(string scene)
    {
        SigEscena.CrossSceneInformation = scene;
        if (scene.Equals("Seleccion de niveles"))
        {
            if (FindObjectOfType<NivelDataHandler>() != null)
                Destroy(FindObjectOfType<NivelDataHandler>().gameObject);

            if (FindObjectOfType<DataToBattle>() != null)
                Destroy(FindObjectOfType<DataToBattle>().gameObject);

            if (FindObjectOfType<HistoriaManager>() != null)
                Destroy(FindObjectOfType<HistoriaManager>().gameObject);


            StopAllCoroutines();
            GameManager.instance.GetAudioSource().Stop();
            GameManager.instance.GetAudioSource().clip = GameManager.instance.GetClipMenu();
            GameManager.instance.GetAudioSource().Play();
        }


        SceneManager.LoadScene("PantallaCarga");
    }
}
