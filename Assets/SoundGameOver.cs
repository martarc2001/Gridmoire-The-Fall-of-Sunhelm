using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundGameOver : MonoBehaviour
{

    [SerializeField] private AudioClip clip;

    private void Start()
    {
        StartCoroutine(GameManager.instance.playSound(clip));
       
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
