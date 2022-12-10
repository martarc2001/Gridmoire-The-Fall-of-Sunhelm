using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutlineText : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> textos;

    private void Start()
    {
        foreach(var texto in textos)
        {
            texto.outlineColor = new Color(0, 0, 0);
            texto.outlineWidth= 0.15f;
        }
    }
}
