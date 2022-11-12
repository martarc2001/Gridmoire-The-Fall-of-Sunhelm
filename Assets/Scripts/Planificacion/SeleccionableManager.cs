using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionableManager : MonoBehaviour
{
    private bool esSeleccionable = true;
    // Start is called before the first frame update
    public bool isSelectable() { return esSeleccionable; }
    public void notSelectable() { esSeleccionable = false; }
    public void canSelectable() { esSeleccionable = true; }
}
