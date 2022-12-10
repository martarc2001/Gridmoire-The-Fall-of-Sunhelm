using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    public void ajustarVolumen(float volumen)
    {
        GameManager.instance.GetAudioSource().volume = volumen;
    }
}
