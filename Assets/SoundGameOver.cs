using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGameOver : MonoBehaviour
{

    [SerializeField] private AudioClip clip;

    private void Start()
    {
        StartCoroutine(GameManager.instance.playSound(clip));
       
    }
}
