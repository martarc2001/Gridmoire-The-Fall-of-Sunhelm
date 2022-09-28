using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CheckPlatform : MonoBehaviour
{
    /*[DllImport("__Internal")]
    private static extern void IsMobile();

    public CheckPlatform instance;

    public CheckPlatform Instance
    {
        get { return instance; }
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

    public bool isMobile()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
                 return IsMobile();
        #endif
        return false;
    }*/
}
