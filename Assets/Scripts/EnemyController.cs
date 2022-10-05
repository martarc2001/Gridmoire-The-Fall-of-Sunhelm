using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase de prueba para simular enemigos. Se convertirá en la clase de control de los enemigos
public class EnemyController : MonoBehaviour
{
    public bool hasEnemy;
    public float vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    public void takeDamage(float damage) { vida -= damage; }

    private void muere() { Debug.Log("Enemigo muerto"); }
}
