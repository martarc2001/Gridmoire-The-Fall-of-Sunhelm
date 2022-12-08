using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercitoManager : MonoBehaviour
{

    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        GameManager.instance.setClip(clip);
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("commons"))
        {
            crearPersonajes();
        }

        if (FindObjectOfType<DataToBattle>())
        {
            Destroy(FindObjectOfType<DataToBattle>().gameObject);
        }
        if (FindObjectOfType<NivelDataHandler>())
        {
            Destroy(FindObjectOfType<NivelDataHandler>().gameObject);
        }
    }

    void crearPersonajes()
    {

        var lsp = new ListaPlayerSerializable();

        var sp1 = new SerializablePlayer(0, 1, 2, 3, 4, 5, 6, 6, 8,0,0, 255f / 255f, 231f / 255f, 209f / 255f,
            25 /255f, 175/255f, 200/255f, 200/255f, 0/255f, 145/255f, 
            4, 4, 17, 17,2, 4, 4, 17, "Egalyn La soñadora", 0, 1, 0, 500);

        var sp2 = new SerializablePlayer(1, 2, 3, 4, 2, 3, 1, 5, 9,1,1, 255f / 255f, 241f / 255f, 229f / 255f
            ,16 /255f, 165/255f, 10/255f, 164/255f, 96/255f, 75/255f, 
            4, 3, 24, 24, 1, 4, 3, 24, "Fropy La furia oriental", 0, 1, 0, 500);

        var sp3 = new SerializablePlayer(2, 3, 4, 1, 1, 4, 2, 4, 10,2,2, 174f / 255f, 120f / 255f, 71f / 255f,
            175 /255f, 10/255f, 100/255f, 173/255f, 78/255f, 47/255f, 
            5, 2, 14, 14, 0, 5,2,14,"Londolf Sangre dragón", 0, 1, 0, 500);

        lsp.list.Add(sp1);
        lsp.list.Add(sp2);
        lsp.list.Add(sp3);

        PlayerPrefs.SetString("commons", JsonUtility.ToJson(lsp));
    }
}
