using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadBattleScene(string scene)
    {
        NivelesManager nivelesManager = FindObjectOfType<NivelesManager>() as NivelesManager;

        int seleccionado = nivelesManager.GetSeleccion();
        SerializableLevel nivel = nivelesManager.GetNiveles()[seleccionado];

        GameObject nivelDH = new GameObject("Nivel");
        var dataHandler = nivelDH.AddComponent<NivelDataHandler>() as NivelDataHandler;
        dataHandler.SetNivel(nivel);

        DontDestroyOnLoad(nivelDH);

        SceneManager.LoadScene(scene);
    }

    public void LoadMainMenu(string scene)
    {
        var dataBattle = FindObjectOfType<DataToBattle>();
        var nivelData = FindObjectOfType<NivelDataHandler>();

        Destroy(dataBattle.gameObject);
        Destroy(nivelData.gameObject);

        if (FindObjectOfType<EjercitoRecompensa>())
        {
            Destroy(FindObjectOfType<EjercitoRecompensa>().gameObject);
        }

        SceneManager.LoadScene(scene);
    }
}
