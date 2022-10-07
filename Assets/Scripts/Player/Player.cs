using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    #region Variables

    #region Parameters
    [SerializeField] private float attack;
    [SerializeField] private float defense;
    [SerializeField] private float hp;
    #endregion

    #endregion
    public Player()
    {
        attack = 0;
        defense = 0;
        hp = 0;
    }

    public Player(float attack, float defense, float hp)
    {
        this.attack = attack;
        this.defense = defense;
        this.hp = hp;
    }

    public void takeDamage(float damage) { hp -= damage; }
    public void heal(float life) { hp += life; }

    public void setAttack(float value) { attack = value; }
    public void setDeffense(float value) { defense = value; }
    public void setHp(float value) { hp = value; }

    public float getAttack() { return attack; }
    public float getDefense() { return defense; }
    public float getHp() { return hp; }
}
