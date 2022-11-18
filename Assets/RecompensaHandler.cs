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

        Debug.Log(ejercitoData.getNombres().Count);

        foreach(var personaje in ejercitoData.getNombres())
        {
            personaje.SetXp(nivelData.GetXp());
            personaje.ComprobarNivel();
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

        estados.list[(nivelData.GetMundo() * nivelData.GetID()) - 1] = Estado.JUGADO;
        estados.list[(nivelData.GetMundo() * nivelData.GetID())] = Estado.NO_JUGADO;

        PlayerPrefs.SetString("Estados Niveles", JsonUtility.ToJson(estados));

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
                    p.defensa = personaje.GetDefensa();
                    p.vida = personaje.GetVida();
                    p.vidaMax = personaje.getVidaMax();
                    p.nivel = personaje.GetNivel();
                    p.xp = personaje.GetXp();
                    p.xpSubida = personaje.GetXpSubida();
                    p.xpSubidaPrev = personaje.GetXpSubidaPrev();
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
                    p.defensa = personaje.GetDefensa();
                    p.vida = personaje.GetVida();
                    p.vidaMax = personaje.getVidaMax();
                    p.nivel = personaje.GetNivel();
                    p.xp = personaje.GetXp();
                    p.xpSubida = personaje.GetXpSubida();
                    p.xpSubidaPrev = personaje.GetXpSubidaPrev();
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
                    p.defensa = personaje.GetDefensa();
                    p.vida = personaje.GetVida();
                    p.vidaMax = personaje.getVidaMax();
                    p.nivel = personaje.GetNivel();
                    p.xp = personaje.GetXp();
                    p.xpSubida = personaje.GetXpSubida();
                    p.xpSubidaPrev = personaje.GetXpSubidaPrev();
                }
                newList.list.Add(p);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
