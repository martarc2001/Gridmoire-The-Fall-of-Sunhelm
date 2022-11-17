using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{

    [SerializeField] private CeldaManager celdaAsociada;
    private PlayerController player;
    bool Activated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Activated)
            GetComponent<Slider>().value = player.getPersonaje().GetVida();

        if(GetComponent<Slider>().value == 0)
        {
            foreach (var image in GetComponentsInChildren<Image>())
            {
                image.enabled = false;
            }
        }
    }

    public void activar()
    {
        GetComponent<Slider>().maxValue = player.getPersonaje().GetVida();
        GetComponent<Slider>().minValue = 0;
        foreach(var image in GetComponentsInChildren<Image>())
        {
            image.enabled = true;
        }
        Activated = true;
    }

    public CeldaManager GetCelda() { return celdaAsociada; }

    public void setPlayer(PlayerController player) { this.player = player; }
}
