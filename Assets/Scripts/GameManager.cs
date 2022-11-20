using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int dineroJugador = 1500;
    private AudioClip clipMenu;
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

        clipMenu = GetComponent<AudioSource>().clip;
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("PrimeraVez"))
        {
            PlayerPrefs.SetInt("PrimeraVez", 1);
            dineroJugador = 1500;
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

    public int getDineroJugador() { return dineroJugador; }

    public void setClip(AudioClip clip) {
        if (clip.name != GetComponent<AudioSource>().clip.name)
        {
            GetComponent<AudioSource>().clip = clip;
            GetComponent<AudioSource>().Play();
        }
    }

    public void playSound(AudioClip clip)
    {
        var audio = GetComponent<AudioSource>().clip;
        GetComponent<AudioSource>().Stop() ;
        GetComponent<AudioSource>().PlayOneShot(clip);
        GetComponent<AudioSource>().clip = clipMenu;
        GetComponent<AudioSource>().Play();
    }
}
