using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
#region Var
    private string colorIndicator;

    private List<int> colorIndicatorArray = new List<int>(); //public List<int> colorIndicatorArray = new List<int>();

    [SerializeField]
    private GameObject obj;

    float R;

    float G;

    float B;

    private Color objColor;
#endregion


    // Start is called before the first frame update
    void Start()
    {
        colorIndicator = GetComponentInChildren<TMPro.TextMeshProUGUI>().text;

        char[] separators = new char[] { ',' };
        string[] nums =
            colorIndicator
                .Split(separators, StringSplitOptions.RemoveEmptyEntries); //Number separation

        for (int i = 0; i < nums.Length; i++)
        {
            colorIndicatorArray.Add(Int32.Parse(nums[i]));
        }

        //Getting colors in RGB
        R = colorIndicatorArray[0] / 255f;
        G = colorIndicatorArray[1] / 255f;
        B = colorIndicatorArray[2] / 255f;
        objColor = new Color(R, G, B);

        //Asigning colors to each button based on their RBG
        var buttonColor = GetComponent<Image>().color;
        buttonColor = objColor;
        GetComponent<Image>().color = buttonColor;

        //Disabling the text so it looks prettier :) 💅🏿
        GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = false;
    }

    public void ChangeThisColor()
    {
        obj.GetComponent<Renderer>().material.color = objColor;
    }
}
