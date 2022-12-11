using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Tutorial : MonoBehaviour
{
    private int actual;
    private int MAX_IMAGEN;
    private int MIN_IMAGEN=0;
    //private string localizacion;
    [SerializeField] private GameObject imagen;
    [SerializeField] private List<Sprite> listaSprites;
    private SpriteRenderer imagenElegida;
    [SerializeField] GameObject bRegreso;
    [SerializeField] GameObject bAvance;
    [SerializeField] GameObject animBatalla;

    // Start is called before the first frame update
    void Start()
    {
        //localizacion = "Tutorial\\Imagenes\\";

        
        MAX_IMAGEN = listaSprites.Count-1;
        actual = MIN_IMAGEN;

        imagenElegida=imagen.GetComponent<SpriteRenderer>();
        imagenElegida.sprite = listaSprites[actual];
        bRegreso.SetActive(false);
        
        /*
        imagenElegida = Resources.Load(localizacion + actual);
        Debug.Log(localizacion + actual);
        */
        /*
        DirectoryInfo d = new Directory(localizacion);
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis){MAX_IMAGEN++;}
        */
    }

    


    public void Avanzar()
    {
        Debug.Log("Avanza");
        if (actual != MAX_IMAGEN)
        {
            actual += 1;
            Batalla();
            if (actual == MAX_IMAGEN) { bAvance.SetActive(false);}
            if (!bRegreso.activeSelf) bRegreso.SetActive(true);

            imagenElegida.sprite = listaSprites[actual];
        }
        
    }

    public void Regresar()
    {
        Debug.Log("Regresa");
        if (actual != MIN_IMAGEN)
        {   
            actual -= 1;
            Batalla();
            if (actual == MIN_IMAGEN) { bRegreso.SetActive(false);}
            if (!bAvance.activeSelf) bAvance.SetActive(true);
            
            imagenElegida.sprite = listaSprites[actual];
        }
        
    }


    public void Batalla()
    {
        if (actual == 3)
        {
            animBatalla.SetActive(true);
            animBatalla.GetComponent<Animator>().enabled = true;
        }
        else
        {
            animBatalla.SetActive(false);
            animBatalla.GetComponent<Animator>().enabled = false;
        }
    }
}

