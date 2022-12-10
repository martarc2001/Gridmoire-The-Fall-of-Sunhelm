using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : MonoBehaviour
{
    public AudioMixer mainMixer;

    public GameObject opciones;

    public List<Button> botones;

    //
    public void abreOpciones()
    {
        var slider = opciones.GetComponentInChildren<Slider>() as Slider;

        slider.value = GameManager.instance.GetAudioSource().volume;


        var toggle = opciones.GetComponentInChildren<Toggle>() as Toggle;

        bool auxToggle = Screen.fullScreen;

        toggle.isOn = auxToggle;



        opciones.SetActive(true);

        foreach(Button boton in botones)
        {
            boton.enabled = false;
        }
    }

    public void cierraOpciones()
    {
        opciones.SetActive(false);

        foreach (Button boton in botones)
        {
            boton.enabled = true;
        }
    }
}
