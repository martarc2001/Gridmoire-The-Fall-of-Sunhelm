using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
