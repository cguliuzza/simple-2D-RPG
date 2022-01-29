using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Elemental
{
    Normal,
    Fire,
    Water,
    Grass,
    Rock,
    Psychic,
    Electric,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Bug,
    Ghost, 
    Dark,
    Dragon,
    Steel,
    Fairy
}

public enum ActionType
{
    Attack,
    Buff,
    Guard
}

[CreateAssetMenu(fileName = "MonsterAction", menuName = "ScriptableObjects/MonsterAction", order = 1)]
public class MonsterAction : ScriptableObject
{
    public string actionName;
    public int powerPoints;
    public ActionType actionType;
    [Range(0.0f, 1.0f)]
    public float damageMultiplier = 0.3f;
    public List<Elemental> elementStrength;
}
