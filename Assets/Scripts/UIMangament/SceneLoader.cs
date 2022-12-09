using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SigEscena.CrossSceneInformation = scene;
        SceneManager.LoadScene("PantallaCarga");
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

        SigEscena.CrossSceneInformation = scene;
        SceneManager.LoadScene("PantallaCarga");
        //SceneManager.LoadScene(scene);
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

        SigEscena.CrossSceneInformation = scene;
        SceneManager.LoadScene("PantallaCarga");
        //SceneManager.LoadScene(scene);
    }

    public void LoadSeleccionNiveles()
    {
        if(PlayerPrefs.GetInt("PrimeraVez") == 1)
        {
            SigEscena.CrossSceneInformation = "Intro Visual Novel";
            SceneManager.LoadScene("PantallaCarga");
            //SceneManager.LoadScene("Intro Visual Novel");
        } else
        {
            SigEscena.CrossSceneInformation = "Seleccion de niveles";
            SceneManager.LoadScene("PantallaCarga");
            //SceneManager.LoadScene("Seleccion de niveles");
        }
    }

    public void LoadPlanificacion(GameObject historiaManager)
    {
        NivelesManager nivelesManager = FindObjectOfType<NivelesManager>() as NivelesManager;

        int seleccionado = nivelesManager.GetSeleccion();
        SerializableLevel nivel = nivelesManager.GetNiveles()[seleccionado];

        GameObject nivelDH = new GameObject("Nivel");
        var dataHandler = nivelDH.AddComponent<NivelDataHandler>() as NivelDataHandler;
        dataHandler.SetNivel(nivel);

        DontDestroyOnLoad(nivelDH);


        var manager = historiaManager.GetComponent<HistoriaManager>() as HistoriaManager;

        if (manager.TieneHistoria())
        {
            DontDestroyOnLoad(historiaManager.gameObject);

            SigEscena.CrossSceneInformation = "Historia " + manager.GetHistoria();
            SceneManager.LoadScene("PantallaCarga");
            //SceneManager.LoadScene("Historia " + manager.GetHistoria());
        }
        else
        {
            SigEscena.CrossSceneInformation = "Planificacion";
            SceneManager.LoadScene("PantallaCarga");
            //SceneManager.LoadScene("Planificacion");
        }
    }
}
