using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public void SetFullScreen(bool isActive)
    {
        Screen.fullScreen = isActive;
    }
}
