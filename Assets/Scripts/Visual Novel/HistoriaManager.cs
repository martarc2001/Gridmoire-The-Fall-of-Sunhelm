using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VNCreator;

public class HistoriaManager : MonoBehaviour
{
    private bool tieneHistoria = false;

    private string historia;

    // GETTERS & SETTERS

    public bool TieneHistoria() { return this.tieneHistoria; }
    public string GetHistoria() { return this.historia; }

    public void SetTieneHistoria(bool tieneHistoria) { this.tieneHistoria = tieneHistoria; }
    public void SetHistoria(string historia) { this.historia = historia; }

    // METODOS

    //private void Update()
    //{
    //    if(SceneManager.GetActiveScene().name == "Historia")
    //    {
    //        this.CargaHistoria();
    //    }
    //}

    //public void CargaHistoria()
    //{
    //    Debug.Log("he llegao");

    //    if (FindObjectOfType<VNCreator_DisplayUI>())
    //    {
    //        var visualNovel = FindObjectOfType<VNCreator_DisplayUI>();
    //        visualNovel.story = this.historia;
    //        visualNovel.enabled = true;

    //        Debug.Log(visualNovel.story.name);
    //        //Destroy(this.gameObject);
    //    }
    //}
}
