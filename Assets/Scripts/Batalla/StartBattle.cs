using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour
{
    [SerializeField] private LevelFlow levelFlow;
    
    public void iniciarBatalla()
    {
        levelFlow.SimulaPartida();
        gameObject.SetActive(false);
    }

}
