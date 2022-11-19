using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercitoManager : MonoBehaviour
{

    private void Start()
    {
        if (!PlayerPrefs.HasKey("commons"))
        {
            crearPersonajes();
        }
    }

    void crearPersonajes()
    {

        var lsp = new ListaPlayerSerializable();

        var sp1 = new SerializablePlayer(0, 1, 2, 3, 4, 5, 6, 7, 8, 25, 175, 200, 200, 0, 145, 4, 4, 17, 17,2,
            "Egalyn La soñadora", 0, 1, 0, 500, 250);

        var sp2 = new SerializablePlayer(1, 2, 3, 4, 5, 6, 7, 8, 9, 16, 165, 10, 164, 96, 75, 4, 3, 24, 24,1,
            "Fropy La furia oriental", 0, 1, 0, 500, 250);

        var sp3 = new SerializablePlayer(2, 3, 4, 5, 6, 7, 8, 9, 10, 175, 10, 100, 173, 78, 47, 5, 2, 14, 14,0,
            "Londolf Sangre dragón", 0, 1, 0, 500, 250);

        lsp.list.Add(sp1);
        lsp.list.Add(sp2);
        lsp.list.Add(sp3);

        PlayerPrefs.SetString("commons", JsonUtility.ToJson(lsp));
    }
}
