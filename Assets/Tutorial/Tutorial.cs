using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Tutorial : MonoBehaviour
{
    private int actual;
    private int MAX_IMAGEN;
    private int MIN_IMAGEN;
    private string localizacion;
    [SerializeField] private GameObject imagen;
    private Object imagenElegida;
    [SerializeField] private List<Sprite> listaSprites;

    // Start is called before the first frame update
    void Start()
    {
        localizacion = "Tutorial\\Imagenes\\";
        MIN_IMAGEN = 2;
        MAX_IMAGEN = 2;
        actual = MIN_IMAGEN;

        imagenElegida=imagen.GetComponent<SpriteRenderer>().sprite;
        imagenElegida = listaSprites[actual+1];
        
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

    // Update is called once per frame
    void Update()
    {

    }


    public void Avanzar()
    {
        if (actual != MAX_IMAGEN)
        {

        }
    }

    public void Retrasar()
    {

    }
}

