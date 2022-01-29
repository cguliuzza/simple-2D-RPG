using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gender
{
    Random,
    Male,
    Female
}


[CreateAssetMenu(fileName = "Monster", menuName = "ScriptableObjects/Monster", order = 1)]
public class Monster : ScriptableObject
{
    public string monsterName;
    public int monsterLevel;
    public int monsterMaxHP;
    public int monsterCurrentHP;
    public Sprite monsterSprite;
    public Gender monsterGender;
    public List<Elemental> monsterElements;
    public List<MonsterAction> monsterActions = new List<MonsterAction>();
}
