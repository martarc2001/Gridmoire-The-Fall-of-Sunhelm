using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Clase de prueba para simular turnos de los personajes del jugador
public class GameplayManager : MonoBehaviour
{

    private GameObject[] luchadoresJugador;
    //private GameObject[] luchadoresEnemigo;

    private int turnPlayer;
    //private int turnEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        luchadoresJugador = GameObject.FindGameObjectsWithTag("Player");
        turnPlayer = 0;

        StartCoroutine(turnCoRoutine());
    }

    IEnumerator turnCoRoutine()
    {
        if(turnPlayer < luchadoresJugador.Length)
            luchadoresJugador[turnPlayer].GetComponent<Attack>().perfomAttack();
        yield return new WaitForSeconds(1);
        /*if(turnEnemy < luchadoresEnemigo.Length)
            luchadoresEnemigo[turnEnemy].GetComponent<Attack>().perfomAttack();*/
        yield return new WaitForSeconds(1);
        turnPlayer++;
        //turnEnemy++;
        yield return new WaitForSeconds(1);
        StartCoroutine(turnCoRoutine());
    }
}
