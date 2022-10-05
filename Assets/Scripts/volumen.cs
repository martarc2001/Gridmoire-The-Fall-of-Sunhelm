using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumen : MonoBehaviour
{
    public AudioMixer mixer;
    
    public void ajustarVolumen(float volumen)
    {
        mixer.SetFloat("VolumenGeneral", volumen);
    }
}
