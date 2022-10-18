using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Renderer objRend;

    [SerializeField]
    private Color objColor = Color.white;

    [SerializeField]
    private GameObject colorButton;
    float R, G, B;

    private void Start()
    {
        objRend = GetComponent<Renderer>();
        objRend.material.color = objColor; //Tints all image, the white parts will be the same as the selected color while black remains unchanged; Transparent areas not affected
    }

/*
    private void Update()
    {
        R=colorButton.GetComponent<ButtonColorChange>().colorIndicatorArray[0]/255f;
        G=colorButton.GetComponent<ButtonColorChange>().colorIndicatorArray[1]/255f;
        B=colorButton.GetComponent<ButtonColorChange>().colorIndicatorArray[2]/255f;
        objColor=new Color(R,G,B);
        objRend.material.color = objColor;
    }
    */
}
