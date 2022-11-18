using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercitoRecompensa : MonoBehaviour
{

    private List<PlayerController> recompensados = new List<PlayerController>();
    

    public List<PlayerController> GetLista() { return recompensados; }
    public void SetLista(List<PlayerController> recompensados) { this.recompensados = recompensados; }
}
