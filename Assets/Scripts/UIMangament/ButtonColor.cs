using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public void changeColor()
    {
        GetComponent<TextMeshProUGUI>().color = new Color(171,0,255);
    }

    public void blackColor()
    {
        //GetComponent<TextMeshProUGUI>().color = Color.black;
        GetComponent<TextMeshProUGUI>().color = Color.white;
        //GetComponent<TextMeshProUGUI>().color = new Color(171, 0, 255);
        //GetComponent<TextMeshProUGUI>().color =new Color(90/255f, 26/255f, 119/255f);
    }

   
}
