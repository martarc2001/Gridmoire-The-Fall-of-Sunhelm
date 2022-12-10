using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int dineroJugador = 2500;
    private AudioClip clipMenu;
    private int mundoSeleccionado = 1;
    private AudioSource audioSorce;
    public GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(gameObject);

        
        audioSorce = GetComponent<AudioSource>();
        audioSorce.volume = 1;
        clipMenu = audioSorce.clip;
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("PrimeraVez"))
        {
            PlayerPrefs.SetInt("PrimeraVez", 1);
            dineroJugador = 2500;
            PlayerPrefs.SetInt("Dinero", dineroJugador);
            PlayerPrefs.Save();
        }
        else
        {
            dineroJugador = PlayerPrefs.GetInt("Dinero");

        }
    }

    private void Update()
    {
        //if (em.GetEjercito().Count > 0)
            //Debug.Log(em.GetEjercito()[0]);
    }

    public void restarDinero(int dinero) { dineroJugador -= dinero; }
    public void sumarDinero(int dinero) { dineroJugador += dinero; }

    public void cambiarMundo(int mundo) { mundoSeleccionado = mundo; }

    public int getDineroJugador() { return dineroJugador; }

    public int GetMundoSeleccionado() { return mundoSeleccionado; }

    public AudioSource GetAudioSource() { return audioSorce; }

    public void setClip(AudioClip clip) {
        if (clip.name != audioSorce.clip.name)
        {
            audioSorce.clip = clip;
            audioSorce.Play();
        }
    }

    public IEnumerator playSound(AudioClip clip)
    {
        var volumenGeneral = audioSorce.volume;
        audioSorce.Stop();
        audioSorce.PlayOneShot(clip);
        audioSorce.volume = 1;
        yield return new WaitForSeconds(clip.length);
        audioSorce.Stop();
        audioSorce.volume = volumenGeneral;
        audioSorce.clip = clipMenu;
        audioSorce.Play();
    }
    
}
