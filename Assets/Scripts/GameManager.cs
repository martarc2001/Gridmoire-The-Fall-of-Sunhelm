using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private EjercitoManager em;

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
        em = GetComponent<EjercitoManager>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //if (em.GetEjercito().Count > 0)
            //Debug.Log(em.GetEjercito()[0]);
    }

    public EjercitoManager getEM() { return em; }
}
