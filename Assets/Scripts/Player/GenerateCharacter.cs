using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCharacter : MonoBehaviour
{
    [SerializeField] private GameObject character;
    public void generateRandomCharacter()
    {
        var newCharacter = Instantiate(character);
        var attackType = (AttackType)Random.Range(0, 4);
        var attackScript = newCharacter.GetComponent<Attack>();
        attackScript.setAttackType(attackType);

        var randomAttack = Random.Range(10, 150);
        attackScript.getPlayerClass().setAttack(randomAttack);

        var randomDefense = Random.Range(10, 150);
        attackScript.getPlayerClass().setDeffense(randomDefense);

        var randomHP = Random.Range(150, 250);
        attackScript.getPlayerClass().setHp(randomHP);
    }
}
