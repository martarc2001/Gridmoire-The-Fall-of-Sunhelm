using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecompensaHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var nivelData = FindObjectOfType<NivelDataHandler>();
        GameManager.instance.sumarDinero(nivelData.GetMonedas());

        var ejercitoData = FindObjectOfType<EjercitoRecompensa>();
        foreach(var personaje in ejercitoData.GetLista())
        {
            personaje.getPersonaje().SetXp(nivelData.GetXp());
            personaje.getPersonaje().ComprobarNivel();
            Debug.Log(personaje.getPersonaje().GetNombre() +" Nivel: "+personaje.getPersonaje().GetNivel());
            switch (personaje.getPersonaje().GetRareza())
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

        Destroy(ejercitoData.gameObject);
    }

    void recompensaCommons(PlayerController personaje)
    {
        string com = PlayerPrefs.GetString("commons");

        if (!string.IsNullOrEmpty(com))
        {
            var lsp = JsonUtility.FromJson<ListaPlayerSerializable>(com);
            var newList = new ListaPlayerSerializable();

            foreach (var p in lsp.list)
            {
                if (p.nombre.Equals(personaje.getPersonaje().GetNombre()))
                {
                    p.ataque = personaje.getPersonaje().GetAtaque();
                    p.defensa = personaje.getPersonaje().GetDefensa();
                    p.vida = personaje.getPersonaje().GetVida();
                    p.vidaMax = personaje.getPersonaje().getVidaMax();
                    p.nivel = personaje.getPersonaje().GetNivel();
                    p.xp = personaje.getPersonaje().GetXp();
                    p.xpSubida = personaje.getPersonaje().GetXpSubida();
                    p.xpSubidaPrev = personaje.getPersonaje().GetXpSubidaPrev();
                }
                newList.list.Add(p);
            }
            PlayerPrefs.SetString("commons", JsonUtility.ToJson(newList));
        }
    }

    void recompensaRares(PlayerController personaje)
    {
        string com = PlayerPrefs.GetString("rares");

        if (!string.IsNullOrEmpty(com))
        {
            var lsp = JsonUtility.FromJson<ListaPlayerSerializable>(com);
            var newList = new ListaPlayerSerializable();

            foreach (var p in lsp.list)
            {
                if (p.nombre.Equals(personaje.getPersonaje().GetNombre()))
                {
                    p.ataque = personaje.getPersonaje().GetAtaque();
                    p.defensa = personaje.getPersonaje().GetDefensa();
                    p.vida = personaje.getPersonaje().GetVida();
                    p.vidaMax = personaje.getPersonaje().getVidaMax();
                    p.nivel = personaje.getPersonaje().GetNivel();
                    p.xp = personaje.getPersonaje().GetXp();
                    p.xpSubida = personaje.getPersonaje().GetXpSubida();
                    p.xpSubidaPrev = personaje.getPersonaje().GetXpSubidaPrev();
                }
                newList.list.Add(p);
            }
            PlayerPrefs.SetString("rares", JsonUtility.ToJson(newList));
        }
    }

    void recompensaSuperRares(PlayerController personaje)
    {
        string com = PlayerPrefs.GetString("superRares");

        if (!string.IsNullOrEmpty(com))
        {
            var lsp = JsonUtility.FromJson<ListaPlayerSerializable>(com);

            var newList = new ListaPlayerSerializable();

            foreach (var p in lsp.list)
            {
                if (p.nombre.Equals(personaje.getPersonaje().GetNombre()))
                {
                    p.ataque = personaje.getPersonaje().GetAtaque();
                    p.defensa = personaje.getPersonaje().GetDefensa();
                    p.vida = personaje.getPersonaje().GetVida();
                    p.vidaMax = personaje.getPersonaje().getVidaMax();
                    p.nivel = personaje.getPersonaje().GetNivel();
                    p.xp = personaje.getPersonaje().GetXp();
                    p.xpSubida = personaje.getPersonaje().GetXpSubida();
                    p.xpSubidaPrev = personaje.getPersonaje().GetXpSubidaPrev();
                }
                newList.list.Add(p);

            }

            foreach(var p in newList.list)
            {
                Debug.Log(p.nombre + " Nivel: " + p.nivel);
            }
            PlayerPrefs.SetString("superRares", JsonUtility.ToJson(newList));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
