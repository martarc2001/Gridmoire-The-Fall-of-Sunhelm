using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGameOver : MonoBehaviour
{

    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        GameManager.instance.playSound(clip);
    }
}
