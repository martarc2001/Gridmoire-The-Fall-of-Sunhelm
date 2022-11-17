using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int dineroJugador = 1500;

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
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("PrimeraVez") == false)
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
}
